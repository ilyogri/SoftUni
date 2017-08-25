namespace _10.Centuries_to_Nanoseconds
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());

            var years = centuries * 100;
            var days = (BigInteger)(years * 365.242);
            var hours = days * 24;
            var minutes = hours * 60;
            var seconds = minutes * 60;
            var milliseconds = seconds * 1000;
            var microseconds = milliseconds * 1000;
            var nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds", centuries,years,days,hours,minutes,seconds, milliseconds, microseconds,nanoseconds);
        }
    }
}