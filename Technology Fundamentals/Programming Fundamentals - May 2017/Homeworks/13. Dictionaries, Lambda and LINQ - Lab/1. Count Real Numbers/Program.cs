namespace _1.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse);

            var numbersDict = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numbersDict.ContainsKey(number))
                {
                    numbersDict[number] = 0;
                }

                numbersDict[number] += 1;
            }

            foreach (KeyValuePair<double, int> input in numbersDict)
            {
                Console.WriteLine(string.Join(" ", input.Key) + " -> " + string.Join(" ", input.Value));
            }
        }
    }
}
