namespace ElevatorController
{
    // State pattern: each state decides how the lift reacts to a tick, a request or a door button.
    public abstract class LiftState
    {
        public abstract string Name { get; }
        public abstract void Tick(Lift lift);
        public abstract void Request(Lift lift, int floor);
        public abstract int RemainingTicks(Lift lift);   // time left in the current job
        public abstract int FinalFloor(Lift lift);       // floor where the current job ends

        // door buttons do nothing unless a state overrides them
        public virtual void OpenDoors(Lift lift) { }
        public virtual void CloseDoors(Lift lift) { }
    }

    public class IdleState : LiftState
    {
        public override string Name { get { return "Idle"; } }

        public override void Tick(Lift lift)
        {
            if (lift.Queue.Count == 0) return;

            int next = lift.Queue[0];
            lift.Queue.RemoveAt(0);

            if (next == lift.Floor)
            {
                lift.SetState(new DoorsState());       // already here: just open the doors
            }
            else
            {
                lift.TargetFloor = next;
                lift.SetState(new MovingState());
                lift.Notify("Moving to floor " + next);
            }
        }

        public override void Request(Lift lift, int floor) { lift.QueueStop(floor); }
        public override int RemainingTicks(Lift lift) { return 0; }
        public override int FinalFloor(Lift lift) { return lift.Floor; }

        public override void OpenDoors(Lift lift)
        {
            lift.SetState(new DoorsState());           // open the doors at this floor
        }
    }

    public class MovingState : LiftState
    {
        public override string Name { get { return "Moving"; } }

        public override void Tick(Lift lift)
        {
            int targetPosition = Lift.FloorPosition(lift.TargetFloor);

            if (lift.Position < targetPosition) lift.Position += 2;
            else lift.Position -= 2;

            if (lift.Position == targetPosition)
            {
                lift.Floor = lift.TargetFloor;
                lift.Notify("Arrived at floor " + lift.Floor);
                lift.SetState(new DoorsState());
            }
            else
            {
                lift.Notify("");
            }
        }

        public override void Request(Lift lift, int floor)
        {
            if (floor != lift.TargetFloor)         // the current trip is never changed
            {
                lift.QueueStop(floor);
            }
        }

        public override int RemainingTicks(Lift lift) { return lift.TravelLeft() + Lift.DoorTicks; }
        public override int FinalFloor(Lift lift) { return lift.TargetFloor; }
    }

    public class DoorsState : LiftState
    {
        private const int WaitTicks = 125;     // 5 seconds with the doors fully open (125 x 40 ms)

        private int phase = 0;                 // 0 = opening, 1 = waiting, 2 = closing
        private int waited = 0;
        private bool closeWanted = false;      // "Close" was pressed while the doors were still opening

        public override string Name
        {
            get
            {
                if (phase == 0) return "Doors opening";
                if (phase == 1) return "Doors open";
                return "Doors closing";
            }
        }

        public override void Tick(Lift lift)
        {
            if (phase == 0)
            {
                lift.DoorOpen += 5;
                if (lift.DoorOpen >= 100)
                {
                    lift.DoorOpen = 100;
                    phase = closeWanted ? 2 : 1;   // close at once if the button was already pressed
                    lift.Notify("Doors open at floor " + lift.Floor);
                }
            }
            else if (phase == 1)
            {
                waited++;
                if (waited >= WaitTicks) phase = 2;
            }
            else
            {
                lift.DoorOpen -= 5;
                if (lift.DoorOpen <= 0)
                {
                    lift.DoorOpen = 0;
                    lift.Notify("Doors closed at floor " + lift.Floor);
                    lift.SetState(new IdleState());
                    return;
                }
            }
            lift.Notify("");
        }

        public override void Request(Lift lift, int floor)
        {
            if (floor != lift.Floor)               // doors are already open at this floor
            {
                lift.QueueStop(floor);
            }
        }

        // "Open" button: hold the doors open, or reopen them if they are closing
        public override void OpenDoors(Lift lift)
        {
            closeWanted = false;
            if (phase == 1) waited = 0;
            else if (phase == 2) phase = 0;
        }

        // "Close" button: close early (or as soon as the doors are fully open)
        public override void CloseDoors(Lift lift)
        {
            if (phase == 1) waited = WaitTicks;
            else if (phase == 0) closeWanted = true;
        }

        public override int RemainingTicks(Lift lift)
        {
            if (phase == 0) return (100 - lift.DoorOpen) / 5 + WaitTicks + 20;
            if (phase == 1) return (WaitTicks - waited) + 20;
            return lift.DoorOpen / 5;
        }

        public override int FinalFloor(Lift lift) { return lift.Floor; }
    }
}