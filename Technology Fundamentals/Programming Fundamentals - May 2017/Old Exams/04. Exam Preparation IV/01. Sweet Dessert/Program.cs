namespace _01.Sweet_Dessert
{
    using System;

    public class SweetDessert
    {
        public static void Main()
        {
            var cash = double.Parse(Console.ReadLine());
            var numberOfGuests = int.Parse(Console.ReadLine());
            var bananasPrice = double.Parse(Console.ReadLine());
            var eggsPrice = double.Parse(Console.ReadLine());
            var berriesPriceKG = double.Parse(Console.ReadLine());

            var sets = (int)Math.Ceiling(numberOfGuests / 6.0);
            var productsPrice =
                (sets * (2 * bananasPrice)) + (sets * (4 * eggsPrice)) + (sets * (0.2 * berriesPriceKG));

            if(productsPrice <= cash)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {productsPrice:f2}lv.");
            }

            else
            {
                var cashNeeded = productsPrice - cash;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {cashNeeded:f2}lv more.");
            }
        }
    }
}