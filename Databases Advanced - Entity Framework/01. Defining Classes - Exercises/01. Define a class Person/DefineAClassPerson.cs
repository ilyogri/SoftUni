namespace _01.Define_a_class_Person
{
    using System;
    using System.Reflection;

    public class DefineAClassPerson
    {
        public static void Main()
        {
            var p1 = new Person("Pesho", 20);

            var p2 = new Person() { Name = "Gosho", Age = 18 };

            var p3 = new Person();
            p3.Name = "Stamat";
            p3.Age = 43;

            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties
                (BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(properties.Length);
        }
    }
}