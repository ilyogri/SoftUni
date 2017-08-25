namespace _02.Spy_Gram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SpyGram
    {
        public static void Main()
        {
            var privateKey = Console.ReadLine();
            var inputMessage = Console.ReadLine();

            var regex = new Regex(@"^TO:\s([A-Z]+);\sMESSAGE:\s[^;]+;$");
            var outgoingMessages = new Dictionary<string, List<string>>();

            while (inputMessage != "END")
            {
                var messageMatch = regex.Match(inputMessage);
                var currentEncryptedWord = new StringBuilder();

                if (messageMatch.Success)
                {
                    var keyCounter = 0;

                    for (int i = 0; i < inputMessage.Length; i++)
                    {
                        var currentPrivateKey = int.Parse(privateKey[keyCounter].ToString());
                        currentEncryptedWord.Append((char)(currentPrivateKey + inputMessage[i]));

                        keyCounter++;
                        if (keyCounter == privateKey.Length)
                        {
                            keyCounter = 0;
                        }
                    }

                    if (!outgoingMessages.ContainsKey(messageMatch.Groups[1].Value))
                    {
                        outgoingMessages[messageMatch.Groups[1].Value] = new List<string>();
                    }

                    outgoingMessages[messageMatch.Groups[1].Value].Add(currentEncryptedWord.ToString());
                }

                inputMessage = Console.ReadLine();
            }

            PrintMessages(outgoingMessages);
        }

        public static void PrintMessages(Dictionary<string, List<string>> outgoingMessages)
        {
            var sortedMessages = outgoingMessages
                .OrderBy(x => x.Key);

            foreach (var message in sortedMessages)
            {
                foreach (var item in message.Value)
                {
                    Console.WriteLine(string.Join("", item));
                }
            }
        }
    }
}