namespace _04.Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpeedRacing
    {
        public static void Main()
        {
            var carsCount = int.Parse(Console.ReadLine());
            var carsList = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                var inputCarData = Console.ReadLine().Split();
                var model = inputCarData[0];
                var fuelAmount = double.Parse(inputCarData[1]);
                var fuelConsumptonFor1Km = double.Parse(inputCarData[2]);
                var car = new Car(model, fuelAmount, fuelConsumptonFor1Km, 0);
                carsList.Add(car);
            }

            var drivingData = Console.ReadLine().Split();
            while (drivingData[0] != "End")
            {
                var carModel = drivingData[1];
                var amountOfKm = int.Parse(drivingData[2]);
                var currentCar = carsList.FirstOrDefault(c => c.Model == carModel);

                if (currentCar.Model.Length > 0)
                {
                    var currentModelFuelConsPerKm = currentCar.FuelConsumptionFor1Km;
                    var fuelConsumed = currentCar.Drive(amountOfKm, currentModelFuelConsPerKm);
                    var currentModelFuel = currentCar.FuelAmount;

                    if (currentModelFuel >= fuelConsumed)
                    {
                        currentCar.FuelAmount -= fuelConsumed;
                        currentCar.DistanceTravelled += amountOfKm;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
                drivingData = Console.ReadLine().Split();
            }
            PrintCars(carsList);
        }

        public static void PrintCars(List<Car> carsList)
        {
            foreach (var c in carsList)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}