namespace _6.Fold_and_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var numbersLength = numbers.Count();
            var k = numbersLength / 4;

            //adding the numbers at left
            var sideNumbers = numbers
                .Skip(0)
                .Take(k)
                .Reverse()
                .ToList();

            //adding the numbers at right
                 sideNumbers.InsertRange(sideNumbers.Count, numbers
                .Skip(numbersLength - k)
                .Take(k)
                .Reverse());

            //adding the middle numbers
            var middleNumbers = numbers
                .Skip(k)
                .Take(k * 2)
                .ToList();
            
            //summing the middle numbers with the side numbers
            var sum = middleNumbers.Zip(sideNumbers, (x, y) => x + y);

            Console.WriteLine(string.Join(" ", sum));
            
        }
    }
}
