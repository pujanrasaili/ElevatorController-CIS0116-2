namespace ElevatorController
{
    partial class LiftView
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.shaftHost = new System.Windows.Forms.Panel();
            this.lblFloor2 = new System.Windows.Forms.Label();
            this.lblFloor1 = new System.Windows.Forms.Label();
            this.shaft = new ElevatorController.BufferedPanel();
            this.car = new ElevatorController.BufferedPanel();
            this.doorLeft = new ElevatorController.BufferedPanel();
            this.doorRight = new ElevatorController.BufferedPanel();
            this.grpPanel = new System.Windows.Forms.GroupBox();
            this.panelTable = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.btnFloor2 = new System.Windows.Forms.Button();
            this.btnFloor1 = new System.Windows.Forms.Button();
            this.btnDoorOpen = new System.Windows.Forms.Button();
            this.btnDoorClose = new System.Windows.Forms.Button();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.shaftHost.SuspendLayout();
            this.shaft.SuspendLayout();
            this.car.SuspendLayout();
            this.grpPanel.SuspendLayout();
            this.panelTable.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 32);
            this.lblTitle.Text = "LIFT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // shaftHost
            //
            this.shaftHost.Controls.Add(this.lblFloor2);
            this.shaftHost.Controls.Add(this.lblFloor1);
            this.shaftHost.Controls.Add(this.shaft);
            this.shaftHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shaftHost.Location = new System.Drawing.Point(0, 32);
            this.shaftHost.Name = "shaftHost";
            this.shaftHost.Size = new System.Drawing.Size(250, 303);
            //
            // lblFloor2
            //
            this.lblFloor2.AutoSize = true;
            this.lblFloor2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFloor2.Location = new System.Drawing.Point(6, 40);
            this.lblFloor2.Name = "lblFloor2";
            this.lblFloor2.Text = "Floor 2";
            //
            // lblFloor1
            //
            this.lblFloor1.AutoSize = true;
            this.lblFloor1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFloor1.Location = new System.Drawing.Point(6, 200);
            this.lblFloor1.Name = "lblFloor1";
            this.lblFloor1.Text = "Floor 1";
            //
            // shaft
            //
            this.shaft.BackColor = System.Drawing.Color.FromArgb(70, 70, 78);
            this.shaft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shaft.Controls.Add(this.car);
            this.shaft.Location = new System.Drawing.Point(60, 6);
            this.shaft.Name = "shaft";
            this.shaft.Size = new System.Drawing.Size(130, 290);
            //
            // car
            //
            this.car.BackColor = System.Drawing.Color.Khaki;
            this.car.Controls.Add(this.doorLeft);
            this.car.Controls.Add(this.doorRight);
            this.car.Location = new System.Drawing.Point(8, 150);
            this.car.Name = "car";
            this.car.Size = new System.Drawing.Size(110, 120);
            //
            // doorLeft
            //
            this.doorLeft.BackColor = System.Drawing.Color.DimGray;
            this.doorLeft.Location = new System.Drawing.Point(0, 24);
            this.doorLeft.Name = "doorLeft";
            this.doorLeft.Size = new System.Drawing.Size(55, 96);
            //
            // doorRight
            //
            this.doorRight.BackColor = System.Drawing.Color.DimGray;
            this.doorRight.Location = new System.Drawing.Point(55, 24);
            this.doorRight.Name = "doorRight";
            this.doorRight.Size = new System.Drawing.Size(55, 96);
            //
            // grpPanel
            //
            this.grpPanel.Controls.Add(this.panelTable);
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpPanel.Location = new System.Drawing.Point(0, 335);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(250, 200);
            this.grpPanel.Text = "Control panel (inside the lift)";
            //
            // panelTable
            //
            this.panelTable.ColumnCount = 2;
            this.panelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTable.Controls.Add(this.lblDisplay, 0, 0);
            this.panelTable.Controls.Add(this.lblState, 0, 1);
            this.panelTable.Controls.Add(this.btnFloor2, 0, 2);
            this.panelTable.Controls.Add(this.btnFloor1, 1, 2);
            this.panelTable.Controls.Add(this.btnDoorOpen, 0, 3);
            this.panelTable.Controls.Add(this.btnDoorClose, 1, 3);
            this.panelTable.Controls.Add(this.btnEmergency, 0, 4);
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTable.Location = new System.Drawing.Point(3, 19);
            this.panelTable.Name = "panelTable";
            this.panelTable.RowCount = 5;
            this.panelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.panelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.panelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.panelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.panelTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelTable.Size = new System.Drawing.Size(244, 178);
            this.panelTable.SetColumnSpan(this.lblDisplay, 2);
            this.panelTable.SetColumnSpan(this.lblState, 2);
            this.panelTable.SetColumnSpan(this.btnEmergency, 2);
            //
            // lblDisplay
            //
            this.lblDisplay.BackColor = System.Drawing.Color.Black;
            this.lblDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDisplay.ForeColor = System.Drawing.Color.Lime;
            this.lblDisplay.Margin = new System.Windows.Forms.Padding(3);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Text = "Floor 1";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblState
            //
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblState.Name = "lblState";
            this.lblState.Text = "State: Idle";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnFloor2
            //
            this.btnFloor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFloor2.Margin = new System.Windows.Forms.Padding(3);
            this.btnFloor2.Name = "btnFloor2";
            this.btnFloor2.Text = "Floor 2";
            this.btnFloor2.Click += new System.EventHandler(this.btnFloor2_Click);
            //
            // btnFloor1
            //
            this.btnFloor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFloor1.Margin = new System.Windows.Forms.Padding(3);
            this.btnFloor1.Name = "btnFloor1";
            this.btnFloor1.Text = "Floor 1";
            this.btnFloor1.Click += new System.EventHandler(this.btnFloor1_Click);
            //
            // btnDoorOpen
            //
            this.btnDoorOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoorOpen.Margin = new System.Windows.Forms.Padding(3);
            this.btnDoorOpen.Name = "btnDoorOpen";
            this.btnDoorOpen.Text = "Open doors";
            this.btnDoorOpen.Click += new System.EventHandler(this.btnDoorOpen_Click);
            //
            // btnDoorClose
            //
            this.btnDoorClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoorClose.Margin = new System.Windows.Forms.Padding(3);
            this.btnDoorClose.Name = "btnDoorClose";
            this.btnDoorClose.Text = "Close doors";
            this.btnDoorClose.Click += new System.EventHandler(this.btnDoorClose_Click);
            //
            // btnEmergency
            //
            this.btnEmergency.BackColor = System.Drawing.Color.Red;
            this.btnEmergency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmergency.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEmergency.ForeColor = System.Drawing.Color.White;
            this.btnEmergency.Margin = new System.Windows.Forms.Padding(3);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Text = "EMERGENCY ALARM";
            this.btnEmergency.UseVisualStyleBackColor = false;
            this.btnEmergency.Click += new System.EventHandler(this.btnEmergency_Click);
            //
            // LiftView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shaftHost);
            this.Controls.Add(this.grpPanel);
            this.Controls.Add(this.lblTitle);
            this.Name = "LiftView";
            this.Size = new System.Drawing.Size(250, 535);
            this.shaftHost.ResumeLayout(false);
            this.shaftHost.PerformLayout();
            this.shaft.ResumeLayout(false);
            this.car.ResumeLayout(false);
            this.grpPanel.ResumeLayout(false);
            this.panelTable.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel shaftHost;
        private System.Windows.Forms.Label lblFloor2;
        private System.Windows.Forms.Label lblFloor1;
        private ElevatorController.BufferedPanel shaft;
        private ElevatorController.BufferedPanel car;
        private ElevatorController.BufferedPanel doorLeft;
        private ElevatorController.BufferedPanel doorRight;
        private System.Windows.Forms.GroupBox grpPanel;
        private System.Windows.Forms.TableLayoutPanel panelTable;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnFloor2;
        private System.Windows.Forms.Button btnFloor1;
        private System.Windows.Forms.Button btnDoorOpen;
        private System.Windows.Forms.Button btnDoorClose;
        private System.Windows.Forms.Button btnEmergency;
    }
}