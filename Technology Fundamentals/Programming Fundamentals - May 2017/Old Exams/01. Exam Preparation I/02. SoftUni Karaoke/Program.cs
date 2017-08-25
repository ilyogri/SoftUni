namespace _02.SoftUni_Karaoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participantsInput = Console.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries);
            var songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            var participants = new Dictionary<string, Dictionary<string, int>>();
            var awardsLists = new HashSet<string>();
            var performanceString = Console.ReadLine();
           
            while (performanceString != "dawn")
            {
                var performance = performanceString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var currentParticipant = performance[0];
                var currentSong = performance[1];
                var award = performance[2];

                if (songs.Contains(currentSong) && participantsInput.Contains(currentParticipant))
                {
                    if (!participants.ContainsKey(currentParticipant))
                    {
                        participants[currentParticipant] = new Dictionary<string, int>();
                    }

                    if (!awardsLists.Contains(award))
                    {
                        participants[currentParticipant].Add(award, 1);
                    }

                    awardsLists.Add(award);
                }

                performanceString = Console.ReadLine();
            }

            if(participants.All(a => a.Value.Count == 0))
            {
                Console.WriteLine("No awards");
                return;
            }

            var sortedParticipants = participants
                .Where(x => x.Value.Values.Count > 0)
                .OrderByDescending(a => a.Value.Values.Count())
                .ThenBy(n => n.Key);

            foreach (var participant in sortedParticipants)
            {
                Console.WriteLine($"{participant.Key}: {participant.Value.Values.Count} awards");

                foreach (var award in participant.Value
                    .OrderBy(x => x.Key))
                {
                    Console.WriteLine($"--{award.Key}");
                }
            }
        }
    }
}