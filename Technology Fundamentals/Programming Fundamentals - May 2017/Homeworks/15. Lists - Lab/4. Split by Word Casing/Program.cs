namespace _4.Split_by_Word_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var separators = new char[] { ':',',', ';', '.', '!', '(', ')', '"', '\\', '/', '[', ']', ' ', '\'' };
            var text = Console.ReadLine().Split(separators).ToList();

            text.RemoveAll(x => x == "");

            var lowerCaseWords = new List<string>(text.Count());
            var upperCaseWords = new List<string>(text.Count());
            var mixedCaseWords = new List<string>(text.Count());
            var lowerCaseCounter = 0;
            var upperCaseCounter = 0;

            for (int i = 0; i < text.Count(); i++)
            {
                var textToChar = text[i].ToCharArray();
                lowerCaseCounter = 0;
                upperCaseCounter = 0;

                for (int j = 0; j < text[i].Count(); j++)
                {
                    if (char.IsLower(textToChar[j]))
                    {
                        lowerCaseCounter++;
                    }                   

                    if (char.IsUpper(textToChar[j]))
                    {
                        upperCaseCounter++;
                    }
                }

                if (lowerCaseCounter == text[i].Count())
                {
                    lowerCaseWords.Add(text[i]);
                }

                else if (upperCaseCounter == text[i].Count())
                {
                    upperCaseWords.Add(text[i]);
                }

                else
                {
                    mixedCaseWords.Add(text[i]);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCaseWords));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCaseWords));
        }
    }
}
