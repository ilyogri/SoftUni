namespace _02.Trophon_the_Grumpy_Cat
{
    using System;
    using System.Linq;

    public class TrophonTheGrumpyCat
    {
        public static void Main()
        {
            var priceRatings = Console.ReadLine().Split().Select(long.Parse).ToList();
            var entryPoint = int.Parse(Console.ReadLine());
            var typeOfItems = Console.ReadLine();
            var typeOfPriceRatings = Console.ReadLine();

            var leftNums = priceRatings.Take(entryPoint).ToList();
            var rightNums = priceRatings.Skip(entryPoint + 1).Take(priceRatings.Count).ToList();

            if (typeOfItems == "cheap")
            {
                leftNums = leftNums.Where(x => x < priceRatings[entryPoint]).ToList();
                rightNums = rightNums.Where(x => x < priceRatings[entryPoint]).ToList();
            }

            else if (typeOfItems == "expensive")
            {
                leftNums = leftNums.Where(x => x >= priceRatings[entryPoint]).ToList();
                rightNums = rightNums.Where(x => x >= priceRatings[entryPoint]).ToList();
            }

            if (typeOfPriceRatings == "positive")
            {
                leftNums = leftNums.Where(x => x >= 0).ToList();
                rightNums = rightNums.Where(x => x >= 0).ToList();
            }

            else if (typeOfPriceRatings == "negative")
            {
                leftNums = leftNums.Where(x => x < 0).ToList();
                rightNums = rightNums.Where(x => x < 0).ToList();
            }

            if (leftNums.Sum() >= rightNums.Sum())
            {
                Console.WriteLine("Left - " + leftNums.Sum());
            }

            else
            {
                Console.WriteLine("Right - " + rightNums.Sum());
            }
        }
    }
}