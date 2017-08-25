namespace _2.Append_Lists
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|').ToList();
            input.Reverse();
            input.RemoveAll(x => x == " ");
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
