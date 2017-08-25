namespace _2.Min_Method
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(firstNumber,secondNumber,thirdNumber));
        }

        static int GetMax(int a, int b, int c)
        {
            return Math.Max(GetMin(a, b), c);
        }

        static int GetMin(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}