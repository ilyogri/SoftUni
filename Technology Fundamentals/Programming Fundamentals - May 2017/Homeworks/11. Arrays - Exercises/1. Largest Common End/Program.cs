using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(' ').ToArray();
            var secondInput = Console.ReadLine().Split(' ').ToArray();

            int sum = 0;
            int smallerLength = Math.Min(firstInput.Length, secondInput.Length);

            for (int i = 0; i < smallerLength; i++)
            {
                if(firstInput[i].Equals(secondInput[i]))
                {
                    sum++;
                }
            }


            if (sum == 0)
            {
                Array.Reverse(firstInput);
                Array.Reverse(secondInput);

                for (int k = 0; k < smallerLength; k++)
                {
                    if (firstInput[k].Equals(secondInput[k]))
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}

//using System;
//using System.Linq;

//public class LargestCommonEnd
//{
//    public static void Main()
//    {
//        string[] firstWords = "hi php java xml csharp sql html css js".Split().ToArray();
//        string[] secondWords = "nakov java sql html css js".Split().ToArray();

//        int minLength = Math.Min(firstWords.Length, secondWords.Length);          //8

//        int firstLength = GetMaxLength(firstWords, secondWords, minLength);       //8

//        Array.Reverse(firstWords);
//        Array.Reverse(secondWords);

//        int secondLength = GetMaxLength(firstWords, secondWords, minLength);       //8

//        Console.WriteLine(firstLength > secondLength ? firstLength : secondLength);
//    }

//    private static int GetMaxLength(string[] firstWords, string[] secondWords, int minLength)
//    {
//        int firstLength = 0;
//        for (int i = 0; i < minLength; i++)
//        {
//            if (firstWords[i].Equals(secondWords[i]))
//            {
//                firstLength++;
//            }
//            else
//            {
//                break;
//            }
//        }

//        return firstLength;
//    }
//}
