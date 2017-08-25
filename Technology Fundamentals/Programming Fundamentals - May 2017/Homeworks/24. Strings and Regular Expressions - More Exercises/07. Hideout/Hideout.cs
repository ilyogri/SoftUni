namespace _07.Hideout
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Hideout
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            while (true)
            {
                var clues = Console.ReadLine().Split();

                var searchedCharacter = clues[0];
                var minimumCount = int.Parse(clues[1]);

                var regex = new Regex($"\\{searchedCharacter}{{{minimumCount},}}");
                var match = regex.Match(text);

                if (match.Success)
                {
                    PrintHideout(searchedCharacter.ToString(), match.ToString(), text);
                    break;
                }              
            }
        }

        public static void PrintHideout(string searchedCharacter, string match, string text)
        {
            var foundIndex = text.IndexOf(match.ToString());
            var newText = text.Remove(0, foundIndex);
            var searchedCharCount = newText.TakeWhile(x => x == searchedCharacter.ToCharArray()[0]).Count();

            Console.WriteLine($"Hideout found at index {foundIndex} and it is with size {searchedCharCount}!");
        }
    }
}