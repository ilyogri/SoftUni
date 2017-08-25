namespace _03.Football_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballLeague
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            var text = Console.ReadLine();

            var teamPoints = new Dictionary<string, long>();
            var teamGoals = new Dictionary<string, long>();

            while (text != "final")
            {
                var teamCounter = 0;
                var data = text.Split();
                var goals = data[2].Split(':');

                var firstTeamGoals = long.Parse(goals[0]);
                var secondTeamGoals = long.Parse(goals[1]);

                for (int i = 0; i < data.Length - 1; i++)
                {
                    var currentEncryptedTeam = data[i];
                    var indexOfPattern = currentEncryptedTeam.IndexOf(key);
                    var lastIndexOfPattern = currentEncryptedTeam.LastIndexOf(key);
                    var encryptedCurrentTeam = currentEncryptedTeam.Substring(indexOfPattern + key.Length,
                        lastIndexOfPattern - indexOfPattern);

                    var team = DescryptTeam(encryptedCurrentTeam, key);

                    if (!teamPoints.ContainsKey(team))
                    {
                        teamPoints[team] = 0;
                        teamGoals[team] = 0;
                    }

                    teamPoints[team] += GetTeamPoints(teamCounter, firstTeamGoals, secondTeamGoals);
                    teamGoals[team] += teamCounter == 0 ? firstTeamGoals : secondTeamGoals;
                    teamCounter++;
                }

                text = Console.ReadLine();
            }

            PrintLeagueStandings(teamPoints);
            PrintTop3TeamsScoredGoals(teamGoals);
        }

        public static string DescryptTeam(string team, string key)
        {
            var encryptedTeam = team
                   .Replace(key, string.Empty)
                   .ToUpper()
                   .Reverse();

            return string.Concat(encryptedTeam);
        }

        public static int GetTeamPoints(int teamCounter, long firstTeamGoals, long secondTeamGoals)
        {
            if (firstTeamGoals == secondTeamGoals)
            {
                return 1;
            }

            else
            {
                if (teamCounter == 0)
                {
                    return firstTeamGoals > secondTeamGoals ? 3 : 0;
                }

                else
                {
                    return firstTeamGoals > secondTeamGoals ? 0 : 3;
                }
            }
        }

        public static void PrintLeagueStandings(Dictionary<string, long> teamPoints)
        {
            Console.WriteLine("League standings:");
            var placeCounter = 1;

            foreach (var team in teamPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{placeCounter}. {team.Key} {team.Value}");

                placeCounter++;
            }
        }

        public static void PrintTop3TeamsScoredGoals(Dictionary<string, long> teamGoals)
        {
            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in teamGoals
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
        }
    }
}