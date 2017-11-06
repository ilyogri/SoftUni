namespace _07.Animals.Models
{
    public class Tomcat : Cat
    {
        public override string ProduceSound()
        {
            return "MEOW";
        }

        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }
    }
}