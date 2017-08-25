namespace _6.Strings_and_Objects
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string firstString = "Hello";
            string secondString = "World";

            object concatenationOfStrings = firstString + " " + secondString;

            string result = (string)concatenationOfStrings;

            Console.WriteLine(result);
        }
    }
}