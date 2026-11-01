namespace ElevatorController
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.liftViewA = new ElevatorController.LiftView();
            this.liftViewB = new ElevatorController.LiftView();
            this.grpOutside = new System.Windows.Forms.GroupBox();
            this.hallTable = new System.Windows.Forms.TableLayoutPanel();
            this.panelHall2 = new System.Windows.Forms.Panel();
            this.lblFloor2Status = new System.Windows.Forms.Label();
            this.btnCall2 = new System.Windows.Forms.Button();
            this.panelHall1 = new System.Windows.Forms.Panel();
            this.lblFloor1Status = new System.Windows.Forms.Label();
            this.btnCall1 = new System.Windows.Forms.Button();
            this.panelLog = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelLogBottom = new System.Windows.Forms.Panel();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.progressLoading = new System.Windows.Forms.ProgressBar();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.table.SuspendLayout();
            this.grpOutside.SuspendLayout();
            this.hallTable.SuspendLayout();
            this.panelHall2.SuspendLayout();
            this.panelHall1.SuspendLayout();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelLogBottom.SuspendLayout();
            this.SuspendLayout();

            // table (4 columns that share the window width)
            this.table.ColumnCount = 4;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.table.Controls.Add(this.liftViewA, 0, 0);
            this.table.Controls.Add(this.grpOutside, 1, 0);
            this.table.Controls.Add(this.liftViewB, 2, 0);
            this.table.Controls.Add(this.panelLog, 3, 0);
            this.table.Controls.Add(this.lblEvent, 0, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table.Size = new System.Drawing.Size(1100, 595);
            this.table.SetColumnSpan(this.lblEvent, 4);
            
            // liftViewA
            this.liftViewA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liftViewA.Location = new System.Drawing.Point(3, 3);
            this.liftViewA.Name = "liftViewA";
            this.liftViewA.Size = new System.Drawing.Size(258, 559);

            // liftViewB
            this.liftViewB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liftViewB.Location = new System.Drawing.Point(456, 3);
            this.liftViewB.Name = "liftViewB";
            this.liftViewB.Size = new System.Drawing.Size(258, 559);
            
            // grpOutside
            this.grpOutside.Controls.Add(this.hallTable);
            this.grpOutside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutside.Location = new System.Drawing.Point(267, 3);
            this.grpOutside.Name = "grpOutside";
            this.grpOutside.Size = new System.Drawing.Size(183, 559);
            this.grpOutside.Text = "Outside the lifts (hall)";
            
            // hallTable (top half = floor 2, bottom half = floor 1)
            this.hallTable.ColumnCount = 1;
            this.hallTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hallTable.Controls.Add(this.panelHall2, 0, 0);
            this.hallTable.Controls.Add(this.panelHall1, 0, 1);
            this.hallTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hallTable.Location = new System.Drawing.Point(3, 19);
            this.hallTable.Name = "hallTable";
            this.hallTable.RowCount = 2;
            this.hallTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hallTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hallTable.Size = new System.Drawing.Size(177, 537);
            
            // panelHall2
            this.panelHall2.Controls.Add(this.lblFloor2Status);
            this.panelHall2.Controls.Add(this.btnCall2);
            this.panelHall2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHall2.Name = "panelHall2";
            
            // lblFloor2Status
            this.lblFloor2Status.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblFloor2Status.BackColor = System.Drawing.Color.White;
            this.lblFloor2Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFloor2Status.Location = new System.Drawing.Point(8, 20);
            this.lblFloor2Status.Name = "lblFloor2Status";
            this.lblFloor2Status.Size = new System.Drawing.Size(160, 66);
            this.lblFloor2Status.Text = "Floor 2";
            
            // btnCall2
            this.btnCall2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnCall2.Location = new System.Drawing.Point(8, 92);
            this.btnCall2.Name = "btnCall2";
            this.btnCall2.Size = new System.Drawing.Size(160, 40);
            this.btnCall2.Text = "Call lift (Floor 2)";
            this.btnCall2.Click += new System.EventHandler(this.btnCall2_Click);
            //
            // panelHall1
            //
            this.panelHall1.Controls.Add(this.lblFloor1Status);
            this.panelHall1.Controls.Add(this.btnCall1);
            this.panelHall1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHall1.Name = "panelHall1";
            
            // lblFloor1Status
            this.lblFloor1Status.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblFloor1Status.BackColor = System.Drawing.Color.White;
            this.lblFloor1Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFloor1Status.Location = new System.Drawing.Point(8, 20);
            this.lblFloor1Status.Name = "lblFloor1Status";
            this.lblFloor1Status.Size = new System.Drawing.Size(160, 66);
            this.lblFloor1Status.Text = "Floor 1";
            
            // btnCall1
            this.btnCall1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnCall1.Location = new System.Drawing.Point(8, 92);
            this.btnCall1.Name = "btnCall1";
            this.btnCall1.Size = new System.Drawing.Size(160, 40);
            this.btnCall1.Text = "Call lift (Floor 1)";
            this.btnCall1.Click += new System.EventHandler(this.btnCall1_Click);
            
            // panelLog
            this.panelLog.Controls.Add(this.grid);
            this.panelLog.Controls.Add(this.panelLogBottom);
            this.panelLog.Controls.Add(this.lblLogTitle);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(720, 3);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(377, 559);
            
            // grid
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 28);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(377, 436);
            
            // panelLogBottom
            this.panelLogBottom.Controls.Add(this.btnShowLog);
            this.panelLogBottom.Controls.Add(this.progressLoading);
            this.panelLogBottom.Controls.Add(this.lblDbStatus);
            this.panelLogBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogBottom.Location = new System.Drawing.Point(0, 464);
            this.panelLogBottom.Name = "panelLogBottom";
            this.panelLogBottom.Size = new System.Drawing.Size(377, 95);
            
            // btnShowLog
            this.btnShowLog.Location = new System.Drawing.Point(0, 6);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(140, 32);
            this.btnShowLog.Text = "Show log";
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            
            // progressLoading
            this.progressLoading.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.progressLoading.Location = new System.Drawing.Point(0, 46);
            this.progressLoading.MarqueeAnimationSpeed = 30;
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.Size = new System.Drawing.Size(377, 18);
            this.progressLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressLoading.Visible = false;
            
            // lblDbStatus
            this.lblDbStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblDbStatus.Location = new System.Drawing.Point(0, 68);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(377, 26);
            this.lblDbStatus.Text = "";
            
            // lblLogTitle
            this.lblLogTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(377, 28);
            this.lblLogTitle.Text = "Live log (stored in the Access database)";
            this.lblLogTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // lblEvent
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEvent.Location = new System.Drawing.Point(3, 565);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(1094, 30);
            this.lblEvent.Text = "Ready";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 595);
            this.Controls.Add(this.table);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "Form1";
            this.Text = "Two-Lift Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.table.ResumeLayout(false);
            this.grpOutside.ResumeLayout(false);
            this.hallTable.ResumeLayout(false);
            this.panelHall2.ResumeLayout(false);
            this.panelHall1.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelLogBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel table;
        private LiftView liftViewA;
        private LiftView liftViewB;
        private System.Windows.Forms.GroupBox grpOutside;
        private System.Windows.Forms.TableLayoutPanel hallTable;
        private System.Windows.Forms.Panel panelHall2;
        private System.Windows.Forms.Label lblFloor2Status;
        private System.Windows.Forms.Button btnCall2;
        private System.Windows.Forms.Panel panelHall1;
        private System.Windows.Forms.Label lblFloor1Status;
        private System.Windows.Forms.Button btnCall1;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelLogBottom;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.ProgressBar progressLoading;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.Label lblEvent;
    }
}