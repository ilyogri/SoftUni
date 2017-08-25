namespace _01.Order_by_Age
{
   public class Person
    {
        public Person (string name, string ID, int age)
        {
            this.Name = name;
            this.ID = ID;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}