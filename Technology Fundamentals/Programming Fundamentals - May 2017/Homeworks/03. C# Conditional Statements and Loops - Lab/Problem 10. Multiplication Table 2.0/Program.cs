namespace Problem_10.Multiplication_Table_2._0
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var multiplyCount = int.Parse(Console.ReadLine());

            if(multiplyCount > 10)
            {
                Console.WriteLine($"{number} X {multiplyCount} = {number * multiplyCount}");
                return;
            }

            for (int i = multiplyCount; i <= 10; i++)
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }
        }
    }
}