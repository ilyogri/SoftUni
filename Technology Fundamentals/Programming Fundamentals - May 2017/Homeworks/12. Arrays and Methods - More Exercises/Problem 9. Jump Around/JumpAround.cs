namespace Problem_9.Jump_Around
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class JumpAround
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var sum = 0;
            var currentIndex = numbers[0];
            var lastIndex = 0;

            while (true)
            {
                //check if the shift to array is possible
                if (lastIndex + currentIndex >= numbers.Length)
                {
                    lastIndex -= currentIndex;
                }

                //check if the shift to left is possible
                else
                {
                    lastIndex += currentIndex;
                }

                sum += currentIndex;

                //if both of the shifts are not possible the loop ends
                if (lastIndex < 0)
                {
                    break;
                }

                currentIndex = numbers[lastIndex];
            }

            Console.WriteLine(sum);
        }
    }
}