namespace _04.Students
{
    using System.Collections.Generic;

    public class Student
    {
        public static int studentsCount { get; set; } = 0;

        private List<Student> studentsList { get; set; }

        public Student()
        {
            this.studentsList = new List<Student>();
        }

        public List<Student> Members
        {
            get { return this.studentsList; }
            set { this.Members = this.studentsList; }
        }

        public string Name { get; set; }
    }
}