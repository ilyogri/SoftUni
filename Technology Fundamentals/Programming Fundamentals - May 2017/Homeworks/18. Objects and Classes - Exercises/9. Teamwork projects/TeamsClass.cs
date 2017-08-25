namespace _10.Student_Groups
{
    using System.Collections.Generic;

    public class Team
    {
        public Team(string name, string creator, List<string> members)
        {
            this.TeamName = name;
            this.Creator = creator;
            this.Members = members;
        }

        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}