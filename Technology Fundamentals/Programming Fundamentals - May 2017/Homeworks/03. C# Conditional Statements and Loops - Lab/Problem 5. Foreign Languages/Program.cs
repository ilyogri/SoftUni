namespace Problem_5.Foreign_Languages
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var country = Console.ReadLine();

            if (country == "England" || country == "USA")
            {
                Console.WriteLine("English");
            }

            else if (country == "Spain" || country == "Argentina" || country == "Mexico")
            {
                Console.WriteLine("Spanish");
            }

            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}