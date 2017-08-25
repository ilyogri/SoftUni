namespace _5.Calculate_Triangle_Area
{
    using System;

   public class CalculateTriangleArea
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            double triangleArea = width * heigth / 2;

            Console.WriteLine(triangleArea);

        }

        public static double GetTriangleArea(double width, double heigth)
        {
            return width * heigth / 2;
        }
    }
}