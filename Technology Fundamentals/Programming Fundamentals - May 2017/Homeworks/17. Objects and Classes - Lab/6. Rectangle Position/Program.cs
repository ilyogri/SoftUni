namespace _6.Rectangle_Position
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstRectangleInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var secondRectanlgeInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var firstRectangle = new Rectangles
            {
                X1 = firstRectangleInput[0],
                Y1 = firstRectangleInput[1],
                X2 = firstRectangleInput[2],
                Y2 = firstRectangleInput[3]
            };

            var secondRectangle = new Rectangles
            {
                X1 = secondRectanlgeInput[0],
                Y1 = secondRectanlgeInput[1],
                X2 = secondRectanlgeInput[2],
                Y2 = secondRectanlgeInput[3]
            };

            if (IsFirstRectangleInsideSecondRectangle(firstRectangle, secondRectangle))
            {
                Console.WriteLine("Inside");
            }

            else
            {
                Console.WriteLine("Not Inside");
            }
        }

        public static bool IsFirstRectangleInsideSecondRectangle(Rectangles firstRectangle, Rectangles secondRectangle)
        {
            return ((firstRectangle.X1 >= secondRectangle.X1)
                && (firstRectangle.Y1 >= secondRectangle.Y1)
                && ((firstRectangle.X1 + firstRectangle.X2) <= (secondRectangle.X2 + secondRectangle.X2))
                && ((Math.Abs(Math.Abs(firstRectangle.Y1) - Math.Abs(firstRectangle.Y2)) <=
                Math.Abs(Math.Abs(secondRectangle.Y1) - Math.Abs(secondRectangle.Y2)))));
        }
    }
}