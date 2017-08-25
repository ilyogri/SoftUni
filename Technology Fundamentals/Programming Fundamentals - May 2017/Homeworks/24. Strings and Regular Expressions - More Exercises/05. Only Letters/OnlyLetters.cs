namespace _05.Only_Letters
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"[0-9]+");
            var numbers = regex.Matches(text);

            var textArray = text.ToArray();

            foreach (Match match in numbers)
            {
                var indexOfNumber = text.IndexOf(match.ToString());

                if(indexOfNumber + match.ToString().Length == text.Length)
                {
                    break;
                }

                var letterToChange = text[indexOfNumber + match.ToString().Length].ToString();
                text = text.Replace(match.ToString(), letterToChange);
            }

            Console.WriteLine(text);
        }
    }
}