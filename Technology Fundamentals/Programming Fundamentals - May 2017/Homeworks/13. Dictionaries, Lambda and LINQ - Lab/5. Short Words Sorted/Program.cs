//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _5.Short_Words_Sorted
//{
//    class Program
//    {
//        static void Main()
//        {
//            var biggestPrimeBelowOneMillion = 999983;

//            var primeNumbers = new List<int>();
//            var primeNumbersSum = primeNumbers.Sum();

//            primeNumbers.Add(2);
//            int i = 3;

//            while (primeNumbers.Sum() + i <= biggestPrimeBelowOneMillion)
//            {
//                if (IsPrime(i) == true )
//                {
//                    primeNumbers.Add(i);
//                }

//                i++;
//            }

//            Console.WriteLine(primeNumbers.Sum());
//            Console.WriteLine(primeNumbers.Count());
//            Console.WriteLine(string.Join(" + ", primeNumbers));
//        }

//        static bool IsPrime(int number)
//        {
//            var factor = number / 2;

//            for (int i = 2; i <= factor; i++)
//            {
//                if(number % i == 0)
//                {
//                    return false;
//                }
//            }

//            return true;
//        }
//    }
//}


namespace _5.Short_Words_Sorted
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] result =
                Console.ReadLine()
                .ToLower()
                .Split(new[] { '.', ',', '!', ':', ';', '(', ')', '[', ']', '/', '\\', '?', ' ', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}