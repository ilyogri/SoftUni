namespace Problem_15.Balanced_Brackets
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var openingBracketCount = 0;
            var closingBracketCount = 0;

            for (int i = 0; i < linesCount; i++)
            {
                var input = Console.ReadLine();

                if(input == "(")
                {
                    openingBracketCount++;
                }

                else if (input == ")")
                {
                    closingBracketCount++;
                }
            }

            var areBalanced = openingBracketCount == closingBracketCount ? "BALANCED" : "UNBALANCED";

            Console.WriteLine(areBalanced);
        }
    }
}