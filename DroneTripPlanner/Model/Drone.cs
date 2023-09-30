using DroneTripsPlanner.Generics;
using System.Collections.Generic;

namespace DroneTripsPlanner.Model
{
    public class Drone : GenericModel
    {
        public Drone(GenericModel model) : base(model)
        {
        }

        private List<Trip> trips { get; set; }

        public List<Trip> Trips
        {
            get
            {
                if (trips == null) trips = new List<Trip>(); return trips;
            }
            set => trips = value;
        }
    }
}
