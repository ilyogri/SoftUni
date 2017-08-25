namespace _08.Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Mines
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"<(.{1})(.{1})>");
            var matches = regex.Matches(text);

            foreach (Match mineMatch in matches)
            {
                var firstLetter = mineMatch.Groups[1].ToString().ToArray()[0];
                var secondLetter = mineMatch.Groups[2].ToString().ToArray()[0];

                var blastRadius = Math.Abs(firstLetter - secondLetter);
                text = RemoveAtLeft(text, blastRadius, '<');
                text = RemoveAtRight(text, blastRadius, '>');
            }

            Console.WriteLine(text);
        }

        public static string RemoveAtRight(string text, int blastRadius, char secondLetter)
        {
            var secondLetterIndex = text.IndexOf(secondLetter);

            var textSB = new StringBuilder(text);

            for (int i = 0; i < blastRadius + 1; i++)
            {
                if (secondLetterIndex >= 0 && secondLetterIndex < textSB.Length)
                {
                    textSB[secondLetterIndex] = '_';
                    secondLetterIndex++;
                }

                else
                {
                    break;
                }
            }

            return textSB.ToString();
        }

        public static string RemoveAtLeft(string text, int blastRadius, char firstLetter)
        {
            var firstLetterIndex = text.IndexOf(firstLetter) + 2;

            var textSB = new StringBuilder(text);

            for (int i = 0; i < blastRadius + 3; i++)
            {
                if (firstLetterIndex >= 0)
                {
                    textSB[firstLetterIndex] = '_';
                    firstLetterIndex--;
                }

                else
                {
                    break;
                }
            }

            return textSB.ToString();
        }
    }
}