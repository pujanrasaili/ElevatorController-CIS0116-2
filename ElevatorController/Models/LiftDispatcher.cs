using System.Collections.Generic;

namespace ElevatorController
{
    // Decides which lift answers a call button pressed OUTSIDE the lifts.
    public class LiftDispatcher
    {
        private List<Lift> lifts = new List<Lift>();

        public LiftDispatcher(params Lift[] allLifts)
        {
            lifts.AddRange(allLifts);
        }

        // returns the lift chosen, or null if none can help
        public Lift AssignHallCall(int floor)
        {
            Lift best = null;
            int bestTime = Lift.NotAvailable;

            foreach (Lift lift in lifts)
            {
                int time = lift.EstimateTime(floor);
                if (time < bestTime)               // shortest estimated response time wins
                {
                    bestTime = time;
                    best = lift;
                }
            }

            if (best != null)
            {
                best.HallRequest(floor);
            }
            return best;
        }
    }
}