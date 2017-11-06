    namespace _03.Oldest_Family_Member
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> membersList { get; set; }

        public Family()
        {
            this.membersList = new List<Person>();
        }

        public List<Person> Members
        {
            get { return this.membersList; }
            set { this.Members = this.membersList; }
        }

        public void AddMember(Person member)
        {
            this.membersList.Add(member);    
        }

        public Person GetOldestMember()
        {
            return this.membersList.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}