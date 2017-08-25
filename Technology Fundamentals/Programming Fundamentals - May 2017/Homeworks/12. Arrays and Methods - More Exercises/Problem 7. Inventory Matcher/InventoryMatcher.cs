namespace Problem_7.Inventory_Matcher
{
    using System;

   public class InventoryMatcher
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ');
            var quantities = Console.ReadLine().Split(' ');
            var prices = Console.ReadLine().Split(' ');

            var command = Console.ReadLine();

            while (command != "done")
            {
                var index = Array.IndexOf(names, command);

                var currentProduct = names[index];
                var currentQuantity = long.Parse(quantities[index]);
                var currentPrice = decimal.Parse(prices[index]);

                Console.WriteLine($"{currentProduct} costs: {currentPrice}; Available quantity: {currentQuantity}");

                command = Console.ReadLine();
            }
        }
    }
}