using System;
using System.Linq;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var leftSum = 0;
            var rightSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                //storing the left side values
                for (int leftIndex = 0; leftIndex < i; leftIndex++)
                {
                    leftSum += arr[leftIndex];
                }

                //storing the right side values
                for (int rightIndex = i + 1; rightIndex < arr.Length; rightIndex++)
                {
                    rightSum += arr[rightIndex];
                }

                //if leftsum and rightsum are equal we break the loop and output the index 
                if(leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }

                //else, we reset the values of leftsum and rightsum
                leftSum = 0;
                rightSum = 0;
            }

            //if there are no equal sums:
            Console.WriteLine("no");
        }
    }
}

//Another solution with LINQ:

//using System;
//using System.Collections.Generic;
//using System.Linq;


//namespace EqualSums
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] nums = "1 2 3 3".Split(' ').Select(int.Parse).ToArray();
//            List<int> index = new List<int>();

//            var sum = 0;
//            var rightSum = 0;

//            for (int i = 0; i < nums.Length; i++)

//            if (nums.Take(i).Sum() == nums.Skip(i + 1).Take(nums.Length - i).Sum())
//                index.Add(i);

//            if (index.Count > 0)
//                Console.WriteLine(string.Join(", ", index));
//            else
//                Console.WriteLine("no");
//        }
//    }
//}