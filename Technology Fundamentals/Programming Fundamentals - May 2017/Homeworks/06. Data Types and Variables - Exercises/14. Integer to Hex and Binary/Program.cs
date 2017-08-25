namespace _14.Integer_to_Hex_and_Binary
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            Console.WriteLine("{0:X}",input);
            Console.WriteLine(Convert.ToString(input, 2));
        }
    }
}