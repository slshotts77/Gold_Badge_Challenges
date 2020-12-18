using System;
using System.Collections.Generic;
using Challenge_Six_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_Six_Test
{
    [TestClass]
    public class GPRepositoryTest
    {
        // Declaring
        private GreenPlanLibrary _greenPlanLibary;
        private CarInfo _carInfo;

        // Assign Value
        [TestInitialize]
        public void Arrange()
        {
            _greenPlanLibary = new GreenPlanLibrary();
            _carInfo = new CarInfo(TypeOfCar.Electric, "Tesla", "Model S", 2020, "Long Range Battery, Acceleration from 0-60 in 2.3 seconds, Range of 387 miles, All-Wheel Drive, Seats 5 and Wheels in either 19\" or 21\"", false);

            _greenPlanLibary.AddCar(_carInfo);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange
            CarInfo item = new CarInfo();
            item.CarName = "Model S";
            GreenPlanLibrary library = new GreenPlanLibrary();

            // Act
            library.AddCar(item);
            List<CarInfo> list = library.GetListOfAllCars();

            // Assert
            Assert.IsTrue(list.Contains(item));
        }

        [TestMethod]
        public void UpdateCarInfo_ShouldReturnTrue()
        {
            // Arrange
            CarInfo newInformation = _carInfo;
            newInformation.CarName = "Model X";

            // Act
            bool updateResult = _greenPlanLibary.UpdateExistingCarInfo("Model S", newInformation);

            // Assert
            Assert.IsTrue(_carInfo.CarName == newInformation.CarName);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            // Arrange --> There is none

            // Act
            bool deleteResult = _greenPlanLibary.RemoveCarFromList(_carInfo.CarName);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}