namespace _10.Price_Change_Alert
{
    using System;

    public class PriceChangeAlert
    {
        public static void Main()
        {
            double numberPrices = double.Parse(Console.ReadLine());
            double significanceThreshold = double.Parse(Console.ReadLine());
            double lastPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < numberPrices - 1; i++)
            {
                double currentPrices = double.Parse(Console.ReadLine());
                double difference = ProcentDifference(lastPrice, currentPrices);
                bool isSignificantDifference = IsThereDiff(difference, significanceThreshold);

                string message = Get(currentPrices, lastPrice, difference, isSignificantDifference);

                lastPrice = currentPrices;

                Console.WriteLine(message);

            }
        }

        public static string Get(double currentPrices, double lastPrice, double difference, bool etherTrueOrFalse)
        {
            string output = string.Empty;

            if (difference == 0)
            {
                output = string.Format("NO CHANGE: {0}", currentPrices);
            }

            else if (!etherTrueOrFalse)
            {
                output = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrices, difference * 100);
            }

            else if (etherTrueOrFalse && (difference > 0))
            {
                output = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrices, difference * 100);
            }

            else if (etherTrueOrFalse && (difference < 0))
            {
                output = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrices, difference * 100);
            }

            return output;
        }

        public static bool IsThereDiff(double difference, double significanceThreshold)
        {
            if (Math.Abs(difference) >= significanceThreshold)
            {
                return true;
            }

            return false;
        }

        public static double ProcentDifference(double lastPrice, double currentPrice)
        {
            double difference = (currentPrice - lastPrice) / lastPrice;

            return difference;
        }
    }
}