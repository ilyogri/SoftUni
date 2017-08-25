using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var secondArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var biggerArray = Math.Max(firstArr.Length, secondArr.Length);
            var destinationArray = new int[biggerArray];                    //storage for the smaller array to be duplicated
            var sum = new int[biggerArray];

            for (int i = 0; i < biggerArray ; i++)
            {
                if (firstArr.Length < secondArr.Length)
                {
                    destinationArray[i] = firstArr[i % firstArr.Length];
                    sum[i] = destinationArray[i] + secondArr[i];
                }

                else
                {
                    destinationArray[i] = secondArr[i % secondArr.Length];                             //another way is this: sum[i] = 
                    sum[i] = destinationArray[i] + firstArr[i];                                        //firstArr[i % firstArr.Length] +
                }                                                                                      //secondArr[i % secondArr.Length];

                Console.Write(string.Join(" ", sum[i] + " "));                                                                                                                           
            }
            Console.WriteLine();
        }
    }
}
