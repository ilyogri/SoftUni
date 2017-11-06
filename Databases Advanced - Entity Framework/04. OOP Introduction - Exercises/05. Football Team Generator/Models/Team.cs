namespace _05.Football_Team_Generator.Models
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Team
    {
        private HashSet<Player> players = new HashSet<Player>();
        private string name;
        private int rating;

        public Team()
        {
            this.Name = name;
            this.Players = players;
            this.Rating = rating;
        }

        public HashSet<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Rating
        {
            get { return GetTeamRating(); }
            set
            {
                this.rating = GetTeamRating();

            }
        }

        private int GetTeamRating()
        {
            var teamRating = players.Count > 0
                ? (int)Math.Round((this.players.Sum(p =>
                                      p.Stats.Shooting + p.Stats.Dribble + p.Stats.Endurance + p.Stats.Passing +
                                      p.Stats.Sprint)) / (5.0 * this.players.Count))
                : 0;
            return teamRating;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var playerToRemove = this.players.First(p => p.Name == playerName);
            this.players.Remove(playerToRemove);
        }
    }
}