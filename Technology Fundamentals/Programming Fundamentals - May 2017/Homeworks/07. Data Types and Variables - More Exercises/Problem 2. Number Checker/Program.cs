namespace Problem_2.Number_Checker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine();

            long integerStorage;
            var isInteger = long.TryParse(number, out integerStorage);

            if (isInteger)
            {
                Console.WriteLine("integer");
            }

            else
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}