namespace _01.Oldest_Family_Member
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> members = new List<Person>();

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestFamilyMember = this.members
                .OrderByDescending(p => p.Age)
                .Take(1)
                .FirstOrDefault();
            return oldestFamilyMember;
        }
    }
}