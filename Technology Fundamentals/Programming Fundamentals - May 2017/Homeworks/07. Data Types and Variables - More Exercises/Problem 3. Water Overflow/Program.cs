namespace Problem_3.Water_Overflow
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var sum = 0;

            for (int i = 0; i < linesCount; i++)
            {
                var number = int.Parse(Console.ReadLine());
                
                if(sum + number <= 255)
                {
                    sum += number;
                }

                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(sum);
        }
    }
}