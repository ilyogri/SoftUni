namespace _5.Boolean_Variable
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            bool boolInput = Convert.ToBoolean(input);

            var result = boolInput ? "Yes" : "No";

            Console.WriteLine(result);
        }
    }
}