namespace _03.Oldest_Family_Member
{
    using System;

    public class P03_OldestFamilyMember
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());
                    
            var family = new Family();

            for (int i = 0; i < linesCount; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person() { Name = name, Age = age };
                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}