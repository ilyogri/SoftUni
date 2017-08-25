namespace _3.Sum_Min_Max_Average
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbersCount = int.Parse(Console.ReadLine());

            var numbersArr = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                numbersArr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Sum = {numbersArr.Sum()}");
            Console.WriteLine($"Min = {numbersArr.Min()}");
            Console.WriteLine($"Max = {numbersArr.Max()}");
            Console.WriteLine($"Average = {numbersArr.Average()}");
        }
    }
}
