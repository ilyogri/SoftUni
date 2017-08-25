namespace _02.Hornet_Comm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class HornetComm
    {
        public static void Main()
        {
            var broadcasts = new Dictionary<string, string>();
            var privateMessages = new Dictionary<string, string>();

            var regInput = new Regex(@"^\w+\s<->\s\w+$");
            var regPrivMessages = new Regex(@"^([\d]+)\s<->\s([A-Za-z\d]+)$");
            var regBroadcasts = new Regex(@"^([\D]+)\s<->\s([A-Za-z\d]+)$");
            var broadcastsList = new List<Broadcast>();
            var privMessagesList = new List<PrivateMessage>();

            var input = Console.ReadLine();
            while (input != "Hornet is Green")
            {
                var matchPrivMessages = regPrivMessages.Match(input);
                var matchBroadcasts = regBroadcasts.Match(input);

                if (matchPrivMessages.Success)
                {
                    privMessagesList.Add(AddPrivateMessage(matchPrivMessages));
                }

                else if (matchBroadcasts.Success)
                {

                    broadcastsList.Add(AddBroadcast(matchBroadcasts));
                }

                input = Console.ReadLine();
            }

            PrintResult(broadcastsList, privMessagesList);
        }

        public static PrivateMessage AddPrivateMessage(Match privMessageMatch)
        {
            var recipientCode = string.Concat(privMessageMatch
                        .Groups[1]
                        .ToString()
                        .Reverse());

            var message = privMessageMatch
                .Groups[2]
                .ToString();

            return new PrivateMessage(recipientCode, message);
        }

        public static Broadcast AddBroadcast(Match broadCastMatch)
        {
            var message = broadCastMatch
                        .Groups[1]
                        .Value
                        .ToString();

            var frequency = broadCastMatch
                .Groups[2]
                .Value
                .ToString();

            var convertedFrequency = new StringBuilder();

            for (int i = 0; i < frequency.Length; i++)
            {
                if (char.IsLower(frequency[i]))
                {
                    convertedFrequency.Append(frequency[i].ToString().ToUpper());
                }

                else if (char.IsUpper(frequency[i]))
                {
                    convertedFrequency.Append(frequency[i].ToString().ToLower());
                }

                else
                {
                    convertedFrequency.Append(frequency[i]);
                }
            }

            return new Broadcast(message, convertedFrequency.ToString());
        }

        public static void PrintResult(List<Broadcast> broadcasts, List<PrivateMessage> privMessages)
        {
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }

            foreach (var broadcast in broadcasts)
            {
                Console.WriteLine($"{broadcast.Frequency} -> {broadcast.Message}");
            }

            Console.WriteLine("Messages:");
            if (privMessages.Count == 0)
            {
                Console.WriteLine("None");
            }

            foreach (var data in privMessages)
            {
                Console.WriteLine($"{data.RecipientCode} -> {data.Message}");
            }
        }
    }
}