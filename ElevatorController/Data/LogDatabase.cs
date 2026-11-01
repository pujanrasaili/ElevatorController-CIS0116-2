using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ElevatorController
{
    public class LogDatabase
    {
        // relative path: the database sits next to the .exe, so it works on any computer
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
            + Path.Combine(AppContext.BaseDirectory, "ElevatorLog.accdb") + ";";

        private OleDbDataAdapter MakeAdapter(string sql)
        {
            return new OleDbDataAdapter(sql, connectionString);
        }

        // read all records (newest first)
        public DataTable GetLog()
        {
            OleDbDataAdapter adapter = MakeAdapter("SELECT * FROM ElevatorLog ORDER BY ID DESC");
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // add one record using the disconnected model (Fill, change in memory, Update)
        public void AddLog(string liftName, int floor, string text, DateTime time)
        {
            OleDbDataAdapter adapter = MakeAdapter("SELECT * FROM ElevatorLog WHERE 1 = 0");
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);  // builds the INSERT command for us

            DataTable table = new DataTable();
            adapter.Fill(table);                       // only gets the column layout

            DataRow row = table.NewRow();
            row["LiftName"] = liftName;
            row["FloorNumber"] = floor;
            row["EventText"] = text;
            row["LogTime"] = time;
            table.Rows.Add(row);

            adapter.Update(table);                     // sends the new row to the database
        }
    }
}