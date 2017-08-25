namespace _1.Remove_Negatives_and_Reverse
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            numbers.Reverse();
            numbers.RemoveAll(x => x < 0);

            if (numbers.Count() == 0)
            {
                Console.WriteLine("empty");
                return;
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
