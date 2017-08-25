namespace ConsoleApplication8
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            ////input the numbers
            //var inputNumbers = Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .ToList();

            //while (true)
            //{
            //    //input command
            //    var command = Console.ReadLine()
            //        .Split(' ')
            //        .ToList();

            //    if (command[0] == "add")
            //    {
            //        var index = int.Parse(command[1]);
            //        var number = int.Parse(command[2]);

            //        inputNumbers.Insert(index, number);
            //    }

            //    else if (command[0] == "contains")
            //    {
            //        var number = int.Parse(command[1]);

            //        //if the given number equals number from the input numbers
            //        Console.WriteLine(inputNumbers.IndexOf((number)));
            //    }

            //    else if (command[0] == "remove")
            //    {
            //        var number = int.Parse(command[1]);

            //        inputNumbers.RemoveAt(number); //"RemoveAt" removes the number at the given index and shift the list to the left     
            //    }

            //    else if (command[0] == "addMany")
            //    {
            //        var index = int.Parse(command[1]);

            //        var elements = command.Skip(2)
            //            .Take(command.Count())
            //            .Select(int.Parse)
            //            .ToList(); //stores the command numbers

            //        inputNumbers.InsertRange(index, elements); //at the given index transfers the command numbers
            //    }

            //    else if (command[0] == "shift")
            //    {
            //        var shiftCounter = int.Parse(command[1]);

            //        shiftCounter = shiftCounter % inputNumbers.Count;

            //        for (int index = 0; index < shiftCounter; index++)
            //        {
            //            //moving the first number after the last
            //            inputNumbers.Insert(inputNumbers.Count(), inputNumbers[0]);

            //            //then we remove the first number
            //            inputNumbers.Remove(inputNumbers[0]);
            //        }
            //    }

            //    else if (command[0] == "sumPairs")
            //    {
            //        for (int i = 0; i < inputNumbers.Count() - 1; i++)
            //        {
            //            inputNumbers[i + 1] = inputNumbers[i] + inputNumbers[i + 1];
            //            inputNumbers.RemoveAt(i);
            //        }
            //    }

            //    else if (command[0] == "print")
            //    {
            //        Console.WriteLine("[" + string.Join(", ", inputNumbers) + "]");
            //        break;
            //    }
            // }

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var unsplittedCommand = Console.ReadLine().Split(' ');

            while (unsplittedCommand[0] != "print")
            {
                var command = unsplittedCommand[0];

                if (command == "add")
                {
                    var index = int.Parse(unsplittedCommand[1]);
                    var element = int.Parse(unsplittedCommand[2]);

                    numbers.Insert(index, element);
                }

                else if (command == "addMany")
                {
                    var index = int.Parse(unsplittedCommand[1]);
                    var elements = unsplittedCommand.Skip(2)
                        .Take(unsplittedCommand.Count())
                        .Select(int.Parse)
                        .ToList();

                    numbers.InsertRange(index, elements);
                }

                else if (command == "contains")
                {
                    var element = int.Parse(unsplittedCommand[1]);

                    Console.WriteLine(numbers.IndexOf(element));
                }

                else if (command == "shift")
                {
                    var shifts = int.Parse(unsplittedCommand[1]);
                    shifts %= numbers.Count();

                    var numbersToShift = numbers.Skip(0).Take(shifts).ToList();
                    numbers.InsertRange(numbers.Count(), numbersToShift);
                    numbers.RemoveRange(0, shifts);
                }

                else if (command == "remove")
                {
                    var element = int.Parse(unsplittedCommand[1]);

                    numbers.RemoveAt(element);
                }

                else if (command == "sumPairs")
                {
                    var tempList = new List<int>();

                    for (int i = 0; i < numbers.Count - 1; i += 2)
                    {
                        tempList.Add(numbers[i] + numbers[i + 1]);
                    }

                    if (numbers.Count % 2 != 0)
                    {
                        tempList.Add(numbers.Last());
                    }

                    numbers = tempList;
                }

                unsplittedCommand = Console.ReadLine().Split(' ');
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}