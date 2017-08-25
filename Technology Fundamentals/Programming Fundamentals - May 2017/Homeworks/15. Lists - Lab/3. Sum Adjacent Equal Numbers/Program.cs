namespace _3.Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Linq;

   public class Program
    {
      public  static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            var startIndex = 0;

            for (int i = startIndex; i < numbers.Count() - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
