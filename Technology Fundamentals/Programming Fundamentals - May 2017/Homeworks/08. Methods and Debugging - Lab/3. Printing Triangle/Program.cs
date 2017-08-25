namespace _3.Printing_Triangle
{
    using System;

    public class Program
    {
        static void Main()
        {

            int number = int.Parse(Console.ReadLine());
            TriangleLength(number);
        }

        public static void TriangleLength(int number)
        {
            //Top side of the triangle
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j.ToString() + " ");
                }

                Console.WriteLine();
            }

            //Bot side of the triangle       
            for (int i = number - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j.ToString() + " ");
                }

                Console.WriteLine();
            }
        }
    }
}