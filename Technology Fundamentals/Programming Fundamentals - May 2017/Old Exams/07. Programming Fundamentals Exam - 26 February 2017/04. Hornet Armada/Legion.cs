namespace _04.Hornet_Armada
{
    using System.Collections.Generic;

   public class Legion
    {
        public  Legion(long lastActivity, string legionName, Dictionary<string, long> soldierTypeAndCount)
        {
            this.LastActivity = lastActivity;
            this.LegionName = legionName;
            this.SoldierTypeAndCount = soldierTypeAndCount;
        }

        public long LastActivity { get; set; }
        public string LegionName { get; set; }
        public Dictionary<string, long> SoldierTypeAndCount { get; set; }
    }
}