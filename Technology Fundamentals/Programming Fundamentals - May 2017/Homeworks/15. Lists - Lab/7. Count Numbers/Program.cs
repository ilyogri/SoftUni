namespace _7.Count_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var occurrencesList = new List<int>();
            var resultNumbers = new List<int>();
            numbers.Sort();

            for (int i = 0; i < numbers.Count(); i++)
            {
                var occurrencesCounter = 1;

                for (int j = i + 1; j < numbers.Count(); j++)
                {
                    if(numbers[i] == numbers[j])
                    {
                        occurrencesCounter++;
                    }
                }

                if (!resultNumbers.Contains(numbers[i]))
                {
                    resultNumbers.Add(numbers[i]);
                    Console.WriteLine(numbers[i] + " -> " + occurrencesCounter);
                }
            }
        }
    }
}