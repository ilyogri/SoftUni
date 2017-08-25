namespace _7.Primes_in_Given_Range
{
    using System;

   public class Program
    {
        public static void Main()
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + ", ");
                }
            }

            Console.WriteLine();
        }

        static bool IsPrime(int startNum)
        {
            if (startNum == 0 || startNum == 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Floor(Math.Sqrt(startNum)); i++)
            {
                if (startNum % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}