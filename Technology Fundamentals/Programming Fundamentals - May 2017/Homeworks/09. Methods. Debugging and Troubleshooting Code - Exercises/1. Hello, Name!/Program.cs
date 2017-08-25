namespace _1.Hello__Name_
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var name = ReadName();
            Console.WriteLine($"Hello, {name}!");
        }

        public static string ReadName()
        {
            return Console.ReadLine();
        }
    }
}