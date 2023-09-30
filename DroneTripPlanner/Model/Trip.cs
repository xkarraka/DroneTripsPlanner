using System.Collections.Generic;
using System.Linq;

namespace DroneTripsPlanner.Model
{
    public class Trip
    {
        private List<DropPoint> dropPoints { get; set; }
        public List<DropPoint> DropPoints
        {
            get
            {
                if (dropPoints == null) dropPoints = new List<DropPoint>(); return dropPoints;
            }
            set { dropPoints = value; }
        }
        public int WeightLoaded => DropPoints.Sum(t => t.Weight);
    }
}
