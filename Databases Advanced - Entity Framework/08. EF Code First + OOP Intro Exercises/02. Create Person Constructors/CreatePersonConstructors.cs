namespace _02.Create_Person_Constructors
{
    using System;
    using System.Text.RegularExpressions;

    public class CreatePersonConstructors
    {
        public static void Main()
        {
            var personData = Console.ReadLine().Split(new string[','], StringSplitOptions.RemoveEmptyEntries);
            var person = GetPerson(personData);

            Console.WriteLine(person.ToString());
        }

        public static Person GetPerson(string[] personData)
        {
            var person = new Person();
            var name = "";
            var age = 0;

            switch (personData.Length)
            {
                case 0:
                    break;
                case 2:
                    name = personData[0];
                    age = int.Parse(personData[1]);
                    person = new Person(name, age);
                    break;
                case 1:
                    if (Regex.IsMatch(personData[0], "\\d+"))
                    {
                        age = int.Parse(personData[0]);
                        person = new Person(age);
                        break;
                    }
                    name = personData[0];
                    person = new Person(name);
                    break;
            }

            return person;
        }
    }
}