namespace Problem_11.String_Concatenation
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var delimeter = Console.ReadLine();
            var evenOrOdd = Console.ReadLine();
            var linesCount = int.Parse(Console.ReadLine());

            var list = new List<string>();

            for (int i = 1; i <= linesCount; i++)
            {
                var input = Console.ReadLine();

                if(evenOrOdd == "even" && i % 2 == 0)
                {
                    list.Add(input);
                }

                if (evenOrOdd == "odd" && i % 2 != 0)
                {
                    list.Add(input);
                }
            }

            Console.WriteLine(string.Join(delimeter, list));
        }
    }
}