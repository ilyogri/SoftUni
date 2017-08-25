namespace Problem_6.Heists
{
    using System;
    using System.Linq;

   public class Heists
    {
        public static void Main()
        {
            var prices = Console.ReadLine().Split(' ');

            var jewelsPrice = int.Parse(prices[0]);
            var goldPrice = int.Parse(prices[1]);
            var expenses = 0;
            var goldCount = 0;
            var jewelCount = 0;
            var earnings = 0;

            var command = Console.ReadLine().Split(' ');

            while (command[0] != "Jail")
            {
                goldCount = command[0].Count(x => x == '$');
                jewelCount = command[0].Count(x => x == '%');

                earnings += (goldCount * goldPrice) + (jewelCount * jewelsPrice);
                expenses += int.Parse(command[1]);

                command = Console.ReadLine().Split(' ');
            }

            var result = earnings >= expenses ?
                $"Heists will continue. Total earnings: {earnings - expenses}." : $"Have to find another job. Lost: {expenses - earnings}.";

            Console.WriteLine(result);
        }
    }
}