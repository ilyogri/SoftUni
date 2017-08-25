namespace Problem_3.Employee_Data
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var employeeID = Console.ReadLine();
            var salary = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Employee ID: {string.Concat(Enumerable.Repeat("0", 8 - employeeID.Length))}{employeeID}");
            Console.WriteLine("Salary: {0:f2}", salary);
        }
    }
}