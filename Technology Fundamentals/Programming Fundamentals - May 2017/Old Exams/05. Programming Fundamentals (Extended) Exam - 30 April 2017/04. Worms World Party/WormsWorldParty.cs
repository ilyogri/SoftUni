namespace _04.Worms_World_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WormsWorldParty
    {
        public static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, long>>(); //holds the team name & the class holds: name and score

            var inputLine = Console.ReadLine();
            while (inputLine != "quit")
            {
                var tokens = inputLine.Split(new string[] { " -> " }, StringSplitOptions.None);

                var wormName = tokens[0];
                var teamName = tokens[1];
                var wormScore = long.Parse(tokens[2]);

                if (!dict.ContainsKey(teamName))
                {
                    dict[teamName] = new Dictionary<string, long>();
                }

                if (!dict.Any(x => x.Value.Keys.Contains (wormName)))
                {
                    dict[teamName].Add(wormName, wormScore);
                }

                inputLine = Console.ReadLine();

            }

            PrintResult(dict);
        }

        public static void PrintResult(Dictionary<string, Dictionary<string, long>> dict)
        {
            var sortedTeams = dict
                .Where(x => x.Value.Values.Count() > 0)
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(x => x.Value.Values.Average());

            var count = 1;

            foreach (var team in sortedTeams)
            {
                Console.WriteLine($"{count}. Team: {team.Key} - {dict[team.Key].Values.Sum()}");
                count++;

                foreach (var worm in team.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
            }
        }
    }
}