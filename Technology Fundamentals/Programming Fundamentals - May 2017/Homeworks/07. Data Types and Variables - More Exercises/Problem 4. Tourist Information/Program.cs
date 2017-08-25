namespace Problem_4.Tourist_Information
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var imperialUnit = Console.ReadLine();
            var value = double.Parse(Console.ReadLine());

            var sumValue = 0.0;
            var convertedValue = string.Empty;

            switch (imperialUnit)
            {
                case "miles":
                    sumValue = value * 1.6;
                    convertedValue = "kilometers";
                    break;
                case "inches":
                    sumValue = value * 2.54;
                    convertedValue = "centimeters";
                    break;
                case "feet":
                    sumValue = value * 30;
                    convertedValue = "centimeters";
                    break;
                case "yards":
                    sumValue = value * 0.91;
                    convertedValue = "meters";
                    break;
                case "gallons":
                    sumValue = value * 3.8;
                    convertedValue = "liters";
                    break;
            }

            Console.WriteLine($"{value} {imperialUnit} = {sumValue:f2} {convertedValue}");
        }
    }
}