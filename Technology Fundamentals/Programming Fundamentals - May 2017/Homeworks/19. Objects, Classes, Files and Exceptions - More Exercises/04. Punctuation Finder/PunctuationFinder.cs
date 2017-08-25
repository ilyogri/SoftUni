namespace _04.Punctuation_Finder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class PunctuationFinder
    {
        public static void Main()
        {
            var text = File.ReadAllText("c:\\sample_text.txt");
            var regex = new Regex(@"[.,!?:]");

            var matchesList = new List<string>();

            foreach (Match match in regex.Matches(text))
            {
                matchesList.Add(match.ToString());
            }

            Console.WriteLine(string.Join(", ", matchesList));
        }
    }
}