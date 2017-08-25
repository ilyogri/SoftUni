namespace _02.Odd_Filter
{
    using System;
    using System.Linq;

    public class OddFilter
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            numbers.RemoveAll(x => x % 2 != 0);

            var average = numbers.Average();

            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] > average)
                {
                    numbers[i]++;
                }

                else if (numbers[i] <= average)
                {
                    numbers[i]--;
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}