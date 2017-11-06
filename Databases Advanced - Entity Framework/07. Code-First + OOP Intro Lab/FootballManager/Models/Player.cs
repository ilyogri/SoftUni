namespace FootballManager.Models
{
   public class Player
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}