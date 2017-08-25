namespace _1.Match_full_name
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"\b[A-Z][a-z]\s[A-Z][a-z]\b");

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}