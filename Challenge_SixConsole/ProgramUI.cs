using Challenge_Six_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Six_Console
{
    class ProgramUI
    {
        private GreenPlanLibrary _carInfoLibrary = new GreenPlanLibrary();

        // Method that runs/starts the application
        public void Run()   // This is the Setup to do anything before the user see's it 
        {
            SeedCarList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Cars\n" +
                    "2. Add New Car\n" +
                    "3. View Car by Type (Electric, Hybrid or Gas)\n" +
                    "4. View Cars with GreenPlan\n" +
                    "5. Update Existing Car Information\n" +
                    "6. Delete Existing Car from list\n" +
                    "7. Exit");

                // Get users input
                string input = Console.ReadLine();

                //Elvaluate
                switch (input)
                {
                    case "1":
                        ViewAllCars();
                        break;
                    case "2":
                        AddNewCar();
                        break;
                    case "3":
                        ViewCarByType();
                        break;
                    case "4":
                        CarWithGreenPlan();  // View all GreenPlan cars --> this can be used in the future to query vehicles on a GreenPlan
                        break;
                    case "5":
                        UpdateExistingCarInfo();  // Update existing car
                        break;
                    case "6":
                        DeleteExistingCarInfo();  // Delete existing car
                        break;
                    case "7":
                        Console.WriteLine("Have a good day!");
                        keepRunning = false;
                        break;
                    default:    // if a option other than 1 through 7 is entered you receive a "Default" response
                        Console.WriteLine("Please enter a valid number 1 through 7.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // View all cars
        private void ViewAllCars()
        {
            Console.Clear();

            List<CarInfo> listOfAllCars = _carInfoLibrary.GetListOfAllCars();

            foreach (CarInfo value in listOfAllCars)
            {
                Console.WriteLine($"CarType: {value.CarType}\n" +
                    $"CarManufacture: {value.CarManufacture}\n" +
                    $"CarName: {value.CarName}\n" +
                    $"CarYear: {value.CarYear}\n" +
                    $"CarDescription: {value.CarDescription}\n" +
                    $"(IsGreenPlan): {value.IsGreenPlan}");
            }
        }

        // Add a new car
        private void AddNewCar()
        {
            Console.Clear();
            CarInfo newCar = new CarInfo();

            // TypeOfCar --> Keep the Index numbering the same. This is the Enum information from GreenPlan in "Challenge_Two_Library" Select Electric, Hybrid or gas
            Console.WriteLine("Enter the type of car by number below:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");

            string carTypeAsString = Console.ReadLine();
            int carTypeAsInt = int.Parse(carTypeAsString);
            newCar.CarType = (TypeOfCar)carTypeAsInt;

            _carInfoLibrary.AddCar(newCar);

            // CarManufacture
            Console.WriteLine("Enter Car manufacture");
            newCar.CarManufacture = Console.ReadLine().ToLower();

            // CarName
            Console.WriteLine("Enter the name of car");
            newCar.CarName = Console.ReadLine();

            // CarYear 
            Console.WriteLine("Enter year of the car (2001, 2010, 2020 etc):");
            newCar.CarYear = Convert.ToInt32(Console.ReadLine());

            // CarDescription
            Console.WriteLine("Enter the car specs");
            newCar.CarDescription = Console.ReadLine();

            // IsGreenPlan
            Console.WriteLine("Is this vechilce inlisted in the Green Plan? (y/n)");
            string isGreenPlan = Console.ReadLine().ToLower();
            if (isGreenPlan == "y")
            {
                newCar.IsGreenPlan = true;
            }
            else
            {
                newCar.IsGreenPlan = false;
            }
        }

        // View car by type
        private void ViewCarByType()
        {
            Console.Clear();
            // Prompt the user for type of car
            Console.WriteLine("Enter the type of car you would like to list (Electric, Hybrid or Gas):");

            // Get the user's input
            string carType = Console.ReadLine();

            // Find the content by that car type

            CarInfo content = _carInfoLibrary.GetInfoByCarType(carType);

            // Display said content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"CarType: {content.CarType}\n" +
                    $"CarManufacture: {content.CarManufacture}\n" +
                    $"CarName: {content.CarName}\n" +
                    $"CarYear: { content.CarYear}\n" +
                    $"CarDescription: {content.CarDescription}\n" +
                    $"IsGreenPlan: {content.IsGreenPlan}");
            }
            else
            {
                Console.WriteLine("No car by that type exist.");
            }
        }


        // View vehicles with Green Plan
        private void CarWithGreenPlan()
        {
            Console.Clear();

            List<CarInfo> listOfAllCars = _carInfoLibrary.GetListOfAllCars();

            foreach (CarInfo value in listOfAllCars)
            {
                Console.WriteLine($"CarType: {value.CarType}\n" +
                  $"CarManufacture: {value.CarManufacture}\n" +
                  $"CarName: {value.CarName}\n" +
                  $"CarYear: {value.CarYear}\n" +
                  $"CarDescription: {value.CarDescription}\n" +
                  $"IsGreenPlan: {true}");

            }
        }

        // Update Existing Information
        private void UpdateExistingCarInfo()
        {
            ViewAllCars();

            Console.WriteLine("Enter the car name for the infromation you would like to update");

            string oldInfo = Console.ReadLine();

            // We will build a new object
            Console.Clear();
            CarInfo newCar = new CarInfo();

            // TypeOfCar  --> Keep the Index numbering the same. This is the enum information from Class "Challenge_Two_Library" Electric, Hybrid or Gas
            Console.WriteLine("Enter the type of car by number 1 through 3:\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");

            string carTypeAsString = Console.ReadLine();
            int carTypeAsInt = int.Parse(carTypeAsString);
            newCar.CarType = (TypeOfCar)carTypeAsInt;

            _carInfoLibrary.AddCar(newCar);

            // CarManufacture
            Console.WriteLine("Enter the manufacture of the car");
            newCar.CarManufacture = Console.ReadLine().ToLower();

            // CarName
            Console.WriteLine("Enter the name of the car");
            newCar.CarName = Console.ReadLine();

            // CarYear
            Console.WriteLine("Enter the year of the car (example 2001, 2010 or 2020):");
            newCar.CarYear = Convert.ToInt32(Console.ReadLine());

            // CarDescription
            Console.WriteLine("Enter the specs for the car");
            newCar.CarDescription = Console.ReadLine();

            // IsGreenPlan
            Console.WriteLine("Is this car on the \"Green Plan\"? (y/n)");
            string greenPlanString = Console.ReadLine().ToLower();
            if (greenPlanString == "y")
            {
                newCar.IsGreenPlan = true;
            }
            else
            {
                newCar.IsGreenPlan = false;
            }

            // Verify the update worked
            bool wasUpdated = _carInfoLibrary.UpdateExistingCarInfo(oldInfo, newCar);

            if (wasUpdated)
            {
                Console.WriteLine("Information was successfully update!");
            }
            else
            {
                Console.WriteLine("unfortunately, the information did not updated.");
            }
        }

        // Delete Existing Information
        private void DeleteExistingCarInfo()
        {
            ViewAllCars();

            // Get the name of the info to be removed
            Console.WriteLine("\nEnter the car name for the vehicle record you like to remove");

            string input = Console.ReadLine();

            // Call the delete method
            bool wasDeleted = _carInfoLibrary.RemoveCarFromList(input);

            // Otherwise state it could be deleted
            // If the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The information was successfully deleted!");
            }
            else
            {
                Console.WriteLine("unfortunately, the information did not deleted.");
            }
        }

        // Seed Method
        private void SeedCarList()
        {
            CarInfo modelS = new CarInfo(TypeOfCar.Electric, "Tesla", "Model S", 2021, "Long Range Battery, Acceleration from 0-60 in 2.3 seconds, Range of 387 miles, All-Wheel Drive, Seats 5 and Wheels in either 19\" or 21\"", true);
            CarInfo eX = new CarInfo(TypeOfCar.Electric, "Honda", "EX", 2020, "High fuel economy, quick acceleration, 2-Wheel Drive, Seats 5 and Wheels come on 15\" or 16\"", true);
            CarInfo _370Z = new CarInfo(TypeOfCar.Gas, "Nissian", "370Z", 2019, "20 MPG, Acceleration from 0-60 in 4.7 seconds, Range of 267 miles, 2-Wheel Drive, Seats 2 and Wheels in either 18\" x8.0 or 18\" x9.0", false);

            _carInfoLibrary.AddCar(modelS);
            _carInfoLibrary.AddCar(eX);
            _carInfoLibrary.AddCar(_370Z);
        }
    }
}