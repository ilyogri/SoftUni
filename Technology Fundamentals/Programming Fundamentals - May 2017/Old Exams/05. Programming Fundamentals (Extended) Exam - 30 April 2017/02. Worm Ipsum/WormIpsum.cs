namespace _02.Worm_Ipsum
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WormIpsum
    {
        public static void Main()
        {
            var sentenceRegex = new Regex(@"^[A-Z][^\.]*\.$");
            var wordsRegex = new Regex(@"[^\s,\.]+");

            var inputText = Console.ReadLine();
            while (inputText != "Worm Ipsum")
            {
                var sentenceMatch = sentenceRegex.Match(inputText);
                if (sentenceMatch.Success)
                {
                    var wordsMatches = wordsRegex.Matches(inputText);

                    foreach (Match match in wordsMatches)
                    {
                        var currentWord = match.Value;
                        if (currentWord.Distinct().Count() != currentWord.Count())
                        {
                            var symbol = GetMostRepeatedChar(currentWord);
                            var newWord = new string(symbol, currentWord.Length);
                            inputText = Regex.Replace(inputText, currentWord, newWord);
                        }
                    }

                    Console.WriteLine(inputText);
                }

                inputText = Console.ReadLine();
            }
        }


        public static char GetMostRepeatedChar(string word)
        {
            return word
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .ToArray()[0]
                .Key;
        }
    }
}