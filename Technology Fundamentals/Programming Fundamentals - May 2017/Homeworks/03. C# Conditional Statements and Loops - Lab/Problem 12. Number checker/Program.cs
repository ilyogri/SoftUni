namespace Problem_12.Number_checker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            double numberStorage;
            if(double.TryParse(input, out numberStorage))
            {
                Console.WriteLine("It is a number.");
            }

            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}