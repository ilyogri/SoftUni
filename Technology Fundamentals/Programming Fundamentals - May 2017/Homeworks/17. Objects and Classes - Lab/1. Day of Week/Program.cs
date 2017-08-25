namespace _1.Day_of_Week
{
    using System;
    using System.Globalization;

    public class Program
    {
        public static void Main()
        {
            var dateAsString = Console.ReadLine();

            var date = DateTime.ParseExact(dateAsString, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}