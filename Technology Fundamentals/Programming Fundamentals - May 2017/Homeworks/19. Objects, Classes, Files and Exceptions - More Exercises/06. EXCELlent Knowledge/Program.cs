namespace _07.Play_Catch
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PlayCatch
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var exceptionsCount = 0;

            while (exceptionsCount != 3)
            {
                var args = Console.ReadLine().Split();
                var command = args[0];

                try
                {
                    if (command == "Replace")
                    {
                        var index = int.Parse(args[1]);
                        var element = int.Parse(args[2]);
                        numbers[index] = element;
                    }

                    else if (command == "Print")
                    {
                        var startIndex = int.Parse(args[1]);
                        var endIndex = int.Parse(args[2]);

                        var elementAtStartIndex = numbers[startIndex];
                        var elementAtEndIndex = numbers[endIndex];

                        var newList = new List<int>();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            newList.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", newList));
                    }

                    else if (command == "Show")
                    {
                        var index = int.Parse(args[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}