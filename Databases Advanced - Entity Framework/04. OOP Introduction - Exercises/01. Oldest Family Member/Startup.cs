namespace _01.Oldest_Family_Member
{
    using System;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            var family = new Family();
            var personsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < personsCount; i++)
            {
                var personInfo = Console.ReadLine().Split();
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var person = new Person(name,age);
                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}