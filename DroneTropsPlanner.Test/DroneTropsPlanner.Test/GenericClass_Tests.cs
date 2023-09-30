
using DroneTripsPlanner.Generics;
using DroneTripsPlanner.Model;

namespace DroneTropsPlanner.Test
{
    public class GenericClass_Tests
    {
        GenericList<GenericModel> genericList = new GenericList<GenericModel>();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GenericList_Avoid_Duplicated()
        {
            genericList.List.Clear();

            genericList.AddItem("ItemName", "100");

            Assert.Throws<Exception>(() => genericList.AddItem("ItemName", "100"));
        }


        [Test]
        public void GenericList_As_Drone_More_Than_100_Records()
        {
            GenericList<Drone> genericListAsDrone = new GenericList<Drone>();
            Add100RandomRecords(ref genericListAsDrone);

            Assert.Throws<Exception>(() => genericListAsDrone.AddItem("ItemName", "100"));
        }

        [Test]
        public void GenericList_Throws_When_Weight_Invalid_Value()
        {
            genericList.List.Clear();

            Assert.Throws<Exception>(() => genericList.AddItem("ItemName", "Weight"));
        }

        private void Add100RandomRecords(ref GenericList<Drone> genericList)
        {
            genericList.List.Clear();
            int count = 0;
            while (count < 100)
            {
                genericList.AddItem($"ItemName{count}", "100");
                count++;
            }
        }
    }
}