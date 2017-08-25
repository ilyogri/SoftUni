namespace _03.Spyfer
{
    using System;
    using System.Linq;

    public class SpyGram
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0)
                {
                    if (numbers[i + 1] == numbers[i])
                    {
                        numbers.RemoveAt(i + 1);
                        i = 0;
                    }
                }

                else if (i == numbers.Count - 1)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        numbers.RemoveAt(i - 1);
                        i = 0;
                    }
                }

                else if (numbers[i - 1] + numbers[i + 1] == numbers[i])
                {
                    numbers.RemoveAt(i - 1);
                    numbers.RemoveAt(i);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}