using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Prime_Checker
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(IsPrime(long.Parse(Console.ReadLine())));
        }

        static bool IsPrime(long number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 2; i <= boundary; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;  
        }
    }
}