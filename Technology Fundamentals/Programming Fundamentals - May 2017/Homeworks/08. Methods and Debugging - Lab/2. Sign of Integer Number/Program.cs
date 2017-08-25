namespace _2.Sign_of_Integer_Number
{
    using System;

    public class Program
    {
        public static void Main()
        {
            PrintSign();
        }

        public static void PrintSign()
        {
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }

            else if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }

            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
        }
    }
}