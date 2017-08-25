namespace _7.Replace_tag
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var textInput = Console.ReadLine();

            var result = string.Empty;

            while (textInput != "end")
            {
                var regex = new Regex(@"<a\shref=(.+?)>(.+?)<\/a>");

                result = regex.Replace(textInput, "[URL href=$1]$2[/URL]");

                Console.WriteLine(result);

                textInput = Console.ReadLine();
            }
        }
    }
}