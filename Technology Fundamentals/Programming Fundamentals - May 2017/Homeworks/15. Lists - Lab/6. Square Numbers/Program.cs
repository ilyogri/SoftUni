namespace _6.Square_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var squareNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (Math.Sqrt(number) % 1 == 0)
                {
                    squareNumbers.Add(number);
                }
            }

            squareNumbers.Sort();
            squareNumbers.Reverse();

            Console.WriteLine(string.Join(" ",squareNumbers));
        }
    }
}
