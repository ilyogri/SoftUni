namespace _04.Roli_The_Coder
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string id, string eventString, List<string> participants)
        {
            this.ID = id;
            this.Event = eventString;
            this.Participants = participants;
        }

        public string ID { get; set; }
        public string Event { get; set; }
        public List<string> Participants { get; set; }
    }
}