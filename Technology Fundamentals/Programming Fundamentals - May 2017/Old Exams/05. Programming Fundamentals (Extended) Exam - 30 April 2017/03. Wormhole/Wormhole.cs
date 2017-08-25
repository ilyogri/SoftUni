namespace _03.Wormhole
{
    using System;
    using System.Linq;

   public class Wormhole
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var steps = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if(numbers[i] != 0)
                {
                    var positionToMove = numbers[i];
                    numbers[i] = 0;
                    i = positionToMove;
                }

                steps++;
            }

            Console.WriteLine(steps);
        }
    }
}