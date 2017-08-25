namespace _03.Hornet_Assault
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var beehives = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            var hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            var assasinations = beehives.Count();
            var loopCount = 0;
            var remover = 0;

            while (loopCount < assasinations)
            {
                var hornetsSum = hornets.Sum();

                if ((int)beehives[remover] >= hornetsSum)
                {
                    if (beehives[remover] == hornetsSum)
                    {
                        beehives.RemoveAt(remover);
                    }

                    else
                    {
                        beehives[remover] -= hornetsSum;
                        remover++;
                    }

                    hornets.RemoveAt(0);

                    if(hornets.Count() == 0)
                    {
                        break;
                    }
                }

                else
                {
                    beehives.RemoveAt(remover);
                }

                loopCount++;
            }

            if (beehives.Count() > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
                return;
            }

            Console.WriteLine(string.Join(" ", hornets));
        }
    }
}