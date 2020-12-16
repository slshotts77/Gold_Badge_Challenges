using System.Collections.Generic;

namespace Challenge_Six_Repository
{
    public class GreenPlanLibrary
    {
        private List<CarInfo> _listOfCars = new List<CarInfo>();

        //Create
        public void AddCar(CarInfo newCar)
        {
            _listOfCars.Add(newCar);
        }

        // Read - All Cars
        public List<CarInfo> GetListOfAllCars()
        {
            return _listOfCars;
        }

        // Update
        public bool UpdateExistingCarInfo(string originalCarName, CarInfo newCar)
        {
            // Find the car infromation
            CarInfo oldCar = GetInfoByCarType(originalCarName);


            // Update the car infromation
            if (oldCar != null)
            {
                oldCar.CarType = newCar.CarType;
                oldCar.CarManufacture = newCar.CarManufacture;
                oldCar.CarName = newCar.CarName;
                oldCar.CarYear = newCar.CarYear;
                oldCar.CarDescription = newCar.CarDescription;
                oldCar.IsGreenPlan = newCar.IsGreenPlan;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveCarFromList(string CarName)
        {
            CarInfo Name = GetInfoByCarType(CarName);

            if (Name == null)
            {
                return false;
            }

            int carCount = _listOfCars.Count;
            _listOfCars.Remove(Name);

            if (carCount > _listOfCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public CarInfo GetInfoByCarType(string carType)
        {
            foreach (CarInfo name in _listOfCars)
            {

                if (carType.ToLower() == "electric")
                {
                    name.CarType = TypeOfCar.Electric;
                    return name;
                }
                else if (carType.ToLower() == "hybrid")
                {
                    name.CarType = TypeOfCar.Hybrid;
                    return name;
                }
                else if (carType.ToLower() == "gas")
                {
                    name.CarType = TypeOfCar.Gas;
                    return name;
                }
            }
            return null;
        }
    }
}
