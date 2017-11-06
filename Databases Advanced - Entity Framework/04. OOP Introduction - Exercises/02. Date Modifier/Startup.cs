namespace _02.Date_Modifier
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();
            var dateModifier = new DateModifier(firstDate, secondDate);
            var daysDifference = dateModifier.CalculateDaysDifference();
            Console.WriteLine(daysDifference);
        }
    }
}