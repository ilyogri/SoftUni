namespace _01.SoftUni_Airline
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SoftUniAirline
    {
       public static void Main()
        {
            var flightsCount = int.Parse(Console.ReadLine());

            var overallProfit = 0.0m;

            for (int i = 0; i < flightsCount; i++)
            {
                var adultPassengersCount = decimal.Parse(Console.ReadLine());
                var adultTicketPrice = decimal.Parse(Console.ReadLine());
                var youthPassengersCount = decimal.Parse(Console.ReadLine());
                var youthTicketPrice = decimal.Parse(Console.ReadLine());
                var fuelPricePerHour = decimal.Parse(Console.ReadLine());
                var fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                var flightDuration = decimal.Parse(Console.ReadLine());

                var income = (adultPassengersCount * adultTicketPrice) + (youthPassengersCount * youthTicketPrice);
                var expenses = flightDuration * fuelConsumptionPerHour * fuelPricePerHour;

                var profit = income - expenses;

                if(income >= expenses)
                {
                    Console.WriteLine($"You are ahead with {profit:f3}$.");
                }

                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {profit:f3}$.");
                }

                overallProfit += profit;
            }

            Console.WriteLine($"Overall profit -> {overallProfit:f3}$.");
            Console.WriteLine($"Average profit -> {(overallProfit / flightsCount):f3}$.");
        }
    }
}