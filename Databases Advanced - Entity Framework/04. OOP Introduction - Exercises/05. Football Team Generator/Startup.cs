namespace _05.Football_Team_Generator
{
    using Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var teams = new HashSet<Team>();
            var args = Console.ReadLine().Split(';');
            var command = args[0];

            while (command != "END")
            {
                try
                {
                    var teamName = args[1];

                    if (command == "Team")
                    {
                        var team = new Team() { Name = teamName };
                        teams.Add(team);
                    }
                    else if (command == "Remove")
                    {
                        var playerName = args[2];
                        ValidateInput(teamName, playerName, teams, command);
                        var team = teams.First(t => t.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Add")
                    {
                        var playerName = args[2];
                        ValidateInput(teamName, playerName, teams, command);
                        var team = teams.First(t => t.Name == teamName);
                        var endurance = long.Parse(args[3]);
                        var sprint = long.Parse(args[4]);
                        var dribble = long.Parse(args[5]);
                        var passing = long.Parse(args[6]);
                        var shooting = long.Parse(args[7]);
                        var stats = new Stat(endurance, sprint, dribble, passing, shooting);
                        var player = new Player(playerName, stats);
                        team.AddPlayer(player);
                    }
                    else if (command == "Rating")
                    {
                        ValidateInput(teamName, "", teams, command);
                        var team = teams.First(t => t.Name == teamName);
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                args = Console.ReadLine().Split(';');
                command = args[0];
            }
        }

        public static ArgumentException ValidateInput(string teamName, string playerName, HashSet<Team> teams, string command)
        {
            if (!teams.Select(t => t.Name).Contains(teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
            if (command == "Remove")
            {
                var team = teams.FirstOrDefault(t => t.Name == teamName);
                if (!team.Players.Select(p => p.Name).Contains(playerName))
                {
                    throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                }
            }
            return null;
        }
    }
}