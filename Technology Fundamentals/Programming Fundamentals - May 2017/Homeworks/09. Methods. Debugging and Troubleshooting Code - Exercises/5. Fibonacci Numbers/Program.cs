namespace _5.Fibonacci_Numbers
{
    using System;

   public class Program
    {
        public static void Main()
        {
            Console.WriteLine(GetFibonacciNumber(int.Parse(Console.ReadLine())));
        }

        static int GetFibonacciNumber(int number)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i <= number; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}