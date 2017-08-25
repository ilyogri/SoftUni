using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool doesContains = false;
            for (int a = 0; a < numbersArr.Length; a++)
            {
                for (int b = a + 1; b < numbersArr.Length; b++)
                {
                    int sum = numbersArr[a] + numbersArr[b];
                    if (numbersArr.Contains(sum))
                    {
                        Console.WriteLine("{0} + {1} == {2}", numbersArr[a], numbersArr[b], sum);
                        doesContains = true;
                    }
                }
            }

            if(doesContains==false)
            {
                Console.WriteLine("No");
            }
        }
    }
}