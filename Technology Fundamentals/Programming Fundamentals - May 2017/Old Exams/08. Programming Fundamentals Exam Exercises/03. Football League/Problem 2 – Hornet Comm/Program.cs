namespace Problem_2___Hornet_Comm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var inputText = Console.ReadLine();

            var privateMessagesCodes = new List<string>();
            var privateMessages = new List<string>();

            var broadcastFrequency = new List<string>();
            var broadcasts = new List<string>();

            while (inputText != "Hornet is Green")
            {
                var splittedInput = Regex.Split(inputText, " <-> ");

                if (IsDigitsOnly(splittedInput[0]) && IsDigitAndOrLeter(splittedInput[1]))
                {
                    splittedInput[0] = string.Concat(splittedInput[0].Reverse());

                    privateMessagesCodes.Add(splittedInput[0]);
                    privateMessages.Add(splittedInput[1]);
                }

                else if (!IsDigitsOnly(splittedInput[0]) && IsDigitAndOrLeter(splittedInput[1]))
                {
                    broadcasts.Add(splittedInput[0]);
                    broadcastFrequency.Add(ConvertToLowerOrUpper(splittedInput[1]));
                }

                inputText = Console.ReadLine();
            }

            GetResult(privateMessagesCodes, privateMessages, broadcastFrequency, broadcasts);
        }

        static bool IsDigitsOnly(string text)
        {
            foreach (char x in text)
            {
                if (x < '0' || x > '9')
                    return false;
            }

            return true;
        }

        static bool IsDigitAndOrLeter(string text)
        {
            if (text.All(x => char.IsLetterOrDigit(x)))
            {
                return true;
            }

            return false;
        }

        static string ConvertToLowerOrUpper(string text)
        {
            var chars = text.ToArray();
            var convertedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLower(chars[i]))
                {
                    convertedText += chars[i].ToString().ToUpper();
                }


                else if (char.IsUpper(chars[i]))
                {
                    convertedText += chars[i].ToString().ToLower();
                }

                else
                {
                    convertedText += chars[i];
                }
            }

            return convertedText;
        }

        static void GetResult(List<string> privateMessagesCodes, List<string> privateMessages,
            List<string> broadcastFrequency, List<string> broadcasts)
        {
            for (int i = 0; i < privateMessagesCodes.Count(); i++)
            {
                privateMessagesCodes[i].Reverse();
            }

            Console.WriteLine("Broadcasts: ");

            if (broadcastFrequency.Count() > 0)
            {
                for (int i = 0; i < broadcastFrequency.Count(); i++)
                {
                    Console.WriteLine(broadcastFrequency[i] + " -> " + broadcasts[i]);
                }
            }

            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages: ");

            if (privateMessages.Count() > 0)
            {
                for (int i = 0; i < privateMessages.Count(); i++)
                {
                    Console.WriteLine(privateMessagesCodes[i] + " -> " + privateMessages[i]);
                }
            }

            else
            {
                Console.WriteLine("None");
            }
        }
    }
}