namespace _02.Lady_Bugs
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizeList = int.Parse(Console.ReadLine());
            var inputLadybugIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var param = Console.ReadLine().Split(' ').ToArray();

            var field = new int[sizeList];

            //setting the indexes of the ladybugs
            foreach (var index in inputLadybugIndexes)
            {
                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            while (param[0] != "end")
            {
                var ladybugIndex = int.Parse(param[0]);
                var direction = param[1];
                var flyLength = int.Parse(param[2]);

                if(flyLength < 0)
                {
                    switch (direction)
                    {
                        case "left":
                            direction = "right";
                            break;

                        case "right":
                            direction = "left";
                            break;
                    }
                }

                //if there is a ladybug at the inputted index:
                if (ladybugIndex >= 0 && ladybugIndex < field.Length && field[ladybugIndex] == 1)
                {
                    field[ladybugIndex] = 0;

                    if (direction == "right")
                    {
                        MoveToRight(flyLength, ladybugIndex, field);
                    }

                    else
                    {
                        MoveToLeft(flyLength, ladybugIndex, field);
                    }
                }

                param = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", field));
        }

        static void MoveToRight(int flyLength, int ladybugIndex, int[] field)
        {
            while (ladybugIndex + Math.Abs(flyLength) < field.Length)
            {
                if (field[ladybugIndex + Math.Abs(flyLength)] != 1)
                {
                    field[ladybugIndex + Math.Abs(flyLength)] = 1;
                    break;
                }

                ladybugIndex = flyLength + 1;
            }

            //flyLength = Math.Abs(flyLength);
            //for (int i = ladybugIndex + flyLength; i < field.Length; i = i + flyLength)
            //{
            //    if (field[i] == 0)
            //    {
            //        field[i] = 1;
            //        break;
            //    }
            //}
        }


        static void MoveToLeft(int flyLength, int ladybugIndex, int[] field)
        {
            while (ladybugIndex - Math.Abs(flyLength) < field.Length && ladybugIndex - flyLength >= 0)
            {
                if (field[ladybugIndex - Math.Abs(flyLength)] != 1)
                {
                    field[ladybugIndex - Math.Abs(flyLength)] = 1;
                    break;
                }

                ladybugIndex = flyLength - 1;
            }

            //flyLength = Math.Abs(flyLength);
            //for (int i = ladybugIndex - flyLength; i >= 0; i = i - flyLength)
            //{
            //    if (field[i] == 0)
            //    {
            //        field[i] = 1;
            //        break;
            //    }
            //}
        }
    }
}