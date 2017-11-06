namespace FootballManager.Models
{
    using System.Collections.Generic;

    public class League
    {
        public League()
        {
            this.Team = new HashSet<Team>();
        }
        
        public int LeagueId { get; set; }

        public string Name { get; set; }

        public ICollection<Team> Team { get; set; }
    }
}