namespace _03.Nether_Realms
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Linq;

    public class NetherRealms
    {
        public static void Main()
        {
            var demon = new List<Demon>();

            var input = Console.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var data in input)
            {
                var demonName = GetDemonName(data);
                var demonDamage = GetDemonDamage(data);
                var demonHealth = GetDemonHealth(demonName);
                
                var demonInfo = new Demon(data, demonHealth, demonDamage);
                demon.Add(demonInfo);
            }

            PrintResult(demon);
        }

        public static string GetDemonName(string input)
        {
            var nameReg = new Regex(@"[^0-9+\-\*\/\.]+");
            var name = new StringBuilder();

            foreach (var text in nameReg.Matches(input))
            {
                name.Append(text);
            }

            return name.ToString();
        }

        public static int GetDemonHealth(string name)
        {
            var health = 0;

            foreach (var letter in name)
            {
                health += letter;
            }

            return health;
        }

        public static double GetDemonDamage(string input)
        {
            var numbersReg = new Regex(@"[-+]*\d+\.*\d*");
            var specCalculations = new Regex(@"[*/]");

            var numbersSum = 0.0;

            foreach (var number in numbersReg.Matches(input))
            {
                numbersSum += double.Parse(number.ToString());
            }

            foreach (var specSymbol in specCalculations.Matches(input))
            {
                var symbol = specSymbol.ToString();

                if (symbol == "*")
                {
                    numbersSum *= 2;
                }

                else
                {
                    numbersSum /= 2;
                }
            }

            return numbersSum;
        }

        public static void PrintResult(List<Demon> demon)
        {
            var sortedDemons = demon
                .OrderBy(n => n.Name);

            foreach (var data in sortedDemons)
            {
                Console.WriteLine($"{data.Name} - {data.Health} health, {data.Damage:f2} damage");
            }
        }
    }
}