namespace _01.Softuni_Coffee_Orders
{
    using System;
    using System.Globalization;

    public class SoftuniCoffeeOrders
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var totalPrice = 0.0m;

            for (int i = 0; i < linesCount; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var orderDateString = Console.ReadLine();
                var capsulesCount = long.Parse(Console.ReadLine());

                var orderDate = DateTime.ParseExact(orderDateString, "d/M/yyyy", CultureInfo.InvariantCulture);
                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                var priceForCofee = ((daysInMonth * capsulesCount) * pricePerCapsule);
                totalPrice += priceForCofee;

                Console.WriteLine($"The price for the coffee is: ${priceForCofee:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}