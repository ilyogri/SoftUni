namespace _04.Hornet_Armada
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine();

            var legionActivity = new Dictionary<string, int>();
            var legionSoldierCount = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                var splittedInput = inputLine.Split(new[] { '=', '-', '>', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var lastActivity = int.Parse(splittedInput[0]);
                var legion = splittedInput[1];
                var soldierType = splittedInput[2];
                var soldierCount = long.Parse(splittedInput[3]);

                if (!legionActivity.ContainsKey(legion))
                {
                    legionActivity[legion] = lastActivity;
                    legionSoldierCount[legion] = new Dictionary<string, long>();
                    legionSoldierCount[legion][soldierType] = soldierCount;
                }

                else
                {
                    if (legionSoldierCount[legion].ContainsKey(soldierType))
                    {
                        soldierCount += legionSoldierCount[legion][soldierType];
                    }

                    if (legionActivity[legion] < lastActivity)
                    {
                        legionActivity[legion] = lastActivity;
                    }

                    legionSoldierCount[legion][soldierType] = soldierCount;
                }

                inputLine = Console.ReadLine();
            }

            var splittedResultLine = inputLine.Split('\\');

            if (splittedResultLine.Count() > 1)
            {
                GetLegionsAndSoldiersCount(legionActivity, legionSoldierCount, int.Parse(splittedResultLine[0]), splittedResultLine[1]);
            }

            else
            {
                GetActivityLegion(legionSoldierCount, splittedResultLine[0], legionActivity);
            }
        }

        static void GetLegionsAndSoldiersCount(Dictionary<string, int> legionAcitivity,
              Dictionary<string, Dictionary<string, long>> legionSoldierCount, int activity, string soldierTypeInput)
        {
            foreach (var soldierType in legionSoldierCount
                .Where(x => x.Value.Keys.Contains(soldierTypeInput))
                .OrderByDescending(x => x.Value[soldierTypeInput]))
            {
                foreach (var activityOfLegion in legionAcitivity
                    .Where(x => x.Key == soldierType.Key))
                {
                    if (activity > activityOfLegion.Value)
                    {
                        Console.WriteLine("{0} -> {1}", soldierType.Key, soldierType.Value[soldierTypeInput]);
                    }
                }
            }
        }

        static void GetActivityLegion(Dictionary<string, Dictionary<string, long>> legionSoldierCount, string soldierTypeInput,
            Dictionary<string, int> legionActivity)
        {
            {
                foreach (var legionAndActivity in legionActivity
                    .OrderByDescending(x => x.Value))
                {
                    if (legionSoldierCount[legionAndActivity.Key].ContainsKey(soldierTypeInput))
                    {
                        Console.WriteLine("{0} : {1}", legionAndActivity.Value, legionAndActivity.Key);
                    }
                }
            }
        }
    }
}