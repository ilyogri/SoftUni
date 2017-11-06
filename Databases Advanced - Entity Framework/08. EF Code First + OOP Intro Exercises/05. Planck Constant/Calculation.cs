namespace _05.Planck_Constant
{
    using System;

    public class Calculation
    {
        public static double PlanckConstant = 6.62606896e-34;

        public static double Pi = Math.PI;

        public static double ReducePlanckConst()
        {
            return PlanckConstant / (2 * Pi);
        }
    }
}