namespace _01.Define_a_class_Person
{
    using System;

    public class DefineAClassPerson
    {
        public static void Main()
        {
            var p1 = new Person("Pesho", 20);
            Console.WriteLine(p1.ToString());

            var p2 = new Person() { Name = "Gosho", Age = 18 };
            Console.WriteLine(p2.ToString());

            var p3 = new Person();
            p3.Name = "Stamat";
            p3.Age = 43;
            Console.WriteLine(p3.ToString());
        }
    }
}