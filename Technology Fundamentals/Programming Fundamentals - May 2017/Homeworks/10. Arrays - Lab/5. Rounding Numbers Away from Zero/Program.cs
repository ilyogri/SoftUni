using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rounding_Numbers_Away_from_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            double[] splittedNumbersArr = input.Split(' ').Select(double.Parse).ToArray();
            var roundednums = new double[splittedNumbersArr.Length];

            for (int i = 0; i < splittedNumbersArr.Length; i++)
            {

                Console.WriteLine(splittedNumbersArr[i] + " => " + (Math.Round(splittedNumbersArr[i], MidpointRounding.AwayFromZero)));
            }
        }
    }
}
