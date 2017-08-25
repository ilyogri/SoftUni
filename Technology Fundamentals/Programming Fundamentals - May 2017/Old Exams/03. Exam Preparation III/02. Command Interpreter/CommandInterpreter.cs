namespace _02.Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().ToList();
            var input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                if (command == "reverse" || command == "sort")
                {
                    var startIndex = int.Parse(tokens[2]);
                    var count = int.Parse(tokens[4]);

                    if(startIndex < 0
                        || startIndex >= list.Count
                        || count < 0
                        || count > list.Count
                        || startIndex + count > list.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        input = Console.ReadLine();
                        continue;
                    }

                    if(command == "reverse")
                    {
                        list.Reverse(startIndex, count);
                    }

                    else if (command == "sort")
                    {
                        list = Sort(list, startIndex, count);
                    }
                }

                else if (command == "rollLeft" || command == "rollRight")
                {
                    var rollCount = int.Parse(tokens[1]);

                    if (rollCount < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        input = Console.ReadLine();
                        continue;
                    }

                    rollCount %= list.Count;

                    if (command == "rollLeft")
                    {
                        list = RollLeft(list, rollCount);
                    }

                    else if(command == "rollRight")
                    {
                        list = RollRight(list, rollCount);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", list)}]");
        }

        public static List<string> Sort(List<string> list, int startIndex, int count)
        {
            return list
                .Take(startIndex)
                .Concat(list.Skip(startIndex)
                .Take(count)
                .OrderBy(x => x))
                .Concat(list.Skip(startIndex + count)
                .Take(list.Count)).ToList();
        }

        public static List<string> RollLeft(List<string> list, int count)
        {
            return list.Skip(count).Concat(list.Take(count)).ToList();
        }

        public static List<string> RollRight(List<string> list, int count)
        {
            return list.Skip(list.Count - count).Concat(list.Take(list.Count - count)).ToList();
        }
    }
}