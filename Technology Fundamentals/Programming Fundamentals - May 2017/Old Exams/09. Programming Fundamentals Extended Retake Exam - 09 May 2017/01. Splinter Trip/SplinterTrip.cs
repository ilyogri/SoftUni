namespace _01.Splinter_Trip
{
    using System;

   public class SplinterTrip
    {
        public static void Main()
        {
            var travelDistance = double.Parse(Console.ReadLine());
            var fuelTankCapacity = double.Parse(Console.ReadLine());
            var milesInHeavyWinds = double.Parse(Console.ReadLine());

            var milesInNonHeavyWinds = travelDistance - milesInHeavyWinds;
            var nonHeavyWindsConsumption = milesInNonHeavyWinds * 25;
            var heavyWindsConsumption = milesInHeavyWinds * (25 * 1.5);
            var fuelConsumption = nonHeavyWindsConsumption + heavyWindsConsumption;
            var tolerance = fuelConsumption * 0.05;
            var totalFuelConsumption = fuelConsumption + tolerance;
            var remainingFuel = fuelTankCapacity - totalFuelConsumption;

            Console.WriteLine($"Fuel needed: {totalFuelConsumption:f2}L");

            if(remainingFuel >= 0)
            {
                Console.WriteLine($"Enough with {remainingFuel:f2}L to spare!");
            }

            else
            {
                Console.WriteLine($"We need {Math.Abs(remainingFuel):f2}L more fuel.");
            }
        }
    }
}