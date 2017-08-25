namespace _16.Comparing_Floats
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            Console.WriteLine(eps > (Math.Max(a,b) - Math.Min(a,b)));
        }
    }
}