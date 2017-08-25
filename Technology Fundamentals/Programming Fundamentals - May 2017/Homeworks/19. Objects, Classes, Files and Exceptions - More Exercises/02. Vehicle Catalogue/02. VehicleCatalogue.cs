namespace _02.Vehicle_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VehicleCatalogue
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var trucks = new List<Truck>();
            var cars = new List<Car>();

            while (input != "End")
            {
                var splittedInput = input.Split();

                var typeOfVehicle = splittedInput[0];
                var model = splittedInput[1];
                var color = splittedInput[2];
                var horsePower = int.Parse(splittedInput[3]);

                if (typeOfVehicle.ToLower() == "car")
                {
                    var carsData = new Car(model, color, horsePower);
                    cars.Add(carsData);
                }

                else
                {
                    var trucksData = new Truck(model, color, horsePower);
                    trucks.Add(trucksData);
                }

                input = Console.ReadLine();
            }

            var modelInput = Console.ReadLine();

            while (modelInput != "Close the Catalogue")
            {
                PrintResult(cars, trucks, modelInput);
                modelInput = Console.ReadLine();
            }

            PrintAverageHorsePower(cars, trucks);
        }

        public static void PrintResult(List<Car> cars, List<Truck> trucks, string modelInput)
        {
            if (cars.Any(x => x.Model == modelInput))
            {
                foreach (var car in cars.Where(x => x.Model == modelInput))
                {
                    Console.WriteLine("Type: Car");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HorsePower}");
                }
            }

            else if (trucks.Any(x => x.Model == modelInput))
            {
                foreach (var truck in trucks.Where(x => x.Model == modelInput))
                {
                    Console.WriteLine("Type: Truck");
                    Console.WriteLine($"Model: {truck.Model}");
                    Console.WriteLine($"Color: {truck.Color}");
                    Console.WriteLine($"Horsepower: {truck.HorsePower}");
                }
            }
        }

        public static void PrintAverageHorsePower(List<Car> cars, List<Truck> trucks)
        {
            var carsAverageHP = (double)cars.Sum(c => c.HorsePower) > 0 ?
                (double)cars.Sum(c => c.HorsePower) / (double)cars.Count : 0.00;
            var trucksAverageHP = trucks.Sum(c => c.HorsePower) > 0 ?
                (double)trucks.Sum(c => c.HorsePower) / (double)trucks.Count : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHP:f2}.");
        }
    }
}