////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace _3.Last_K_Numbers_Sums_Sequence
////{
////    class Program
////    {
////        private static int length;

////        static void Main(string[] args)
////        {
////            //int numCount = int.Parse(Console.ReadLine());
////            //int k = int.Parse(Console.ReadLine());

////            //var numbersArray = new int[numCount];

////            //for (int i = 0; i < numCount; i++)
////            //{
////            //    int num = int.Parse(Console.ReadLine());
////            //    numbersArray[i] = num;
////            //}
////            var k = 3;
////            var numbers = new int[6];

////            numbers[0] = 1;

////            for (int i = 1; i < numbers.Length; i++)
////            {
////                for (int p = i- k; p < i-1; p++)
////                {
////                    Console.WriteLine(p);
////                }
////            }
////        }
////    }
////}




//using System;

//public class LastKNumbersSums
//{
//    public static void Main()
//    {
//        int n = 6;// int.Parse(Console.ReadLine());
//        int k = 3;// int.Parse(Console.ReadLine());

//        long[] arr = new long[n];
//        arr[0] = 1;
//        for (int i = 1; i < n; i++)
//        {                                                                                          // i-k (startIndex) = 0, 1
//            arr[i] = SumNum(arr, i - k, i - 1);                                                    // i - 1(endIndex) = 0, 1,2,3,4
//            //Console.WriteLine(i - 1);
//        }
//         Console.WriteLine(string.Join(" ", arr));    
//    }

//    private static long SumNum(long[] arr, int startIndex, int endIndex)
//    {
//        long sum = 0;

//        for (int i = startIndex; i <= endIndex; i++)
//        {
//            if (i >= 0)
//            {
//                sum += arr[i];

//                //Console.Write(i + " ");
//            }
//        }
//        //Console.WriteLine();
//        return sum;
//    }
//}

using System;
using System.Linq;

namespace Program
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var sequence = new int[n];

            sequence[0] = 1;

            for (int i = 1; i < n; i++)
            {
                sequence[i] = Sum(sequence, i - k, i - 1);
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        public static int Sum(int[] sequence, int startIndex, int endIndex)
        {
            int sum = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i >= 0)
                {
                    sum += sequence[i];
                }
            }

            return sum;
        }
    }
}