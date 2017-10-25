using System;

namespace _02.Create_Person_Constructors
{
    public class Program
    {
        public static void Main()
        {
            var input1 = Console.ReadLine().Split(',');
            var name = input1[0];
            var age = int.Parse(input1[1]);
            var p1 = new Person(name, age);
            Console.WriteLine(p1.ToString());

            var input2 = Console.ReadLine().Split(',');
            name = input2[0];
            var p2 = new Person(name);
            Console.WriteLine(p2.ToString());

            var input3 = Console.ReadLine().Split(',');
            age = int.Parse(input3[0]);
            var p3 = new Person(age);
            Console.WriteLine(p3.ToString());

            var input4 = Console.ReadLine().Split(',');
            var p4 = new Person();
            Console.WriteLine(p4.ToString());
        }
    }
}