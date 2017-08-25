namespace _02.SoftUni_Water_Supplies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var totalWater = decimal.Parse(Console.ReadLine());
            var bottles = Console.ReadLine()
                .Split()
                .Select(decimal.Parse)
                .ToArray();

            var bottleCapacity = decimal.Parse(Console.ReadLine());

            var bottlesLeftCount = 0.0m;
            var indexList = new List<decimal>();
            var totalNeededLiters = 0.0m;

            if (totalWater % 2 == 0)
            {
                for (int i = 0; i < bottles.Length; i++)
                {
                    var litersNeeded = bottleCapacity - bottles[i];

                    if (litersNeeded > 0)
                    {
                        if (totalWater - litersNeeded >= 0)
                        {
                            totalWater -= litersNeeded;
                            bottles[i] = bottleCapacity;
                        }

                        else
                        {
                            totalNeededLiters += (litersNeeded - totalWater);
                            totalWater = 0;
                            indexList.Add(i);
                            bottlesLeftCount++;
                        }
                    }
                }
            }

            else
            {
                for (int i = bottles.Length - 1; i >= 0; i--)
                {
                    var litersNeeded = bottleCapacity - bottles[i];

                    if (litersNeeded > 0)
                    {
                        if (totalWater - litersNeeded >= 0)
                        {
                            totalWater -= litersNeeded;
                            bottles[i] = bottleCapacity;
                        }

                        else
                        {
                            totalNeededLiters += (litersNeeded - totalWater);
                            totalWater = 0;
                            indexList.Add(i);
                            bottlesLeftCount++;
                        }
                    }
                }
            }

            if (totalWater > 0)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalWater}l.");
            }

            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {bottles.Where(x => x < bottleCapacity).Count()}");
                Console.WriteLine($"With indexes: {string.Join(", ", indexList)}");

                if (totalNeededLiters % 1 != 0)
                {
                    Console.WriteLine($"We need {totalNeededLiters} more liters!");
                }

                else
                {
                    Console.WriteLine($"We need {(long)totalNeededLiters} more liters!");
                }
            }
        }
    }
}