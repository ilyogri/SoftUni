namespace _03.Mankind
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        private const int MinFacultyNumberLength = 5;
        private const int MaxFacultyNumberLength = 10;

        private string facultyNumber;

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (value.Length < MinFacultyNumberLength || value.Length > MaxFacultyNumberLength || Regex.IsMatch(value, "[^A-Za-z0-9]"))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {base.FirstName}" +
                   $"{Environment.NewLine}Last Name: {base.LastName}{Environment.NewLine}" +
                   $"Faculty number: {this.FacultyNumber}{Environment.NewLine}";
        }
    }
}