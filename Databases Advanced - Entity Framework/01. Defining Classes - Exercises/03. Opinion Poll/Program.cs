namespace _03.Opinion_Poll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var personList = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var newPersonData = Console.ReadLine().Split();
                var name = newPersonData[0];
                var age = int.Parse(newPersonData[1]);
                var person = new Person(name, age);
                personList.Add(person);
            }

            foreach (var p in personList.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}