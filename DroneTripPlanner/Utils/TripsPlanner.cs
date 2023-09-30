using DroneTripsPlanner.Model;
using System.Collections.Generic;
using System.Linq;

namespace DroneTripsPlanner.Utils
{
    public class TripsPlanner
    {
        private List<DropPoint> dropPoints { get; set; }
        private List<Drone> drones = new List<Drone>();

        public TripsPlanner(List<Drone> drones, List<DropPoint> dropPoints)
        {
            Initialize(drones);
            this.dropPoints = dropPoints;
        }

        private void Initialize(List<Drone> drones)
        {
            foreach (var drone in drones.OrderByDescending(t => t.Weight).ToList())
            {
                var trip = new Trip() { DropPoints = new List<DropPoint>() };
                drone.Trips.Add(trip);
                this.drones.Add(drone);
            }
        }

        public List<Drone> Plan()
        {

            while (dropPoints.ToList().Any())
            {

                foreach (var drone in drones.ToList())
                {
                    if (drone.Trips.Where(t => t.WeightLoaded <= drone.Weight).Any())
                    {
                        var trip = new Trip() { DropPoints = new List<DropPoint>() };
                        drone.Trips.Add(trip);
                    }

                    foreach (var drop in dropPoints.ToList())
                    {
                        var trip = drone.Trips.Where(t => t.WeightLoaded <= t.DropPoints.Sum(t => t.Weight) && (t.WeightLoaded + drop.Weight) <= drone.Weight).FirstOrDefault();
                        if (trip != null)
                        {
                            trip.DropPoints.Add(drop);
                            dropPoints.Remove(drop);
                        }
                    }

                }

            }

            return drones.ToList();

        }
    }
}
