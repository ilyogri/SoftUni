namespace _04.Supermarket_Database
{
    using System;
    using System.Collections.Generic;

    public class SupermarketDatabase
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var prodPriceQuantDict = new Dictionary<string, Dictionary<double, int>>();

            //this dict will hold the product and its quantity
            var productQuantity = new Dictionary<string, int>();

            while (input != "stocked")
            {
                var splittedInput = input.Split(' ');

                var product = splittedInput[0];
                var price = double.Parse(splittedInput[1]);
                var quantity = int.Parse(splittedInput[2]);

                if (!prodPriceQuantDict.ContainsKey(product))
                {
                    prodPriceQuantDict[product] = new Dictionary<double, int>();
                    prodPriceQuantDict[product].Add(price, quantity);

                    productQuantity[product] = quantity;
                }

                else
                {
                    //if the dictionary already contains the given product the quantity increases and the price is changed
                    quantity += productQuantity[product];
                    productQuantity[product] = quantity;

                    //this clears the info from the dict so the new price and quantity to be added
                    prodPriceQuantDict[product].Clear();
                    prodPriceQuantDict[product].Add(price, quantity);
                }

                input = Console.ReadLine();
            }

            var grandTotal = 0.0;

            foreach (var product in prodPriceQuantDict)
            {
                foreach (var priceQuant in product.Value)
                {
                    var currentTotal = priceQuant.Key * priceQuant.Value;
                    grandTotal += currentTotal;

                    Console.WriteLine($"{product.Key}: ${priceQuant.Key:f2} * {priceQuant.Value} = ${currentTotal:f2}");
                }
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:f2}");
        }
    }
}