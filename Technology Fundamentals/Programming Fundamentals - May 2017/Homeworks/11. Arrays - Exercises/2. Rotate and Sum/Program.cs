using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());

            int counter = 0;
            var sum = new int[firstNumbers.Length];

            while (counter != k)
            {
                //rotating the arrays
                var lastElementValue = firstNumbers[firstNumbers.Length - 1];

                for (int i = firstNumbers.Length - 1; i > 0; i--)
                {
                    firstNumbers[i] = firstNumbers[i - 1];
                }

                firstNumbers[0] = lastElementValue;

                //summing the arrays
                for (int i = 0; i < firstNumbers.Length; i++)
                {
                    sum[i] += firstNumbers[i];
                }

                counter++;
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
