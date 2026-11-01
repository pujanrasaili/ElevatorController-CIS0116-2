using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ElevatorController
{
    // One lift on screen: shaft, car, doors and its own control panel.
    // It is an OBSERVER: the Lift tells it whenever something changes.
    public partial class LiftView : UserControl, ILiftObserver
    {
        private Lift lift;
        private System.Windows.Forms.Timer flashTimer = new System.Windows.Forms.Timer();
        private bool flashOn = false;

        private const int HeaderHeight = 24;   // black floor-indicator strip on top of the car
        private int middleLineY = 0;           // the line between floor 2 (top half) and floor 1 (bottom half)
        private string indicatorText = "1";

        public LiftView()
        {
            InitializeComponent();

            shaftHost.Resize += ShaftHost_Resize;
            shaft.Paint += Shaft_Paint;
            car.Paint += Car_Paint;
            doorLeft.Paint += Door_Paint;      // the doors are drawn by us (steel look)
            doorRight.Paint += Door_Paint;
            LayoutParts();
        }

        public void ConnectTo(Lift liftToShow)
        {
            lift = liftToShow;
            lift.Attach(this);
            OnLiftChanged(lift, "");

            flashTimer.Interval = 500;          // makes the alarm flash
            flashTimer.Tick += FlashTimer_Tick;
            flashTimer.Start();
        }

        private void ShaftHost_Resize(object sender, EventArgs e)
        {
            LayoutParts();
        }

        // Works out the size and position of the shaft, car and doors from the
        // REAL size of the area, so it looks right in any window and at any screen scaling.
        private void LayoutParts()
        {
            int hostW = shaftHost.ClientSize.Width;
            int hostH = shaftHost.ClientSize.Height;
            if (hostW < 120 || hostH < 150) return;

            int side = 8;                                        // gap between shaft wall and car
            int gap = 4;                                         // gap between the car and the floor line
            int shaftH = hostH - 12;
            int innerH = shaftH - 2;                             // minus the border
            int half = innerH / 2;                               // each floor gets half of the shaft
            int carH = half * 80 / 100;                          // car = 80% of one floor's height
            int carW = carH * 62 / 100;                          // tall and narrow, like a real lift
            if (carW > hostW - 130) carW = Math.Max(60, hostW - 130);
            int shaftW = carW + 2 * side + 2;

            shaft.SetBounds((hostW - shaftW) / 2, 6, shaftW, shaftH);

            int position = (lift == null) ? 0 : lift.Position;   // 0 = floor 1, 100 = floor 2
            int open = (lift == null) ? 0 : lift.DoorOpen;       // 0 = closed, 100 = open

            // the car stands ON its floor: floor 2 stands on the middle line, floor 1 on the bottom
            int floor2Top = half - gap - carH;
            car.SetBounds(side, floor2Top + half * (100 - position) / 100, carW, carH);

            // doors open from the CENTRE: each door shrinks towards its own side
            int doorsH = carH - HeaderHeight;
            int leftMax = carW / 2;
            int rightMax = carW - leftMax;
            int leftW = leftMax * (100 - open) / 100;
            int rightW = rightMax * (100 - open) / 100;
            doorLeft.SetBounds(0, HeaderHeight, leftW, doorsH);
            doorRight.SetBounds(carW - rightW, HeaderHeight, rightW, doorsH);

            // floor labels sit level with the car at each floor
            middleLineY = half;
            lblFloor2.Left = 6;
            lblFloor1.Left = 6;
            lblFloor2.Top = shaft.Top + 1 + floor2Top + carH / 2 - lblFloor2.Height / 2;
            lblFloor1.Top = shaft.Top + 1 + floor2Top + half + carH / 2 - lblFloor1.Height / 2;
            shaft.Invalidate();
        }

        // guide rails and the line that divides floor 2 (top) from floor 1 (bottom)
        private void Shaft_Paint(object sender, PaintEventArgs e)
        {
            int w = shaft.ClientSize.Width;
            int h = shaft.ClientSize.Height;

            using (Pen rail = new Pen(Color.Silver, 3))
            {
                e.Graphics.DrawLine(rail, 3, 0, 3, h);
                e.Graphics.DrawLine(rail, w - 4, 0, w - 4, h);
            }
            using (Pen floorLine = new Pen(Color.Black, 3))
            {
                e.Graphics.DrawLine(floorLine, 0, middleLineY, w, middleLineY);
            }
        }

        // the car frame and the little floor indicator above the doors
        private void Car_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = car.ClientSize.Width;
            int h = car.ClientSize.Height;

            g.FillRectangle(Brushes.Black, 0, 0, w, HeaderHeight);
            using (Font f = new Font("Segoe UI", 9F, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, indicatorText, f, new Rectangle(0, 0, w, HeaderHeight),
                    Color.Lime, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            g.DrawRectangle(Pens.Black, 0, 0, w - 1, h - 1);
        }

        // one steel door: a gradient that is darker next to the centre seam, and a dark edge
        private void Door_Paint(object sender, PaintEventArgs e)
        {
            Panel door = (Panel)sender;
            Rectangle r = door.ClientRectangle;
            if (r.Width < 3 || r.Height < 3) return;

            bool isLeft = (door == doorLeft);
            Color outer = Color.Silver;
            Color seam = Color.DimGray;

            using (LinearGradientBrush brush = new LinearGradientBrush(r, isLeft ? outer : seam, isLeft ? seam : outer, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, r);
            }
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, r.Width - 1, r.Height - 1);
        }

        // buttons on this lift's control panel: they only talk to THIS lift
        private void btnFloor1_Click(object sender, EventArgs e)
        {
            lift.InsideRequest(1);
        }

        private void btnFloor2_Click(object sender, EventArgs e)
        {
            lift.InsideRequest(2);
        }

        private void btnDoorOpen_Click(object sender, EventArgs e)
        {
            lift.PressDoorOpen();
        }

        private void btnDoorClose_Click(object sender, EventArgs e)
        {
            lift.PressDoorClose();
        }

        private void btnEmergency_Click(object sender, EventArgs e)
        {
            lift.PressEmergency();
        }

        // flashes the title and the status text red while the alarm is active
        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            flashOn = !flashOn;
            if (lift == null) return;

            Color back = SystemColors.Control;
            Color fore = SystemColors.ControlText;
            if (lift.AlarmActive)
            {
                back = flashOn ? Color.Red : SystemColors.Control;
                fore = flashOn ? Color.White : Color.Red;
            }
            lblState.BackColor = back;
            lblState.ForeColor = fore;
            lblTitle.BackColor = back;
            lblTitle.ForeColor = lift.AlarmActive ? fore : SystemColors.ControlText;
        }

        // called by the Lift every time something changes 
        public void OnLiftChanged(Lift changed, string message)
        {
            LayoutParts();                      // moves the car and the doors

            string arrow = "";
            if (changed.State is MovingState)
            {
                arrow = (changed.TargetFloor > changed.Floor) ? "▲ " : "▼ ";
            }
            indicatorText = arrow + changed.Floor;
            car.Invalidate();

            lblDisplay.Text = ("Floor " + changed.Floor + "  " + arrow).TrimEnd();
            lblTitle.Text = changed.AlarmActive ? changed.Name.ToUpper() + "  -  ALARM" : changed.Name.ToUpper();

            if (changed.AlarmActive)
                lblState.Text = "ALARM - SECURITY NOTIFIED";
            else
                lblState.Text = "State: " + changed.State.Name;

            btnEmergency.Text = changed.AlarmActive ? "CANCEL ALARM" : "EMERGENCY ALARM";

            // audible alert at the moment the alarm is pressed
            if (message.StartsWith("EMERGENCY ALARM"))
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }
    }

    // A panel that redraws without flicker (the animation changes it many times a second).
    // It stays BELOW the LiftView class on purpose: the Designer needs LiftView to be first in this file.
    public class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}