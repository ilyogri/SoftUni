namespace Problem_8.House_Builder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstNumber = long.Parse(Console.ReadLine());
            var secondNumber = long.Parse(Console.ReadLine());

            if (firstNumber >= 0 && firstNumber <= 127)
            {
                Console.WriteLine((firstNumber * 4) + (secondNumber * 10));
            }

            else
            {
                Console.WriteLine((secondNumber * 4) + (firstNumber * 10));
            }
        }
    }
}