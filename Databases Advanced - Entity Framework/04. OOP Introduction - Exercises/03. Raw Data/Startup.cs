namespace _03.Raw_Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                var carInfo = Console.ReadLine().Split();
                var carModel = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var tireArr = GetAllTires(carInfo);
                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(carModel, engine, cargo, tireArr);
                cars.Add(car);
            }

            var cargoTypeNeeded = Console.ReadLine();
            if (cargoTypeNeeded == "fragile")
            {
                PrintCarsWithFragileTypeCargo(cars);
            }
            else
            {
                PrintCarsWithFlammableTypeCargo(cars);
            }
        }

        public static void PrintCarsWithFlammableTypeCargo(List<Car> cars)
        {
            var carsToPrint = cars
                .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                .ToList();
            foreach (var c in carsToPrint)
            {
                Console.WriteLine(c.Model);
            }
        }

        public static void PrintCarsWithFragileTypeCargo(List<Car> cars)
        {
            var carsToPrint = cars
                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                .ToList();
            foreach (var c in carsToPrint)
            {
                Console.WriteLine(c.Model);
            }
        }

        public static Tire[] GetAllTires(string[] tireArgs)
        {
            var index = 5;
            var tireArr = new Tire[4];
            for (int i = 0; i < 4; i++)
            {
                var currentTirePressure = double.Parse(tireArgs[index]);
                var currentTireAge = int.Parse(tireArgs[index + 1]);
                var currentTire = new Tire(currentTirePressure, currentTireAge);
                tireArr[i] = currentTire;
                index += 2;
            }

            return tireArr;
        }
    }
}