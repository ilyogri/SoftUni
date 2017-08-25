namespace Problem_10.Sum_of_Chars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var sum = 0;

            for (int i = 0; i < linesCount; i++)
            {
                var input = Console.ReadLine().ToCharArray();

                sum += input[0];
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}