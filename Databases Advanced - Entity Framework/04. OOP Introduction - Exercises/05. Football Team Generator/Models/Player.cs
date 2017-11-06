namespace _05.Football_Team_Generator.Models
{
    using System;

    public class Player
    {
        private string name;
        private Stat stats;

        public Player(string name, Stat stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stat Stats
        {
            get
            {
                return this.stats;
            }
            set
            {
                this.stats = value;
            }
        }
    }
}