using System;
using System.Collections.Generic;

namespace ElevatorController
{
    // Observer pattern: anything that wants to hear about a lift implements this.
    public interface ILiftObserver
    {
        void OnLiftChanged(Lift lift, string message);
    }

    public class Lift
    {
        public const int TravelTicks = 50;     // timer ticks to go from one floor to the other
        public const int DoorTicks = 65;       // timer ticks for doors to open, wait and close
        public const int NotAvailable = 99999; // "this lift cannot take the request"

        public string Name { get; private set; }
        public int Floor { get; set; } = 1;        // last floor the lift stopped at
        public int TargetFloor { get; set; } = 1;  // floor it is heading to
        public int Position { get; set; } = 0;     // 0 = floor 1, 100 = floor 2
        public int DoorOpen { get; set; } = 0;     // 0 = closed, 100 = fully open
        public bool AlarmActive { get; private set; } = false;   // passenger pressed the alarm
        public List<int> Queue { get; private set; } = new List<int>();  // waiting stops
        public LiftState State { get; private set; }

        private List<ILiftObserver> observers = new List<ILiftObserver>();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Lift(string name)
        {
            Name = name;
            State = new IdleState();
            timer.Interval = 40;               // the animation "heartbeat"
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            State.Tick(this);                  // the current state decides what happens
        }

        // Observer pattern
        public void Attach(ILiftObserver observer) { observers.Add(observer); }
        public void Detach(ILiftObserver observer) { observers.Remove(observer); }

        // message = "" for plain animation steps, or text for events worth logging
        public void Notify(string message)
        {
            foreach (ILiftObserver observer in observers)
            {
                observer.OnLiftChanged(this, message);
            }
        }

        // State pattern
        public void SetState(LiftState newState)
        {
            State = newState;
            Notify("");
        }

        // Requests
        public void InsideRequest(int floor)   // button inside this lift
        {
            Notify("Inside request: floor " + floor);
            State.Request(this, floor);
        }

        public void HallRequest(int floor)     // call button outside, given to this lift by the dispatcher
        {
            Notify("Hall call for floor " + floor + " assigned");
            State.Request(this, floor);
        }

        // Alarm / intercom button: it does NOT stop the lift.
        public void PressEmergency()
        {
            if (AlarmActive)
            {
                AlarmActive = false;
                Notify("Alarm cancelled - lift back in service");
            }
            else
            {
                AlarmActive = true;
                Queue.Clear();                                  // only the trip already in progress is finished
                if (State is IdleState) Queue.Add(Floor);       // idle: open the doors so passengers can leave
                Notify("EMERGENCY ALARM TRIGGERED - PASSENGER REQUESTING ASSISTANCE");
            }
        }

        public void PressDoorOpen()
        {
            if (State is MovingState)
            {
                Notify("Door open ignored: lift is moving");
                return;
            }
            Notify("Door OPEN button pressed");
            State.OpenDoors(this);
        }

        public void PressDoorClose()
        {
            if (State is MovingState)
            {
                Notify("Door close ignored: lift is moving");
                return;
            }
            Notify("Door CLOSE button pressed");
            State.CloseDoors(this);
        }

        public void QueueStop(int floor)
        {
            if (!Queue.Contains(floor))
            {
                Queue.Add(floor);              // added at the END, so the current trip is never disturbed
            }
        }

        //Helpers
        public bool AtFloor() { return Position == 0 || Position == 100; }

        public static int FloorPosition(int floor) { return (floor - 1) * 100; }

        public int TravelLeft()
        {
            return Math.Abs(FloorPosition(TargetFloor) - Position) / 2;
        }

        private static int Travel(int fromFloor, int toFloor)
        {
            return (fromFloor == toFloor) ? 0 : TravelTicks;
        }

        // Estimated time (in ticks) before this lift could be at the given floor.
        public int EstimateTime(int floor)
        {
            if (AlarmActive) return NotAvailable;      // a lift with an active alarm gets no new hall calls

            // already on its way there with nothing else queued
            if (State is MovingState && Queue.Count == 0 && TargetFloor == floor)
                return TravelLeft();

            // already standing at that floor
            if (!(State is MovingState) && AtFloor() && Floor == floor)
                return 0;

            int time = State.RemainingTicks(this);     // finish the current job first
            int position = State.FinalFloor(this);     // where the lift will be after it

            foreach (int stop in Queue)                // then every stop already waiting
            {
                time += Travel(position, stop) + DoorTicks;
                position = stop;
            }

            return time + Travel(position, floor);     // finally the trip to the new floor
        }
    }
}