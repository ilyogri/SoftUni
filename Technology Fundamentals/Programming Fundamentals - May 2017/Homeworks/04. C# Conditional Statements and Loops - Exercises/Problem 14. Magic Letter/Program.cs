﻿namespace Problem_14.Magic_Letter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstLetter = char.Parse(Console.ReadLine());
            var secondLetter = char.Parse(Console.ReadLine());
            var thirdLetter = char.Parse(Console.ReadLine());

            for (char i = firstLetter; i <= secondLetter; i++)
            {
                for (char k = firstLetter; k <= secondLetter; k++)
                {
                    for (char j = firstLetter; j <= secondLetter; j++)
                    {
                        if (i != thirdLetter && k != thirdLetter && j != thirdLetter)
                        {
                            Console.Write($"{i}{k}{j} ");
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}