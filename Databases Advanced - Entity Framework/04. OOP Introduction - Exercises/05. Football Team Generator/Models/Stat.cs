namespace _05.Football_Team_Generator.Models
{
    using System;

    public class Stat
    {
        private long endurance;
        private long sprlong;
        private long dribble;
        private long passing;
        private long shooting;

        public Stat(long endurance, long sprlong, long dribble, long passing, long shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprlong;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public long Endurance
        {
            get { return this.endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }

        public long Sprint
        {
            get { return this.sprlong; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprlong should be between 0 and 100.");
                }
                this.sprlong = value;
            }
        }

        public long Dribble
        {
            get { return this.dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }

        public long Passing
        {
            get { return this.passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }

        public long Shooting
        {
            get { return this.shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }
    }
}