namespace _02.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayManipulator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine();

            while (command != "end")
            {
                var args = command.Split();

                if (args[0] == "exchange")
                {
                    var index = int.Parse(args[1]);

                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }

                    else
                    {
                        numbers = Exchange(index, numbers);
                    }
                }

                else if (args[0] == "max" || args[0] == "min")
                {
                    Console.WriteLine(GetMaxOrMinEvenOrOddIndex(args[1], args[0], numbers));
                }

                else if (args[0] == "first" || args[0] == "last")
                {
                    var count = int.Parse(args[1]);

                    if (count > numbers.Count || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                    }

                    else
                    {
                        var evenOrOdd = args[2];
                        var sequence = FirstOrLastEvenOrOddNumbers(evenOrOdd, args[0], count, numbers);

                        Console.WriteLine($"[{string.Join(", ", sequence)}]");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        public static List<int> Exchange(int index, List<int> numbers)
        {
            var firstHalf = numbers
                .Skip(index + 1)
                .Take(numbers.Count)
                .ToList();

            var secondHalf = numbers
                .Take(index + 1)
                .ToList();

            return firstHalf
                .Concat(secondHalf)
                .ToList(); ;
        }

        public static string GetMaxOrMinEvenOrOddIndex(string evenOrOdd, string firstOrLast, List<int> numbers)
        {
            var reminder = evenOrOdd == "odd" ? 1 : 0;
            var filtered = numbers.Where(n => n % 2 == reminder).ToList();

            if (!filtered.Any())
            {
                return "No matches";
            }

            return firstOrLast == "max" ?
                numbers
                .LastIndexOf(filtered
                .Max())
                .ToString()
                : numbers
                .LastIndexOf(filtered
                .Min())
                .ToString();
        }

        public static List<int>
            FirstOrLastEvenOrOddNumbers(string evenOrOdd, string firstOrLast, int count, List<int> numbers)
        {
            var reminder = evenOrOdd == "odd" ? 1 : 0;
            var filtered = numbers.Where(n => n % 2 == reminder);

            return firstOrLast == "first" ?
                filtered.Take(count).ToList()
                : filtered.Reverse().Take(count).Reverse().ToList();
        }
    }
}