using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Reverse_an_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            var numbersArr = new int[numCount];


            for (int i = 0; i < numCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbersArr[i] = number;
            }

            for (int k = numbersArr.Length - 1; k >= 0; k--)
            {
                Console.Write(string.Join(" ", numbersArr[k]) + " ");
            }

            Console.WriteLine();

            //another solution:
            //Array.Reverse(numbersArr);
            //Console.WriteLine(string.Join(" ",numbersArr));
        }
    }
}
