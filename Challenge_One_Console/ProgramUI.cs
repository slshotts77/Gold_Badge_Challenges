using Challenge_One_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Console
{
    class ProgramUI
    {
        private CafeRepository _mealInformationRepo = new CafeRepository();

        // Method that runs/starts the application
        public void Run()   // This is the Setup to do anything before the user see's it 
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options to the user. Note the plus sign here...as long as you are inside the string somewhere and hit enter before the closing quote mark you will add a new line concatenated to the next and output as one code.
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Meal\n" +
                    "2. View All Meals\n" +
                    "3. View Meals by Name\n" +
                    "4. Update Existing Meal Information\n" +
                    "5. Delete Existing Meal Information\n" +
                    "6. Exit");

                // Get user's imput
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        // Create new meal 
                        CreateNewItem();
                        break;
                    case "2":
                        // View all meals
                        DisplayAllItems();
                        break;
                    case "3":
                        // View meals by name
                        DisplayItemByName();
                        break;
                    case "4":
                        // Update existing item
                        UpdateExistingItem();
                        break;
                    case "5":
                        // Delete existing item
                        DeleteExistingItem();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:    // if a option other than 1 through 6 is entered you receive a "Default" response
                        Console.WriteLine("Please enter a number 1 through 6.");
                        break;
                }

                Console.WriteLine("Please press any key to exit.");
                Console.ReadKey();  // Before the screen clears the user will be prompted to "press any key"
                Console.Clear();    // Clears the screen
            }
        }
        // Create new Meal 
        private void CreateNewItem()
        {
            Console.Clear();
            MealItems newMeal = new MealItems();

            // MealName
            Console.WriteLine("Enter the name for meal");
            newMeal.Name = Console.ReadLine().ToLower();

            // Description
            Console.WriteLine("Enter the description for the meal");
            newMeal.Description = Console.ReadLine();

            // Ingredients 
            Console.WriteLine("Enter the ingredients for the meal");
            newMeal.Ingredients = Console.ReadLine();

            // MealNumber
            Console.WriteLine("Enter the meal number (1, 2, 3, etc):");
            string mealNumberAsString = Console.ReadLine();
            newMeal.MealNumber = double.Parse(mealNumberAsString); 

            // IsAllergyFriendly
            Console.WriteLine("Is this meal allergy friendly? (y/n)");
            string allergyFriendlyString = Console.ReadLine().ToLower();
            if (allergyFriendlyString == "y")
            {
                newMeal.IsAllergyFriendly = true;
            }
            else
            {
                newMeal.IsAllergyFriendly = false;
            }

            // ItemOnSide --> Keep the Index numbering the same. This is the enum information from Class "Challenge_One_Repository" Salad, Rolls, Fries, Coleslaw, MashedPotatoes, BakedPotatoes, Vegetables
            Console.WriteLine("Enter the side item number:\n" +
                "1. Salad\n" +
                "2. Rolls\n" +
                "3. Fries\n" +
                "4. Coleslaw\n" +
                "5. MashedPotatoes\n" +
                "6. BakedPotatoes\n" +
                "7. Vegetables");

            string itemOnSideAsString = Console.ReadLine();
            int itemOnSideAsInt = int.Parse(itemOnSideAsString);
            newMeal.ItemOnSide = (SideItem)itemOnSideAsInt;    

            _mealInformationRepo.AddMealItems(newMeal);

        }

        // View Current MealItems that is saved
        private void DisplayAllItems()
        {
            Console.Clear();

            List<MealItems> listOfMeals = _mealInformationRepo.GetMeals();
            
            foreach (MealItems item in listOfMeals)
            {
                Console.WriteLine($"(Name): {item.Name} /" + $" (Description): {item.Description} /" +  $" " +
                    $"(Ingredients): {item.Ingredients}");   // $ is String Interpolation 
            }
        }

        // View Item by NewName
        private void DisplayItemByName()
        {
            Console.Clear();
            // Prompt the user to give me a NewName
            Console.WriteLine("Enter the name of the meal you would like to see");

            // Get the user's input
            string name = Console.ReadLine();

            // Find the item by that name
            MealItems item = _mealInformationRepo.GetItemByName(name);
                
            // Display said item if it isn't null
            if (item != null)
            {
                Console.WriteLine($"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"MealNumber: { item.MealNumber}\n" +
                    $"Is Allergy Friendly: {item.IsAllergyFriendly}\n" +
                    $"SideItem: {item.ItemOnSide}");
            }
            else
            {
                Console.WriteLine("No item by that name.");
            }
        }

        // Update Existing Item
        private void UpdateExistingItem()
        {
            // Display all items
            DisplayAllItems();

            // Ask for the name of item to update
            Console.WriteLine("Enter the name of the item you would like to update");

            // Get that name
            string oldName = Console.ReadLine();

            // We will build a new object 
            Console.Clear();
            MealItems newItem = new MealItems();

            // Name
            Console.WriteLine("Enter the name for the item");
            newItem.Name = Console.ReadLine().ToLower();

            // Description
            Console.WriteLine("Enter the description for the name");
            newItem.Description = Console.ReadLine();

            // Ingredients
            Console.WriteLine("Enter the ingredients for the description");
            newItem.Ingredients = Console.ReadLine();

            // CustomerRating 
            Console.WriteLine("Enter the menu number for the item (1, 2, 3 etc):");
            string mealNumberAsString = Console.ReadLine();
            newItem.MealNumber = double.Parse(mealNumberAsString);    

            // IsAllergyFriendly
            Console.WriteLine("Is this item allergy friendly? (y/n)");
            string allergyFriendlyString = Console.ReadLine().ToLower();
            if (allergyFriendlyString == "y")
            {
                newItem.IsAllergyFriendly = true;
            }
            else
            {
                newItem.IsAllergyFriendly = false;
            }

            // ItemOnSide --> Keep the Index numbering the same. This is the enum information from Class "Challenge_One_Repository" Salad, Rolls, Fries, Coleslaw, MashPotatoes, BakePotatoes, Vegetables
            Console.WriteLine("Enter the side item number:\n" +
                "1. Salad\n" +
                "2. Rolls\n" +
                "3. Fries\n" +
                "4. ColeSlaw\n" +
                "5. MashedPotatoes\n" +
                "6. BakedPotatoes\n" +
                "7. Vegetables");

            string itemOnSideAsString = Console.ReadLine();
            int itemOnSideAsInt = int.Parse(itemOnSideAsString);
            newItem.ItemOnSide = (SideItem)itemOnSideAsInt;     // This is called "Casting" 

            // Verify the update worked
            bool wasUpdated = _mealInformationRepo.UpdateExistingItem  (oldName, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Item successfully update!");
            }
            else
            {
                Console.WriteLine("Could not update item.");
            }
        }

        // Delete Existing Item
        private void DeleteExistingItem()
        {
            DisplayAllItems();

            // Get the title they want to remove
            Console.WriteLine("\nEnter the title of the item you would like to remove");

            string input = Console.ReadLine();

            // Call the delete method
            bool wasDeleted = _mealInformationRepo.RemoveItemFromList(input);

            // Otherwise state it could be deleted
            // If the item was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The item could not be deleted.");
            }
        }

        // See method
        private void SeedContentList()
        {
            MealItems pizza = new MealItems("Meal number 1", "Pizza", "Beer battered crust, sauce, onion and bacon", 4, false, SideItem.Salad);
            MealItems oneTheBorder = new MealItems("Meal Number 2","On The Border", "All taco here, meat, lettuce, tomato, sour cream and cheese.", 3, false, SideItem.Vegetables);
            MealItems oneForTheRoad = new MealItems("Meal number 3", "One For The Road", "Hotdog, onion, chili and mustard", 5, false, SideItem.Fries);

            _mealInformationRepo.AddMealItems(pizza);
            _mealInformationRepo.AddMealItems(oneTheBorder);
            _mealInformationRepo.AddMealItems(oneForTheRoad);
        }
    }
}