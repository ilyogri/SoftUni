namespace _4.Distance_Between_Points
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var secondNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var firstPoints = new Point
            {
                X = firstNumbers[0],
                Y = firstNumbers[1]
            };

            var secondPoints = new Point
            {
                X = secondNumbers[0],
                Y = secondNumbers[1]
            };

            Console.WriteLine("{0:f3}", GetDistance(firstPoints, secondPoints));
        }

        public static double GetDistance(Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2)
                + Math.Pow(firstPoint.Y - secondPoint.Y, 2));
        }
    }
}