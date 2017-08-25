namespace _04.Hornet_Armada
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HornetArmada
    {
        private static int e;
        private static object x;

        public static void Main()
        {
            var legionList = new List<Legion>();

            var linesCount = long.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var soldierTokens = tokens[4].Split(':');

                var lastActivity = int.Parse(tokens[0]);
                var legionName = tokens[2];
                var soldierType = soldierTokens[0];
                var soldierCount = long.Parse(soldierTokens[1]);

                var matchLegion = legionList
                    .FindIndex(l => l.LegionName == legionName);

                var matchLegionAndSoldierType = legionList
                    .FindIndex(x => x.LegionName == legionName & x.SoldierTypeAndCount.ContainsKey(soldierType));

                if (matchLegionAndSoldierType >= 0)
                {
                    legionList[matchLegionAndSoldierType].SoldierTypeAndCount[soldierType] += soldierCount;

                    if(legionList[matchLegionAndSoldierType].LastActivity < lastActivity)
                    {
                        legionList[matchLegionAndSoldierType].LastActivity = lastActivity;
                    }
                }

                else if (matchLegion >= 0)
                {
                    legionList[matchLegion].SoldierTypeAndCount.Add(soldierType, soldierCount);

                    if (legionList[matchLegion].LastActivity < lastActivity)
                    {
                        legionList[matchLegion].LastActivity = lastActivity;
                    }
                }

                else
                {
                    var soldierTypeAndCountDict = new Dictionary<string, long>();
                    soldierTypeAndCountDict.Add(soldierType, soldierCount);

                    var legionAddInfo = new Legion(lastActivity, legionName, soldierTypeAndCountDict);
                    legionList.Add(legionAddInfo);
                }
            }

            var printInput = Console.ReadLine().Split('\\');

            if(printInput.Length > 1)
            {
                var lastActivity = int.Parse(printInput[0]);
                var soldierType = printInput[1];

                var sorted = legionList
                    .Where(l => l.LastActivity < lastActivity)
                    .Where(s => s.SoldierTypeAndCount.ContainsKey(soldierType))
                    .OrderByDescending(l => l.SoldierTypeAndCount[soldierType]);

                foreach (var legion in sorted)
                {
                    Console.WriteLine($"{legion.LegionName} -> {legion.SoldierTypeAndCount[soldierType]}");
                }
            }

            else
            {
                var soldierType = printInput[0];

                var sorted = legionList
                    .Where(s => s.SoldierTypeAndCount.ContainsKey(soldierType))
                    .OrderByDescending(a => a.LastActivity);

                foreach (var legion in sorted)
                {
                    Console.WriteLine($"{legion.LastActivity} : {legion.LegionName}");
                }
            }
        }
    }
}