namespace Problem_5.Weather_Forecast
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberAsString = Console.ReadLine();

            if (IsSbyte(numberAsString))
            {
                Console.WriteLine("Sunny");
            }

            else if (IsInteger(numberAsString))
            {
                Console.WriteLine("Cloudy");
            }

            else if (IsLong(numberAsString))
            {
                Console.WriteLine("Windy");
            }

            else if (IsFloatNumber(numberAsString))
            {
                Console.WriteLine("Rainy");
            }
        }

        public static bool IsSbyte(string numberString)
        {
            sbyte number;
            if (sbyte.TryParse(numberString, out number))
            {
                return true;
            }

            return false;
        }

        public static bool IsInteger(string numberString)
        {
            int number;
            if (int.TryParse(numberString, out number))
            {
                return true;
            }

            return false;
        }

        public static bool IsLong(string numberString)
        {
            long number;
            if (long.TryParse(numberString, out number))
            {
                return true;
            }

            return false;
        }

        public static bool IsFloatNumber(string numberString)
        {
            double number;
            if (double.TryParse(numberString, out number))
            {
                return true;
            }

            return false;
        }
    }
}