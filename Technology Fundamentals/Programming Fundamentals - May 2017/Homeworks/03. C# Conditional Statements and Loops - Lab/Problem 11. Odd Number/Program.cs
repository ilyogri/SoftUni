namespace Problem_11.Odd_Number
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
          
            while (true)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("Please write an odd number.");
                }

                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    break;
                }

                number = int.Parse(Console.ReadLine());
            }
        }
    }
}