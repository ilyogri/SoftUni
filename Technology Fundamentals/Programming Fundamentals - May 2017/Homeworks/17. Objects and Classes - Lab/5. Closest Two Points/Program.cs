namespace _5.Closest_Two_Points
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numbersLineCount = int.Parse(Console.ReadLine());

            var points = new List<Points>();

            for (int i = 0; i < numbersLineCount; i++)
            {
                var currentPointsPair = Console.ReadLine()
                    .Split(' ')
                    .Select(double.Parse)
                    .ToArray();

                points.Add(new Points
                {
                    X = currentPointsPair[0],
                    Y = currentPointsPair[1]
                });
            }

            var lowestDistance = double.MaxValue;
            Points firstPointMin = null;
            Points secondPointMin = null;

            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    var firstPoint = points[i];
                    var secondPoint = points[j];

                    var currentDistance = GetDistance(firstPoint, secondPoint);

                    if (currentDistance < lowestDistance)
                    {
                        lowestDistance = currentDistance;
                        firstPointMin = firstPoint;
                        secondPointMin = secondPoint;
                    }
                }
            }

            Console.WriteLine("{0:f3}", lowestDistance);
            Console.WriteLine($"({firstPointMin.X}, {firstPointMin.Y})");
            Console.WriteLine($"({secondPointMin.X}, {secondPointMin.Y})");
        }

        public static double GetDistance(Points firstPoint, Points secondPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2)
                + Math.Pow(firstPoint.Y - secondPoint.Y, 2));
        }
    }
}