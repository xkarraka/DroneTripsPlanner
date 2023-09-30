using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTripsPlanner.Generics
{
    public class GenericModel
    {

        public string Name { get; set; }
        public int Weight { get; set; }

        public GenericModel()
        {

        }

        public GenericModel(GenericModel model)
        {
            this.Weight = model.Weight;
            this.Name = model.Name;

        }
    }
}
