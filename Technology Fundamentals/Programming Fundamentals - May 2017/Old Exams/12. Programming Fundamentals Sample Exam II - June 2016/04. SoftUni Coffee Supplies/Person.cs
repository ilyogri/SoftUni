namespace _04.SoftUni_Coffee_Supplies
{
   public class Person
    {
        public Person(string name, string coffeeType)
        {
            this.Name = name;
            this.CoffeeType = coffeeType;
        }

        public string Name { get; set; }
        public string CoffeeType { get; set; }
    }
}