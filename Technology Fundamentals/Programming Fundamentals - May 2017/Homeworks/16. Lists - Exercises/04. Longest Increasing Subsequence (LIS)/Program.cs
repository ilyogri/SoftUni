namespace _4.Longest_Increasing_Subsequence__LIS_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var bestIncreasingSubsequence = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var currentIncreasingSubseq = new List<int>();
                currentIncreasingSubseq.Add(numbers[i]);

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    var biggerNumberCheck = numbers.Skip(j + 1).Take(numbers.Count).Count(x => x > currentIncreasingSubseq.Last());

                    if (numbers[j] > currentIncreasingSubseq.Last() &&
                        (numbers.Skip(j + 1).
                        Take(numbers.Count)).
                        All(x => (x >= numbers[j] || x <= currentIncreasingSubseq.Last())))

                    {
                        currentIncreasingSubseq.Add(numbers[j]);
                    }

                    else if (biggerNumberCheck == 1)
                    {
                        currentIncreasingSubseq.Add(numbers.Skip(j).Take(numbers.Count).Max());
                    }
                }

                if (currentIncreasingSubseq.Count > bestIncreasingSubsequence.Count)
                {
                    bestIncreasingSubsequence = currentIncreasingSubseq;
                }
            }

            Console.WriteLine(string.Join(" ", bestIncreasingSubsequence));
        }
    }
}