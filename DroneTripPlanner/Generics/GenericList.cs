using DroneTripsPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DroneTripsPlanner.Generics
{
    public class GenericList<T>
        where T : GenericModel
    {
        private List<GenericModel> list = new List<GenericModel>();

        public List<GenericModel> List { get => list; }

        public void AddItem(string name, string weight)
        {
            if (type == typeof(Drone) && list.Count == 100)
                throw new Exception("Unable to register a new Drone, Limit of 100 drones reached.");

            int weightParsed;
            var parsed = int.TryParse(weight, out weightParsed);

            if (!parsed)
                throw new Exception("Error: Unable to parse the Weight Value into a Integer Value");

            if (list.Any(t => t.Name == name))
                throw new Exception($"Error: There's and existing {type.Name} with name '{name}'");

            var model = new GenericModel() { Name = name, Weight = weightParsed };

            list.Add(model);
        }

        private Type type = typeof(T);
    }
}
