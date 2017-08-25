namespace _15.Fast_Prime_Checker___Refactor
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

                for (int index = 2; index <= number; index++)
                {
                    bool isPrime = true;

                    for (int k = 2; k <= Math.Sqrt(index); k++)
                    {
                        if (index % k == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    Console.WriteLine($"{index} -> {isPrime}");
                }
            }
        }
    }