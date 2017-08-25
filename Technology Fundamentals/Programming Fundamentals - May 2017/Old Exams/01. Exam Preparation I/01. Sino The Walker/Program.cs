namespace _01.Sino_The_Walker
{
    using System;

   public class SinoTheWalker
    {
        public static void Main()
        {

            var timeAsString = Console.ReadLine();
            var stepsTaken = int.Parse(Console.ReadLine()) % 86400;
            var timeEachStep = int.Parse(Console.ReadLine()) % 86400;

            var time = DateTime.Parse(timeAsString);
            var secondsToAdd = (stepsTaken * timeEachStep) % 86400;
            var timeArrival = time.AddSeconds(secondsToAdd).ToString("HH:mm:ss");

            Console.WriteLine($"Time Arrival: {timeArrival}");
        }
    }
}