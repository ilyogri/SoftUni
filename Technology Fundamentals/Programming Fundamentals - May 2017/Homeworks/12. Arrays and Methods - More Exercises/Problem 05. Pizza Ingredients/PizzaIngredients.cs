namespace Problem_05.Pizza_Ingredients
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PizzaIngredients
    {
        public static void Main()
        {
            var ingredients = Console.ReadLine().Split(' ');
            var validLength = int.Parse(Console.ReadLine());

            var validIngredients = new List<string>();

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == validLength)
                {
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    validIngredients.Add(ingredients[i]);

                    if(validIngredients.Count() == 10)
                    {
                        break;  
                    }
                }
            }

            Console.WriteLine($"Made pizza with total of {validIngredients.Count()} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ",validIngredients)}.");
        }
    }
}