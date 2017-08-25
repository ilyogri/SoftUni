namespace _03.Immune_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ImmuneSystem
    {
        public static void Main()
        {
            var initialHealth = int.Parse(Console.ReadLine());
            var virusName = Console.ReadLine();

            var maxIntialHealth = initialHealth;
            var timeToDefeat = 0;
            var virusNamesList = new List<string>();

            while (virusName != "end")
            {
                var currentVirusStrength = virusName.Sum(x => x) / 3;

                if (!virusNamesList.Contains(virusName))
                {
                    virusNamesList.Add(virusName);
                    timeToDefeat = currentVirusStrength * virusName.Length;
                }

                else
                {
                    timeToDefeat = (currentVirusStrength * virusName.Length) / 3;
                }

                Console.WriteLine($"Virus {virusName}: {currentVirusStrength} => {timeToDefeat} seconds");

                //check if the virus is defeated

                if (initialHealth - timeToDefeat > 0)
                {
                    initialHealth -= timeToDefeat;
                    var minutesToDefeat = timeToDefeat / 60;
                    var secondsToDefeat = timeToDefeat % 60;

                    Console.WriteLine($"{virusName} defeated in {minutesToDefeat}m {secondsToDefeat}s.");
                    Console.WriteLine($"Remaining health: {initialHealth}");

                    if(initialHealth + (int)(initialHealth * 0.2) > maxIntialHealth)
                    {
                        initialHealth = maxIntialHealth;
                    }

                    else
                    {
                        initialHealth += (int)(initialHealth * 0.2);
                    }
                }

                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }

                virusName = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {initialHealth}");
        }
    }
}