namespace _12.Rectangle_Properties
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rectangleWidth = double.Parse(Console.ReadLine());
            var rectangleHeight = double.Parse(Console.ReadLine());

            var rectanglePerimer = 2 * (rectangleHeight + rectangleWidth);
            var rectangleArea = rectangleHeight * rectangleWidth;
            var rectangleDiagonal = Math.Sqrt(Math.Pow(rectangleWidth, 2) + (Math.Pow(rectangleHeight, 2)));

            Console.WriteLine(rectanglePerimer);
            Console.WriteLine(rectangleArea);
            Console.WriteLine(rectangleDiagonal);
        }
    }
}