using System;
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
            CarInfo contentFromDirectory = library.GetInfoByCarType("Model S");

            // Assert
            Assert.IsNotNull(contentFromDirectory);
        }

        [TestMethod]
        public void UpdateCarInfo_ShouldReturnTrue()
        {
            // Arrange
            CarInfo newInformation = _carInfo;

            // Act
            bool updateResult = _greenPlanLibary.UpdateExistingCarInfo("Model S", newInformation);

            // Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Model S", true)]
        [DataRow("Pinto", false)]
        public void UpdateCarInfo_ShouldMatchGivenBool(string originalCarName, bool shouldUpdate)
        {

            // Arrange
            CarInfo newCarInfo = _carInfo;

            // Act
            bool updateResult = _greenPlanLibary.UpdateExistingCarInfo(originalCarName, newCarInfo);

            // Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            // Arrange --> THhere is none

            // Act
            bool deleteResult = _greenPlanLibary.RemoveCarFromList(_carInfo.CarName);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}