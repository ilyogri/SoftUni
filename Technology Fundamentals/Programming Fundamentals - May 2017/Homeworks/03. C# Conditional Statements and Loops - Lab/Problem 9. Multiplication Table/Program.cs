namespace Problem_9.Multiplication_Table
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }
        }
    }
}