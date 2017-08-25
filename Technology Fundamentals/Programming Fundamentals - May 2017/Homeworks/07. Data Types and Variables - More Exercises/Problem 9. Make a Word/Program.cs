namespace Problem_9.Make_a_Word
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                var input = Console.ReadLine();

                sb.Append(input);
            }

            Console.WriteLine($"The word is: {sb.ToString()}");
        }
    }
}