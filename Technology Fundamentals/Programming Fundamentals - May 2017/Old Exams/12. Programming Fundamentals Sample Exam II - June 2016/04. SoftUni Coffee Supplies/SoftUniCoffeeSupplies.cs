namespace _04.SoftUni_Coffee_Supplies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniCoffeeSupplies
    {
        public static void Main()
        {
            var delimeters = Console.ReadLine().Split();

            var firstDelimeter = delimeters[0];
            var secondDelimeter = delimeters[1];

            var personList = new List<Person>();
            var coffeeList = new List<Coffee>();

            var input = Console.ReadLine();
            while (input != "end of info")
            {
                var coffeeQuantity = 0m;

                if (input.Contains(firstDelimeter))
                {
                    var tokens = input.Split(new string[] { firstDelimeter }, StringSplitOptions.None);

                    var name = tokens[0];
                    var coffeeType = tokens[1];

                    var personClassAddInfo = new Person(name, coffeeType);

                    var index = coffeeList.FindIndex(c => c.Type == coffeeType);

                    if (index < 0)
                    {
                        var coffeeClassAddInfo = new Coffee(coffeeType, coffeeQuantity);
                        coffeeList.Add(coffeeClassAddInfo);
                    }

                    //else
                    //{
                    //    coffeeList[index].Quantity += coffeeQuantity;
                    //}

                    personList.Add(personClassAddInfo);
                }

                else
                {
                    var tokens = input.Split(new string[] { secondDelimeter }, StringSplitOptions.None);

                    var coffeeType = tokens[0];
                    coffeeQuantity = decimal.Parse(tokens[1]);

                    var index = coffeeList.FindIndex(c => c.Type == coffeeType); //check if the the coffeeList contains the current coffeeType

                    if (index < 0)
                    {
                        var coffeeClassAddInfo = new Coffee(coffeeType, coffeeQuantity);
                        coffeeList.Add(coffeeClassAddInfo);
                    }

                    else
                    { 
                        coffeeList[index].Quantity += coffeeQuantity;
                    }
                }

                input = Console.ReadLine();
            }


            input = Console.ReadLine();
            while (input != "end of week")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var coffeeTypeOrderedCount = long.Parse(tokens[1]);

                var personIndex = personList.FindIndex(c => c.Name == name);
                var currentNameCoffeeType = personList[personIndex].CoffeeType;

                var coffeeIndex = coffeeList.FindIndex(c => c.Type == currentNameCoffeeType);
                coffeeList[coffeeIndex].Quantity -= coffeeTypeOrderedCount;

                input = Console.ReadLine();
            }

            PrintMissingCoffee(coffeeList);
            PrintResult(coffeeList, personList);
        }

        public static void PrintResult(List<Coffee> coffeeList, List<Person> personList)
        {
            Console.WriteLine("Coffee Left:");
            var sortedCoffeeLeft = coffeeList
                .Where(q => q.Quantity > 0)
                .OrderByDescending(q => q.Quantity);

            var coffeeTypeLeftList = new List<string>();

            foreach (var data in sortedCoffeeLeft)
            {
                Console.WriteLine($"{data.Type} {data.Quantity}");
                coffeeTypeLeftList.Add(data.Type);
            }

            var personNameAndCofeeType = personList
                .Where(c => coffeeTypeLeftList.Contains(c.CoffeeType))
                .OrderBy(c => c.CoffeeType)
                .ThenByDescending(c => c.Name);

            Console.WriteLine("For:");
            foreach (var data in personNameAndCofeeType)
            {
                Console.WriteLine($"{data.Name} {data.CoffeeType}");
            }
        }

        public static void PrintMissingCoffee(List<Coffee> coffeeList)
        {
            foreach (var coffee in coffeeList.Where(c => c.Quantity <= 0))
            {
                Console.WriteLine($"Out of {coffee.Type}");
            }
        }
    }
}