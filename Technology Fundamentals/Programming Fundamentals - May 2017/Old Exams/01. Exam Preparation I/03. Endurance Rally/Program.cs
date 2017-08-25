namespace _03.Endurance_Rally
{
    using System;
    using System.Linq;

   public class EnduranceRally
    {
        public static void Main()
        {
            var drivers = Console.ReadLine().Split(' ');
            var zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var checkPoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < drivers.Length; i++)
            {
                var startFuel = (double)drivers[i].First();

                for (int j = 0; j < zones.Length; j++)
                {
                    if (checkPoints.Contains(j))
                    {
                        startFuel += zones[j];
                    }

                    else
                    {
                        startFuel -= zones[j];
                    }

                    if(startFuel <= 0)
                    {
                        Console.WriteLine($"{drivers[i]} - reached {j}");
                        break;
                    }
                }

                if(startFuel > 0)
                {
                    Console.WriteLine($"{drivers[i]} - fuel left {startFuel:f2}");
                }
            }
        }
    }
}