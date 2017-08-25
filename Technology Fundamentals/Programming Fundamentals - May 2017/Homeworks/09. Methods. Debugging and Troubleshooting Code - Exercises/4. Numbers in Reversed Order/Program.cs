namespace _4.Numbers_in_Reversed_Order
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputNumber = Console.ReadLine();

            Console.WriteLine(GetNumberInReverse(inputNumber));
        }

        private static string GetNumberInReverse(string inputNumber)
        {
            //  var reversedNumber = inputNumber.Reverse().Aggregate("", (a, b) => a + b);
            //return reversedNumber;
            return inputNumber.Reverse().Aggregate("", (a, b) => a + b);
        }
    }
}