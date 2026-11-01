using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;

namespace ElevatorController
{
    // one piece of database work, passed to the background thread
    public class DbJob
    {
        public bool IsWrite;
        public string LiftName = "";
        public int Floor;
        public string Text = "";
        public DateTime Time;
        public DataTable Table;      // result of a read
        public string Error = "";    // filled in if something went wrong
    }

    // Observer: listens to the lifts, and writes events to the database on a BACKGROUND thread
    public class DatabaseLogger : ILiftObserver
    {
        private LogDatabase db = new LogDatabase();
        private BackgroundWorker worker = new BackgroundWorker();
        private Queue<DbJob> jobs = new Queue<DbJob>();
        private bool readWaiting = false;

        // delegates: the form plugs its own methods in here
        public Action<bool> BusyChanged;
        public Action<DataTable> LogLoaded;
        public Action<string> ErrorHappened;

        public DatabaseLogger()
        {
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public void OnLiftChanged(Lift lift, string message)
        {
            if (message == "") return;             // plain animation step, nothing to log

            DbJob job = new DbJob();
            job.IsWrite = true;
            job.LiftName = lift.Name;
            job.Floor = lift.Floor;
            job.Text = message;
            job.Time = DateTime.Now;               // timestamp taken at the moment of the event
            AddJob(job);
        }

        public void RefreshLog()
        {
            if (readWaiting) return;               // one waiting read is enough
            readWaiting = true;
            DbJob job = new DbJob();
            job.IsWrite = false;
            AddJob(job);
        }

        private void AddJob(DbJob job)
        {
            jobs.Enqueue(job);
            StartNext();
        }

        private void StartNext()
        {
            if (worker.IsBusy || jobs.Count == 0) return;

            DbJob job = jobs.Dequeue();
            if (!job.IsWrite) readWaiting = false;

            BusyChanged?.Invoke(true);
            worker.RunWorkerAsync(job);            // runs Worker_DoWork on another thread
        }

        // runs on the BACKGROUND thread: no controls may be touched here
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DbJob job = (DbJob)e.Argument;
            try
            {
                if (job.IsWrite)
                    db.AddLog(job.LiftName, job.Floor, job.Text, job.Time);
                else
                    job.Table = db.GetLog();
            }
            catch (Exception ex)
            {
                job.Error = ex.Message;
            }
            e.Result = job;
        }

        // runs back on the WINDOW thread: safe to update the screen
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ErrorHappened?.Invoke(e.Error.Message);
            }
            else
            {
                DbJob job = (DbJob)e.Result;
                if (job.Error != "") ErrorHappened?.Invoke(job.Error);
                else if (job.IsWrite) RefreshLog();          // new row saved, so reload the log
                else LogLoaded?.Invoke(job.Table);
            }

            StartNext();
            if (!worker.IsBusy) BusyChanged?.Invoke(false);
        }
    }
}