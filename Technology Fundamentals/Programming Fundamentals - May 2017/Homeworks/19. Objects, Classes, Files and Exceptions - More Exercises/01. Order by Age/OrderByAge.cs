namespace _01.Order_by_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderByAge
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var personsList = new List<Person>();

            while (input != "End")
            {
                var args = input.Split();

                var name = args[0];
                var ID = args[1];
                var age = int.Parse(args[2]);

                var newPerson = new Person(name, ID, age);
                personsList.Add(newPerson);

                input = Console.ReadLine();
            }

            PrintResult(personsList);
        }

        public static void PrintResult(List<Person> personsList)
        {
            var sorted = personsList
                .OrderBy(a => a.Age);

            foreach (var person in sorted)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}