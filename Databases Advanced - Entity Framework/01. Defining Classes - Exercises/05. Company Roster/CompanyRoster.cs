namespace _05.Company_Roster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyRoster
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var employeesList = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine().Split();
                var employee = GetEmployee(inputData);
                employeesList.Add(employee);
            }
            PrintResult(employeesList);
        }

        public static Employee GetEmployee(string[] args)
        {
            var name = args[0];
            var salary = decimal.Parse(args[1]);
            var position = args[2];
            var department = args[3];
            var employee = new Employee(name, salary, position, department);

            if (args.Length > 4)
            {
                int error = 0;
                int.TryParse(args[4], out error);
                if (error == 0)
                {
                     employee.Email = args[4];
                }
                else
                {
                    employee.Age = int.Parse(args[4]);
                }
            }
            if (args.Length > 5)
            {
                employee.Age = int.Parse(args[5]);
            }
            return employee;
        }

        public static void PrintResult(List<Employee> employeesList)
        {
            var highestAvgSalaryDepartment = employeesList
                .GroupBy(e => e.Department)
                .Select(group => new
                {
                    Department = group.Key,
                    AvgSalary = group.Average(e => e.Salary)
                })
                .OrderByDescending(e => e.AvgSalary)
                .ThenBy(e => e.Department)
                .ToDictionary(e => e.Department, e => e.AvgSalary)
                .Keys
                .First();

            Console.WriteLine($"Highest Average Salary: {highestAvgSalaryDepartment}");

            var bestDepartmentEmployees = employeesList
                .Where(e => e.Department == highestAvgSalaryDepartment)
                .OrderByDescending(e => e.Salary);

            foreach (var e in bestDepartmentEmployees)
            {
                Console.WriteLine($"{e.Name} {e.Salary:f2} {e.Email} {e.Age}");
            }
        }
    }
}