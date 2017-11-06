namespace _07.Gringotts_Database
{
    using System.Data.Entity;
    using Models;

    public partial class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }

        public virtual DbSet<WizardDeposit> WizardDeposit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
