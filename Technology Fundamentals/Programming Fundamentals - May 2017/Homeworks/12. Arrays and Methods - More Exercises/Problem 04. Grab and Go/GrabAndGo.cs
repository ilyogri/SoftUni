namespace Problem_04.Grab_and_Go
{
    using System;
    using System.Linq;

    public class GrabAndGo
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var numberSearch = long.Parse(Console.ReadLine());

            long sum = 0;

            if (numbers.Contains(numberSearch))
            {
                var lastIndex = Array.LastIndexOf(numbers, numberSearch);
                sum = numbers.Skip(0).Take(lastIndex).Sum();

                Console.WriteLine(sum);
            }

            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}