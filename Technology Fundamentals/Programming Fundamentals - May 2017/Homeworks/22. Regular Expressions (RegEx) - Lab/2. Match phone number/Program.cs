namespace _2.Match_phone_number
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"\+359(-|\s)2\1\d{3}\1\d{4}\b");
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}