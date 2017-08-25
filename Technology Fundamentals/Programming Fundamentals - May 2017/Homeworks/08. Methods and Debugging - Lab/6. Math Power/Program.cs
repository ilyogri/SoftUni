namespace _6.Math_Power
{
    using System;

   public class MathPower
    {
        public static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double output = GetRaisedNumber(number, power);

            Console.WriteLine(output);
        }

        public static double GetRaisedNumber(double number, double power)
        {
            double output = 1;

            for (double i = 1; i <= power; i++)
            {
                output *= number;           
            }

            return output;
        }
    }
}