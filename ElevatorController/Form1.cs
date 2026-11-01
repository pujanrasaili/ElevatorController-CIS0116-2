using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ElevatorController
{
    // The form is also an OBSERVER: it shows the two floor status displays.
    public partial class Form1 : Form, ILiftObserver
    {
        Lift liftA = new Lift("Lift A");
        Lift liftB = new Lift("Lift B");
        LiftDispatcher dispatcher;
        DatabaseLogger logger = new DatabaseLogger();

        public Form1()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;     // start full screen

            dispatcher = new LiftDispatcher(liftA, liftB);

            // each LiftView shows one lift and registers itself as an observer
            liftViewA.ConnectTo(liftA);
            liftViewB.ConnectTo(liftB);

            // the form and the logger also observe both lifts
            liftA.Attach(this);
            liftB.Attach(this);
            liftA.Attach(logger);
            liftB.Attach(logger);

            // plug our methods into the logger's delegates
            logger.BusyChanged = ShowBusy;
            logger.LogLoaded = ShowLog;
            logger.ErrorHappened = ShowError;

            ShowFloorStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.RefreshLog();               // load the old records when the program starts
        }
         
        // outside (hall) buttons: the dispatcher picks the best lift
        private void btnCall1_Click(object sender, EventArgs e)
        {
            CallLift(1);
        }

        private void btnCall2_Click(object sender, EventArgs e)
        {
            CallLift(2);
        }

        private void CallLift(int floor)
        {
            Lift chosen = dispatcher.AssignHallCall(floor);
            if (chosen == null)
            {
                lblEvent.Text = "No lift available (both in alarm)";
            }
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            logger.RefreshLog();
        }

        // Observer: called whenever a lift changes
        public void OnLiftChanged(Lift lift, string message)
        {
            ShowFloorStatus();
            if (message != "")
            {
                lblEvent.Text = lift.Name + ": " + message;
            }
        }

        private void ShowFloorStatus()
        {
            lblFloor1Status.Text = "FLOOR 1" + Environment.NewLine + Describe(liftA, 1) + Environment.NewLine + Describe(liftB, 1);
            lblFloor2Status.Text = "FLOOR 2" + Environment.NewLine + Describe(liftA, 2) + Environment.NewLine + Describe(liftB, 2);
        }

        private string Describe(Lift lift, int floor)
        {
            string text;
            if (lift.Position == Lift.FloorPosition(floor)) text = lift.Name + ": HERE";
            else if (lift.State is MovingState) text = lift.Name + ": moving";
            else text = lift.Name + ": away";

            if (lift.AlarmActive) text += " (ALARM)";
            return text;
        }

        // methods the logger calls (through delegates)
        private void ShowBusy(bool busy)
        {
            progressLoading.Visible = busy;
            if (busy)
            {
                lblDbStatus.ForeColor = Color.Black;
                lblDbStatus.Text = "Working with the database...";
            }
            else if (lblDbStatus.ForeColor != Color.Red)
            {
                lblDbStatus.Text = "";
            }
        }

        private void ShowLog(DataTable table)
        {
            grid.DataSource = table;
            grid.Columns["ID"].FillWeight = 40;
            grid.Columns["LiftName"].FillWeight = 60;
            grid.Columns["FloorNumber"].FillWeight = 60;
            grid.Columns["EventText"].FillWeight = 220;
            grid.Columns["LogTime"].FillWeight = 130;
        }
        private void ShowError(string message)
        {
            lblDbStatus.ForeColor = Color.Red;
            lblDbStatus.Text = "Database error: " + message;
        }
    }
}