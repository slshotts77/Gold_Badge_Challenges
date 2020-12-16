using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Six_Repository
{
    public enum TypeOfCar
    {
        Electric = 1,
        Hybrid,
        Gas
    }

    public class CarInfo
    {
        public TypeOfCar CarType { get; set; }
        public string CarManufacture { get; set; }
        public string CarName { get; set; }
        public int CarYear { get; set; }
        public string CarDescription { get; set; }
        public bool IsGreenPlan { get; set; }   // This will give the company a way to mark the car as GreenPlan later on and build query on that information.

        public CarInfo() { }

        public CarInfo(TypeOfCar carType, string carManufacture, string carName, int carYear, string carDescription, bool isGreenPlan)
        {
            CarType = carType;
            CarManufacture = carManufacture;
            CarName = carName;
            CarYear = carYear;
            CarDescription = carDescription;
            IsGreenPlan = isGreenPlan;
        }

    }
}
