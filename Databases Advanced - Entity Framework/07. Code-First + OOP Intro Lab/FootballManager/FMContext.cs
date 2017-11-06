using System.Collections.Generic;
using FootballManager.Models;

namespace FootballManager
{
    using System.Data.Entity;

    public class FMContext : DbContext
    {
        public FMContext()
            : base("FootballManagerContext") { }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<League> Leagues { get; set; }
    }
}