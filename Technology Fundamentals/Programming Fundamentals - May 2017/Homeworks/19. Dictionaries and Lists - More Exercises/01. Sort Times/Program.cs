namespace _01.Sort_Times
{
    using System;
    using System.Linq;

    public class SortTimes
    {
        public static void Main()
        {
            var times = Console.ReadLine().Split(' ');

            var orderedTimes = times.OrderBy(x => x);

            Console.WriteLine(string.Join(", ", orderedTimes));
        }
    }
}