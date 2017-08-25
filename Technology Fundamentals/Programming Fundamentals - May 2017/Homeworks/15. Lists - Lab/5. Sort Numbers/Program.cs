namespace _5.Sort_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            
            for (int i = 0; i < numbers.Count() - 1; i++)
            {
                var tempSortedNumbers = new List<decimal>(numbers);

                for (int j = i + 1; j < numbers.Count(); j++)
                {
                    if (numbers[i] >= numbers[j])
                    {
                        numbers[j] = numbers[i];
                        numbers[i] = tempSortedNumbers[j];
                    }
                }
            }

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}
