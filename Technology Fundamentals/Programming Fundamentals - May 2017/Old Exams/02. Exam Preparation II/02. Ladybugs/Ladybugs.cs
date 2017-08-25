namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    public class Ladybugs
    {
        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var inputLadyBugIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var arr = new int[fieldSize];

            foreach (var index in inputLadyBugIndexes)
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = 1;
                }
            }

            var command = Console.ReadLine();
            while (command != "end")
            {
                var args = command.Split();

                var ladyBugIndex = int.Parse(args[0]);
                var direction = args[1];
                var flyLength = int.Parse(args[2]);

                if (ladyBugIndex >= 0 && ladyBugIndex < arr.Count() && arr[ladyBugIndex] == 1)
                {
                    LadyBugFly(arr, ladyBugIndex, flyLength, direction);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        public static void LadyBugFly(int[] arr, int ladyBugIndex, int flyLength, string direction)
        {
            var newCellFound = false;
            arr[ladyBugIndex] = 0;

            while (!newCellFound)
            {
                switch (direction)
                {
                    case "right":
                        ladyBugIndex += flyLength;
                        break;
                    case "left":
                        ladyBugIndex -= flyLength;
                        break;
                }

                if(ladyBugIndex < 0 || ladyBugIndex >= arr.Length)
                {
                    break;
                }

                if(arr[ladyBugIndex] == 0)
                {
                    arr[ladyBugIndex] = 1;
                    break;
                }

                if(arr[ladyBugIndex] == 1)
                {
                    continue;
                }
            }
        }
    }
}