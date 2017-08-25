namespace _6.Math_Power
{
    using System;

    public class GreaterOfТwoValues
    {
        public static void Main()
        {
            var type = Console.ReadLine().ToLower();

            if (type == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMaxInteger(firstNumber, secondNumber));
            }

            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMaxChar(firstChar, secondChar));
            }

            else if (type == "string")
            {
                var firstString = Console.ReadLine();
                var secondString = Console.ReadLine();

                Console.WriteLine(GetMaxString(firstString, secondString));
            }
        }

        public static string GetMaxString(string firstString, string secondString)
        {
            if (string.Compare(firstString, secondString) >= 0)
            {
                return firstString;
            }

            return secondString;
        }

        public static int GetMaxInteger(int firstNumber, int secondNumber)
        {
            if (firstNumber >= secondNumber)
            {
                return firstNumber;
            }

            return secondNumber;
        }

        public static char GetMaxChar(char firstChar, char secondChar)
        {

            if (firstChar >= secondChar)
            {
                return firstChar;
            }

            return secondChar;
        }
    }
}