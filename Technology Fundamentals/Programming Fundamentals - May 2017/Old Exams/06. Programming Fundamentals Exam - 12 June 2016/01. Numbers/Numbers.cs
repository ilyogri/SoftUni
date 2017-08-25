namespace _01.Numbers
{
    using System;
    using System.Linq;

    public class Numbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var average = numbers.Average();

            var resultNumbers = numbers
                .OrderByDescending(n => n)
                .Where(n => n > average)
                .Take(5);

            if (!resultNumbers.Any())
            {
                Console.WriteLine("No");
            }

            else
            {
                Console.WriteLine(string.Join(" ", resultNumbers));
            }
        }
    }
}