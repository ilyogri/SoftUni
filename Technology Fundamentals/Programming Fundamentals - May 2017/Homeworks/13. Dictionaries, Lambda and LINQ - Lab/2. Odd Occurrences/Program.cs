namespace _2.Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToLower().Split(' ').ToList();

            var wordsDict = new Dictionary<string, int>();

            foreach (var element in input)
            {
                //if the element does not exist in our dictinoary we add it with count of 1
                if (!wordsDict.ContainsKey(element))
                {
                    wordsDict[element] = 0;
                }

                wordsDict[element] += 1;
            }

            var oddOccurrences = new List<string>();

            foreach (var count in wordsDict)
            {
                if (count.Value % 2 != 0)
                {
                    oddOccurrences.Add(count.Key);
                }
            }

            Console.WriteLine(string.Join(", ", oddOccurrences));
        }
    }
}

