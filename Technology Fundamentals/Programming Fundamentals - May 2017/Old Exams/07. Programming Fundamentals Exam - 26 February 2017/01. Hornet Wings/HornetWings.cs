namespace _01.Hornet_Wings
{
    using System;

    public class HornetWings
    {
        public static void Main()
        {
            var wingFlaps = long.Parse(Console.ReadLine());
            var distance = double.Parse(Console.ReadLine());
            var endurance = long.Parse(Console.ReadLine());

            var metersTraveled = (wingFlaps / 1000) * distance;
            var flapsWithoutRest = wingFlaps / 100;
            var flapsWithRest = (wingFlaps / endurance) * 5;
            var secondsPassed = flapsWithoutRest + flapsWithRest;

            Console.WriteLine($"{metersTraveled:f2} m.");
            Console.WriteLine($"{secondsPassed} s.");
        }
    }
}