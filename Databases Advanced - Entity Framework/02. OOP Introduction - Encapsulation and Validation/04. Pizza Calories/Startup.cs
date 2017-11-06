namespace _04.Pizza_Calories
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var toppingsCount = 0;
            var pizza = new Pizza();
            var totalCalories = 0.0;
            try
            {
                var pizzaArgs = Console.ReadLine().Split();
                var pizzaName = pizzaArgs[1];
                pizza.Name = pizzaName;

                pizzaArgs = Console.ReadLine().Split();
                while (pizzaArgs[0] != "END")
                {
                    var ingredientType = pizzaArgs[0];
                    if (ingredientType == "Dough")
                    {
                        var flourType = pizzaArgs[1];
                        var bakingTechnique = pizzaArgs[2];
                        var weight = double.Parse(pizzaArgs[3]);
                        var dough = new Dough(flourType, bakingTechnique, weight);
                        totalCalories += dough.CalculateCalories();
                        pizza.Dough = dough;
                    }
                    else if (ingredientType == "Topping")
                    {
                        var toppingType = pizzaArgs[1];
                        var weight = double.Parse(pizzaArgs[2]);
                        var topping = new Topping(toppingType, weight);
                        totalCalories += topping.CalculateCalories();
                        pizza.Toping.Add(topping);
                        toppingsCount++;
                    }
                    pizzaArgs = Console.ReadLine().Split();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (toppingsCount > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                return;
            }
            PrintResult(pizza, totalCalories);
        }

        public static void PrintResult(Pizza pizza, double totalCalories)
        {
            Console.WriteLine($"{pizza.Name} - {totalCalories:f2} Calories.");
        }
    }
}