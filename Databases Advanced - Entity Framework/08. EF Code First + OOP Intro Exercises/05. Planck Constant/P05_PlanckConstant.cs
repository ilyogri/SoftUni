namespace _05.Planck_Constant
{
    using System;

    public class P05_PlanckConstant
    {
        public static void Main()
        {
            var reducedPlankConst = Calculation.ReducePlanckConst();

            Console.WriteLine($"Reduced Plank Constant = {reducedPlankConst}");
        }
    }
}