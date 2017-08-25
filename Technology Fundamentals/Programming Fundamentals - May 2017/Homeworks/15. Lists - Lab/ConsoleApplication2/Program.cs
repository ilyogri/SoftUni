using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }

            var text = input.Split(' ').ToList();

            var collection = Console.ReadLine().Split(' ').ToList();
            var command = collection[0];

            TryAgain:
            try
            {
                while (true)
                {
                    command = collection[0];

                    if (command == "reverse" || command == "sort")
                    {
                        var index = int.Parse(collection[2]);
                        var count = int.Parse(collection[4]);
                        ReverseOrSort(command, text, index, count);
                    }

                    else if (command == "rollLeft" || command == "rollRight")
                    {
                        var count = int.Parse(collection[1]);
                        RollLeftOrRight(command, text, count);
                    }

                    else if (command == "end")
                    {
                        Console.WriteLine($"[{string.Join(", ", text)}]");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                    collection = Console.ReadLine().Split(' ').ToList();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Invalid input parameters.");
                collection = Console.ReadLine().Split(' ').ToList();
                goto TryAgain;
            }
        }

        static void ReverseOrSort(string command, List<string> text, int index, int count)
        {
            switch (command)
            {
                case "sort":
                    var sortedElements = new List<string>();

                    for (int i = index; i < count + index; i++)
                    {
                        sortedElements.Add(text[i]);
                    }

                    sortedElements.Sort();

                    text.RemoveRange(index, count);
                    text.InsertRange(index, sortedElements);
                    break;

                case "reverse":
                    text.Reverse(index, count);
                    break;
            }
        }

        static void RollLeftOrRight(string command, List<string> text, int shift)
        {
            switch (command)
            {
                case "rollLeft":
                    shift = shift % text.Count();

                    for (int count = 0; count < shift; count++)
                    {
                        text.Insert(text.Count(), text[0]);
                        text.Remove(text[0]);
                    }

                    break;

                case "rollRight":
                    shift = shift % text.Count();

                    for (int count = 0; count < shift; count++)
                    {
                        text.Insert(0, text[text.Count() - 1]);
                        text.RemoveAt(text.Count() - 1);
                    }

                    break;
            }
        }
    }
}
