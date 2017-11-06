namespace _05.Company_Roster
{
    public class Employee
    {
        public string Name;
        public decimal Salary;
        public string Position;
        public string Department;
        public string Email;
        public int Age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = "n/a";
            this.Age = -1;
        }
    }
}