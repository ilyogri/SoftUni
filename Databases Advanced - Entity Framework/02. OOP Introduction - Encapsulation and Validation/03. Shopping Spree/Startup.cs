namespace _03.Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var personsNameAndPrice = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var persons = new List<Person>();
            for (int i = 0; i < personsNameAndPrice.Length; i++)
            {
                try
                {
                    var splittedInput = personsNameAndPrice[i].Split('=');
                    var name = splittedInput[0];
                    var money = decimal.Parse(splittedInput[1]);

                    var person = new Person(name, money);
                    persons.Add(person);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var productsNameAndPrice = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            var products = new List<Product>();
            for (int i = 0; i < productsNameAndPrice.Length; i++)
            {
                try
                {
                    var splittedInput = productsNameAndPrice[i].Split('=');
                    var name = splittedInput[0];
                    var price = decimal.Parse(splittedInput[1]);
                    var product = new Product(name, price);
                    products.Add(product);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var boughts = Console.ReadLine().Split();
            while (boughts[0] != "END")
            {
                var buyer = boughts[0];
                var productToBuy = boughts[1];

                var person = persons.FirstOrDefault(p => p.Name == buyer);
                var product = products.FirstOrDefault(p => p.Name == productToBuy);

                if (person != null && product != null)
                {
                    if (person.Money < product.Price)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        person.Money -= product.Price;
                        person.BagOfProducts.Add(product.Name);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                }

                boughts = Console.ReadLine().Split();
            }

            PrintResult(persons);
        }

        public static void PrintResult(List<Person> persons)
        {
            foreach (var p in persons)
            {
                if (p.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{p.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{p.Name} - {string.Join(", ", p.BagOfProducts)}");
                }
            }
        }
    }
}