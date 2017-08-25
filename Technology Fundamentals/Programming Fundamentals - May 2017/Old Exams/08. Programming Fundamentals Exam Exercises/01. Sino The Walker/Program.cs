namespace _9.Legendary_Farming
{
    using System;
    using System.Globalization;

    public class Program
    {
        public static void Main()
        {
            var inputTime = Console.ReadLine();

            var stepsTaken = int.Parse(Console.ReadLine()) % 86400;
            var eachStepTime = int.Parse(Console.ReadLine()) % 86400;

            var walkMinutes = stepsTaken * eachStepTime;

            var time = DateTime.ParseExact(inputTime, "HH:mm:ss", CultureInfo.CurrentCulture);
            time = time.AddSeconds(walkMinutes);

            Console.WriteLine("Time Arrival: {0:HH:mm:ss}", time);
        }
    }
}