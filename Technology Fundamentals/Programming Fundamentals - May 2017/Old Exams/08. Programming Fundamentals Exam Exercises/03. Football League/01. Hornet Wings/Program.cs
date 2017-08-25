namespace _01.Hornet_Wings
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var distanceInput = int.Parse(Console.ReadLine());
            var wingFlaps = double.Parse(Console.ReadLine());
            var endurance = int.Parse(Console.ReadLine());

            var distance = (distanceInput / 1000) * wingFlaps;
            var hornetFlaps = distanceInput / 100;
            var rest = (distanceInput / endurance) * 5;
            var time = hornetFlaps + rest;

            Console.WriteLine("{0:f2} m.",distance);
            Console.WriteLine("{0} s.", time);
        }
    }
}