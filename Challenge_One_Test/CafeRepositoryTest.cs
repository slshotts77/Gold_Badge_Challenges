using Challenge_One_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Test
{
    [TestClass]
    public class CafeRepositoryTest
    {
        // Declaring  
        private CafeRepository _repo;   // MealRepository is now an object and its name is _repo
        private MealItems _content;  // Meal is now an objst and its name is _mealInformation

        // Assign Value
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepository();
            _content = new MealItems("Minute to Midnight", "Sound the alarms, this meal packs a punch and explodes with flavort.", "Burger, jalapenos, cheese, pickle, ketchup and mustard", 4.7, true, SideItem.MashedPotatoes);

            _repo.AddMealItems(_content);
        }

        // Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            MealItems item = new MealItems();  // When referencing one “Class / Namespace” to another since this has already been referenced hit “ctrl .” on the Class reference name and select the recommended “using statement”.
            item.Name = "All You Can Eat";
            CafeRepository repository = new CafeRepository();

            // Act --> GET/Run the code we want to test
            repository.AddMealItems(item);
            MealItems contentFromDirectory = repository.GetItemByName("All You Can Eat");

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(contentFromDirectory);
        }

        // Update
        [TestMethod]
        public void UpdateExistingItem_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize
            MealItems newInformation = new MealItems("Late Night", "This burger that stacks up against the best,BBQ seasoning some is blended into the patties themselves for smoky-sweet flavor, while the rest seasons a side of tender oven fries.", "smothered in melted pepper jack cheese AND sautéed peppers and onions.", 01, true, SideItem.MashedPotatoes);

            // Act
            bool updateResult = _repo.UpdateExistingItem("Minute to Midnight", newInformation);

            // Assert
            Assert.IsTrue(updateResult);
        }


        [DataTestMethod]
        [DataRow("Minute to Midnight", true)] // Attribute or TestCase
        [DataRow("Pizza Burge", false)] // Attribute
        public void UpdateExistingItem_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            // Arrange
            // TestInitialize
            MealItems newItem = new MealItems("Minute to Midnight", "A car comes to life with the power to make people explode and goes on a murderous rampage through the California desert.", "R", 10, false, SideItem.MashedPotatoes);

            // Act
            bool updateResult = _repo.UpdateExistingItem(originalName, newItem);

            // Assert 
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize


            // Act
            bool deleteResult = _repo.RemoveItemFromList(_content.Name);

            // Assert 
            Assert.IsTrue(deleteResult);
        }
    }
}

