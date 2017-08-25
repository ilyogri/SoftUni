namespace Problem_8.Upgraded_Matcher
{
    using System;
    using System.Linq;

    public class UpgradedMatcher
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ');
            var quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            var command = Console.ReadLine().Split(' ');

            while (command[0] != "done")
            {
                var index = Array.IndexOf(names, command[0]);
                var currentPrice = 0.0m;
                var currentProduct = names[index];
                var quantityNeeded = long.Parse(command[1]);
                long validQuantity = 0;

                if (index < prices.Length)
                {
                    currentPrice = prices[index];

                    if (index < quantities.Length)
                    {
                        validQuantity = quantities[index];
                    }
                }

                if (validQuantity >= quantityNeeded)
                {
                    quantities[index] -= quantityNeeded;
                    Console.WriteLine("{0} x {1} costs {2:f2}", currentProduct,quantityNeeded, currentPrice * quantityNeeded);
                }

                else
                {
                    Console.WriteLine($"We do not have enough {currentProduct}");
                }

                command = Console.ReadLine().Split(' ');
            }
        }
    }
}