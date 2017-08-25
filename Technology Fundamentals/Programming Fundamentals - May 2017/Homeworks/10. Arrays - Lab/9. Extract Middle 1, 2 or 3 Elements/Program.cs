using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Extract_Middle_1__2_or_3_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (IsLengthEqualToOne(numbers))                                                         
            {
                Console.WriteLine("{ " + string.Join(" ", numbers) + " }");
            }
            
            
            else if (IsLengthEvenOrOdd(numbers))                                         
            {
                Console.WriteLine("{ " + numbers[(numbers.Length / 2) - 1] + ", " + numbers[(numbers.Length) / 2] + " }");
            }

            else                                                                            
            {
                Console.WriteLine("{ " + numbers[(numbers.Length / 2) - 1] + ", " + numbers[numbers.Length / 2] + ", " + numbers[(numbers.Length / 2) + 1] + " }");
            }
        }

        static bool IsLengthEvenOrOdd(int[] numbers)
        {
            if(numbers.Length % 2 == 0)
            {
                return true;
            }

            return false;
        }

        static bool IsLengthEqualToOne(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return true;
            }

            return false;
        }
    }
}