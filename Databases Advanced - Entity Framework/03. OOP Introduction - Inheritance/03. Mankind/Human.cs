namespace _03.Mankind
{
    using System;

    public class Human
    {
        private const int MinFirstNameLength = 4;
        private const int MinLastNameLength = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value.Length < MinFirstNameLength)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length < MinLastNameLength)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                this.lastName = value;
            }
        }
    }
}