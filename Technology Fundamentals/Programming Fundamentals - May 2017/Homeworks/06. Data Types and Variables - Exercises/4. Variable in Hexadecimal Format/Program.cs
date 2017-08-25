namespace _4.Variable_in_Hexadecimal_Format
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var hexadecimalFormat = Console.ReadLine();

            Console.WriteLine(Convert.ToInt32(hexadecimalFormat,16));
        }
    }
}