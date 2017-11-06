namespace _03.Mankind
{
    using System;

    public class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        private const int MinWorkingHours = 1;
        private const int MaxWorkingHours = 12;

        private decimal weekSalary;
        private decimal workHoursPerDay;

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < MinWorkingHours || value > MaxWorkingHours)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal GetSalaryPerHour()
        {
            const int workDaysInAWeek = 5;
            var salaryPerHour = weekSalary / (workHoursPerDay * workDaysInAWeek);
            return salaryPerHour;
        }

        public override string ToString()
        {
            return $"First Name: {base.FirstName}" +
                   $"{Environment.NewLine}Last Name: {base.LastName}{Environment.NewLine}" +
                   $"Week Salary: {this.WeekSalary:f2}{Environment.NewLine}Hours per day: {this.WorkHoursPerDay:f2}" +
                   $"{Environment.NewLine}Salary per hour: {this.GetSalaryPerHour():f2}";
        }
    }
}