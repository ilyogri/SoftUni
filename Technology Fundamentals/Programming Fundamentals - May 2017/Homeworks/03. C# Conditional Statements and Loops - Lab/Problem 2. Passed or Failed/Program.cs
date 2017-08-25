namespace Problem_2.Passed_or_Failed
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var grade = double.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }

            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}