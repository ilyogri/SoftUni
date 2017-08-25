using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Reverse_an_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inputArray = input.Split(' ').ToArray();

            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                Console.Write(string.Join(" ", inputArray[i] + " "));
            }

            Console.WriteLine();
        }
    }
}
