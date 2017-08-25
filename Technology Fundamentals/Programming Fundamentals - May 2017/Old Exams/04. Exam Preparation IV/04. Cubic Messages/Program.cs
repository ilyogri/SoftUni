namespace _04.Cubic_Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

   public class CubicMessages
    {
        public static void Main()
        {
            var message = Console.ReadLine();

            var messageCode = new Dictionary<string, string>();

            while (message != "Over!")
            {
                var charsCount = int.Parse(Console.ReadLine());
                var pattern = string.Format(@"^\d+([A-Za-z]{{{0}}})[^A-Za-z]*$", charsCount);
                var regex = new Regex(pattern);
                var match = regex.Match(message);

                if (regex.IsMatch(message))
                {
                    var verificationCode = string.Concat(match.ToString().Where(x => char.IsDigit(x)));
                    messageCode.Add(match.Groups[1].ToString(), verificationCode);
                }

                message = Console.ReadLine();
            }

            PrintResult(messageCode);
        }

        public static void PrintResult(Dictionary<string,string> messageCode)
        {
            foreach (var word in messageCode)
            {
                var codeString = string.Empty;

                foreach (var code in word.Value)
                {
                    var index = int.Parse(code.ToString());

                    if (index >= 0 && index < word.Key.Length)
                    {
                        codeString += word.Key[index];
                    }

                    else
                    {
                        codeString += " ";
                    }
                }

                Console.WriteLine($"{word.Key} == {codeString}");
            }
        }
    }
}