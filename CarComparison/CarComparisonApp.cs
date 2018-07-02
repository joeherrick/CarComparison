using System;
using System.Collections.Generic;

namespace CarComparisonApp
{
    class CarComparisonApp
    {
        static void Main(string[] args)
        {
            var carCollection = LoadSampleCars();
            string command = string.Empty;
            decimal fuelDistance = 0;
            DisplayCars(carCollection.AllCars, fuelDistance);
            DisplayMenu();

            while (!command.ToUpper().Equals("X"))
            {
                command = Console.ReadLine();

                switch (command.ToUpper())
                {
                    case "1":
                        DisplayCars(carCollection.AllCarsByYear, fuelDistance);
                        break;
                    case "2":
                        DisplayCars(carCollection.AllCarsByMakeAndModel, fuelDistance);
                        break;
                    case "3":
                        DisplayCars(carCollection.AllCarsByPrice, fuelDistance);
                        break;
                    case "4":
                        DisplayCars(carCollection.AllCarsByValue, fuelDistance);
                        break;
                    case "5":
                        fuelDistance = GetFuelDistance();
                        DisplayCars(carCollection.AllCars, fuelDistance);
                        break;
                    case "6":
                        var randomCar = carCollection.RandomCar;
                        Console.WriteLine($"Selected: {randomCar.Year} {randomCar.Make} {randomCar.Model}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        DisplayCars(carCollection.AllCars, fuelDistance);
                        break;
                    case "7":
                        var averageMPGByYear = carCollection.AverageMPGByYear;
                        foreach (var item in averageMPGByYear)
                        {
                            Console.WriteLine($"Year: {item.Key}  AverageMPG: {item.Value:0.##}");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        DisplayCars(carCollection.AllCars, fuelDistance);
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                }

                DisplayMenu();
            }
        }

        private static decimal GetFuelDistance()
        {
            decimal distance = 0;
            Console.Write("Enter Distance (must be a positive value): ");
            var input = Console.ReadLine();
            var valid = decimal.TryParse(input, out distance);
            if (!valid)
            {
                Console.WriteLine("Invalid value");
                Console.ReadLine();
            }
            return distance;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1 - Sort by Year");
            Console.WriteLine("2 - Sort by Make/Model");
            Console.WriteLine("3 - Sort by Price");
            Console.WriteLine("4 - Sort by Value");
            Console.WriteLine("5 - Show Fuel Consumption for a given distance");
            Console.WriteLine("6 - Select a Random Car");
            Console.WriteLine("7 - Show Average MPG by Year");
            Console.WriteLine("X - Exit");
            Console.WriteLine();
            Console.WriteLine("Enter command:");
        }

        private static void DisplayCars( IEnumerable<CarDetails> _cars, decimal fuelDistance)
        {
            Console.Clear();

            Console.Write($"{"Make",-20}{"Model",-20}{"Color",-10}{"Year",-10}{"Price",-15}{"TCC Rating",-12}{"Hwy MPG",-10}");
            if (fuelDistance != 0)
            {
                Console.Write($"{ $"Fuel for {fuelDistance} miles",-10}");
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (CarDetails car in _cars)
            {
                Console.Write($"{car.Make,-20}{car.Model,-20}{car.Color,-10}{car.Year,-10}{car.PriceFormatted,-15}{car.TCCRating,-12}{car.HwyMPG,-10}");
                if (fuelDistance != 0)
                {
                    Console.Write($"{(car.FuelByDistance(fuelDistance)):0.##}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static CarCollection LoadSampleCars()
        {
            var stringdata = System.IO.File.ReadAllText("SampleCarData.json");
            var detailsData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CarDetails>>(stringdata);
            return new CarCollection(detailsData);
        }
    }
}
