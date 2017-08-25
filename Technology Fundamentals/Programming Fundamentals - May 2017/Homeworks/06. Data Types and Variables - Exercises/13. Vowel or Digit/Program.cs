namespace _13.Vowel_or_Digit
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string symbol = Console.ReadLine();

            if (IsVowel(symbol))
            {
                Console.WriteLine("vowel");
            }

            else if (IsDigit(symbol))
            {
                Console.WriteLine("digit");
            }

            else
                Console.WriteLine("other");
        }

        static bool IsVowel(string symbol)
        {
            char[] vowelArr = new char[] { 'a', 'e', 'o', 'u', 'i' };

            foreach (char letter in vowelArr)
            {
                if(symbol.Contains(letter))
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsDigit(string symbol)
        {
            char[] digitArr = new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            foreach (char letter in digitArr)
            {
                if (symbol.Contains(letter))
                {
                    return true;
                }
            }

            return false;
        }
    }
}