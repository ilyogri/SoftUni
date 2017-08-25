namespace _03.Nether_Realms
{
    public class Demon
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}