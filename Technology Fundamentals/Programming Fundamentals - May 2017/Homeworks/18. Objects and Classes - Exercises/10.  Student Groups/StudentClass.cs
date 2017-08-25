namespace _10.Student_Groups
{
    using System;

    public class StudentClass
    {
        public StudentClass(string name, string email, DateTime date)
        {
            this.Name = name;
            this.Email = email;
            this.Date = date;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
