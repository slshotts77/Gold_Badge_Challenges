using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repository
{
    public class CafeRepository
    {
        private List<MealItems> _listOfItems = new List<MealItems>();     // Newup POCO and create a list


        // Create
        public void AddMealItems(MealItems item)
        {
            _listOfItems.Add(item);
        }

        // Read
        public List<MealItems> GetMeals()
        {
            return _listOfItems;
        }

        // Update
        public bool UpdateExistingItem(string originalName, MealItems newInformation)
        {
            // Find the meal infromation
            MealItems oldInformation = GetItemByName(originalName);

            // Update the meal infromation
            if (oldInformation != null)
            {
                oldInformation.Name = newInformation.Name;
                oldInformation.Description = newInformation.Description;
                oldInformation.Ingredients = newInformation.Ingredients;
                oldInformation.MealNumber = newInformation.MealNumber;
                oldInformation.IsAllergyFriendly = newInformation.IsAllergyFriendly;
                oldInformation.ItemOnSide = newInformation.ItemOnSide;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveItemFromList(string Name)
        {
            MealItems Item = GetItemByName(Name);

            if (Item == null)
            {
                return false;
            }

            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(Item);

            if (initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public MealItems GetItemByName(string Name)
        {
            foreach (MealItems item in _listOfItems)
            {
                if (item.Name.ToLower() == Name.ToLower())
                {
                    return item;
                }
            }
            

            return null;
        }
    }
}

