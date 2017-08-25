namespace Problem_3.Back_in_30_Minutes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var hour = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            //if the hours are 23
            var formattedHours = (minutes > 29 && hour == 23) ? hour = 0 : hour;

            /* if the minutes are higher than 29 
             * the hours are increased with 1
             * if not the hours don't change */
            formattedHours = minutes > 29 && formattedHours !=0 ? hour+=1 : hour;

            /* the minutes are increased with 30
             * if the minutes are lower than sixty
             * they don't change, else -> they
             * are equal to minutes - 60 */
            var formattedMinutes = minutes > 29 ? minutes += 30 - 60 : minutes += 30;

            Console.WriteLine($"{formattedHours}:{formattedMinutes.ToString("#00")}");
        }
    }
}