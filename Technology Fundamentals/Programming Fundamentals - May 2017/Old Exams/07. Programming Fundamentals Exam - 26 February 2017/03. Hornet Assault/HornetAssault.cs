namespace _03.Hornet_Assault
{
    using System;
    using System.Linq;

    public class HornetAssault
    {
        public static void Main()
        {
            var beehives = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var hornets = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var beehivesLength = beehives.Count;
            var index = 0;
            var loopCounter = 0;

            while (beehives.Count != 0 && hornets.Count != 0 && loopCounter != beehivesLength)
            {
                var hornetsPower = hornets.Sum();

                if (hornetsPower > beehives[index])
                {
                    beehives.RemoveAt(index);
                    index--;
                }

                else if (hornetsPower == beehives[index])
                {
                    hornets.RemoveAt(0);
                    beehives.RemoveAt(index);
                    index--;
                }

                else
                {
                    hornets.RemoveAt(0);
                    beehives[index] -= hornetsPower;
                }

                index++;
                loopCounter++;
            }

            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }

            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}