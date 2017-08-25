namespace _4.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Strings
    {
        public static void Main()
        {
            var text = Console.ReadLine().Split(new string[] { ",", ".", " ", "?", "!" },StringSplitOptions.RemoveEmptyEntries);

            var uniquePalindromes = new HashSet<string>();

            foreach (var word in text)
            {
                var reversedWord = string.Concat(word.Reverse());

                if (word == reversedWord)
                {
                    uniquePalindromes.Add(word);
                }
            }

            Console.WriteLine(string.Join(", ", uniquePalindromes.OrderBy(x => x)));
        }
    }
}