namespace _04.NSA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NSA
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            var inputLine = Console.ReadLine();
            while (inputLine != "quit")
            {
                var tokens = inputLine.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var countryName = tokens[0];
                var spyName = tokens[1];
                var daysInService = int.Parse(tokens[2]);

                if (!dictionary.ContainsKey(countryName))
                {
                    dictionary[countryName] = new Dictionary<string, int>();
                }

                if (dictionary[countryName].ContainsKey(spyName))
                {
                    dictionary[countryName][spyName] = daysInService;
                }

                else
                {
                    dictionary[countryName].Add(spyName, daysInService);
                }

                inputLine = Console.ReadLine();
            }

            PrintResult(dictionary);
        }

        public static void PrintResult(Dictionary<string, Dictionary<string, int>> dictionary)
        {
            var sortedDict = dictionary
                .OrderByDescending(x => x.Value.Count());

            foreach (var country in sortedDict)
            {
                Console.WriteLine($"Country: {country.Key}");

                foreach (var spy in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }
    }
}