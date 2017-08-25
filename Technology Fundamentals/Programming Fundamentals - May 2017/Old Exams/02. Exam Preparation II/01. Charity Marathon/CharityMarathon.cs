namespace _01.Charity_Marathon
{
    using System;

   public class CharityMarathon
    {
        public static void Main()
        {
            var maratonDays = long.Parse(Console.ReadLine());
            var runners = long.Parse(Console.ReadLine());
            var averageLaps = long.Parse(Console.ReadLine());
            var lapLength = long.Parse(Console.ReadLine());
            var trackCapacity = long.Parse(Console.ReadLine());
            var moneyPerKilometer = double.Parse(Console.ReadLine());

            runners = trackCapacity * maratonDays > runners ? runners : trackCapacity * maratonDays;

            var totalMeters = runners * averageLaps * lapLength;    
            var totalKMs = totalMeters / 1000;
            var moneyRaised = totalKMs * moneyPerKilometer;

            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
    }
}