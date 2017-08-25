namespace _8.Multiply_Evens_by_Odds
{
    using System;

   public class MultiplyEvensByOdds
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(MultiplyEvensbyOdds(number));
        }

        public static int MultiplyEvensbyOdds(int number)
        {
            int digit = 0;
            int evenSum = 0;
            int oddSum = 0;

            while (number != 0)
            {
                digit =  number % 10;
                number /= 10;

                if (digit % 2 == 0)
                {
                    evenSum += digit;
                }

                else
                {
                    oddSum += digit;
                }
            }

            return evenSum * oddSum;
        }
    }
}