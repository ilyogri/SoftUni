namespace ConsoleApplication8
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var reversedSum = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                var reversed = 0;
                var reminder = 0;

                while (input[i] > 0)
                {
                    reminder = input[i] % 10;
                    reversed = (reversed * 10) + reminder;
                    input[i] /= 10;
                }

                reversedSum += reversed;
            }

            Console.WriteLine(reversedSum);
        }
    }
}

/* another working solution
 * 
using System;
using System.Collections.Generic;
using System.Linq;

public class SumReversedNumbers
{
    public static void Main()
    {
        List<string> numbersAsStr = Console.ReadLine().Split().ToList();

        for (int i = 0; i < numbersAsStr.Count; i++)
        {
            char[] digits = numbersAsStr[i].ToCharArray();
            Array.Reverse(digits);
            string currentNum = new string(digits);
            numbersAsStr[i] = currentNum;
        }

        int sum = numbersAsStr.Sum(x => int.Parse(x));

        Console.WriteLine(sum);
    }
}
*/
