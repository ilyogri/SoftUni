namespace Problem_7.Training_Hall_Equipment
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var budget = double.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            var subtotal = 0.0;

            for (int i = 0; i < linesCount; i++)
            {
                var nameOfItem = Console.ReadLine();
                var priceOfItem = double.Parse(Console.ReadLine());
                var quantityOfItem = int.Parse(Console.ReadLine());

                subtotal += priceOfItem * quantityOfItem;

                if (!(quantityOfItem == 1))
                {
                    nameOfItem += "s";
                }

                Console.WriteLine($"Adding {quantityOfItem} {nameOfItem} to cart.");
            }

            Console.WriteLine($"Subtotal: ${subtotal:f2}");

            if (subtotal <= budget)
            {
                Console.WriteLine($"Money left: ${(budget - subtotal):f2}");
            }

            else
            {
                Console.WriteLine($"Not enough. We need ${(subtotal - budget):f2} more.");
            }
        }
    }
}