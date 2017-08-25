//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _8.Condense_Array_to_Number
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

//            int i = 0;

//            while (numbersArray.Length > 1)
//            {
//                var condenced = new int[numbersArray.Length - 1];

//                while (i != condenced.Length)
//                {
//                    condenced[i] = numbersArray[i] + numbersArray[i + 1];
//                    i++;
//                }
//                numbersArray = condenced;
//                i = 0;
//            }

//            Console.WriteLine(numbersArray[0]);
//        }
//    }
//}

using System;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int i = 0;

            while(numbers.Length > 1)
            {
                var condenced = new int[numbers.Length - 1];

                while (condenced.Length != i)
                {
                    condenced[i] = numbers[i] + numbers[i + 1];
                    i++;
                }

                numbers = condenced;
                i = 0;
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}