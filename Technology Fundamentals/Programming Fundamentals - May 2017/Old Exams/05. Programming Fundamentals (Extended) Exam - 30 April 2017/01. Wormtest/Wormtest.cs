namespace _01.Wormtest
{
    using System;

    public class Wormtest
    {
        public static void Main()
        {
            var wormsLength = long.Parse(Console.ReadLine()) * 100;
            var wormsWidth = float.Parse(Console.ReadLine());

            var divison = wormsLength % wormsWidth;
            if (divison == 0 || wormsWidth == 0)
            {
                Console.WriteLine("{0:f2}", wormsWidth * wormsLength);
                return;
            }

            Console.WriteLine("{0:f2}%", (wormsLength / wormsWidth) * 100);
        }
    }
}