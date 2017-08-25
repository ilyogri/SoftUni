using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine(); ;

            var unsplittedNumbers = Regex.Split(input, @"[^\d]").ToList();

            unsplittedNumbers.RemoveAll(x => x == "");

            var strings = input.Split(new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            var uniqueSymbolsCount = string.Concat(strings).ToLower().Distinct().ToArray().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");

            var outputString = string.Empty;
            var counter = 0;

            foreach (var text in strings)
            {
                outputString += string.Concat(Enumerable.Repeat(text, int.Parse(unsplittedNumbers[counter])));
                counter++;
            }

            Console.WriteLine(outputString.ToUpper());
        }
    }
}