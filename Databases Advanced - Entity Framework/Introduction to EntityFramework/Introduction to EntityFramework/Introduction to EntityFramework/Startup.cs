using System.Diagnostics;

namespace Introduction_to_EntityFramework.Models
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var SoftUniContext = new SoftUniContext();
            var GringottsContext = new GringottsContext();
        }

        public static void EmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.ToList().OrderBy(e => e.EmployeeID);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName}" +
                                  $" {employee.JobTitle} {employee.Salary}");
            }
        }

        public static void EmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .ToList()
                .Where(e => e.Salary > 50000);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }
        }

        public static void EmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                .Employees
                .ToList()
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
            }
        }

        public static void AddingANewAddressAndUpdatingEmployee(SoftUniContext context)
        {
            var adress = new Address { AddressText = "Vitoshka 15", TownID = 4 };
            context.Addresses.Add(adress);
            context.SaveChanges();

            var employeeNakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employeeNakov.Address = adress;
            context.SaveChanges();

            var employees = context
                .Employees
                .OrderByDescending(e => e.AddressID)
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Address.AddressText);
            }
        }

        public static void FindEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year >= 2001 & p.StartDate.Year <= 2003))
                .Take(30)
                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");

                foreach (var p in e.Projects)
                {
                    Console.Write(
                        $"--{p.Name} {ConvertDate(p.StartDate)} ");

                    if (p.EndDate.HasValue)
                    {
                        Console.Write(p.EndDate.Value.ToString("M'/'d'/'yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                    }

                    Console.WriteLine();
                }
            }
        }

        public static void AddressesByTownName(SoftUniContext context)
        {
            var adresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .ToList();

            foreach (var adress in adresses)
            {
                Console.WriteLine($"{adress.AddressText}, {adress.Town.Name} - {adress.Employees.Count} employees");
            }
        }

        public static void EmployeeWithId147(SoftUniContext context)
        {
            var employee = context.Employees.Find(147);

            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            foreach (var project in employee.Projects.OrderBy(p => p.Name))
            {
                Console.WriteLine(project.Name);
            }
        }

        public static void DepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ToList();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} {department.Manager.FirstName}");

                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                }
            }
        }

        public static void FindLatest10Projects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                Console.Write($"{project.Name} {project.Description} " +
                                  $"{ConvertDate(project.StartDate)} ");

                if (project.EndDate.HasValue)
                {
                    Console.Write(project.EndDate.Value.ToString("M'/'d'/'yyyy h:mm:ss tt ", CultureInfo.InvariantCulture));
                }

                Console.WriteLine();
            }
        }

        public static void IncreaseSalaries(SoftUniContext context)
        {
            var employeesToUpdate = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" | e.Department.Name == "Tool Design" |
                            e.Department.Name == "Marketing" |
                            e.Department.Name == "Information Services");
            foreach (var employee in employeesToUpdate)
            {
                employee.Salary += (employee.Salary * 0.12m);
                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            }

            context.SaveChanges();
        }

        public static void FindEmployeesByFirstNameStartingWithSA(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.Substring(0, 2) == "SA");

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f4})");
            }

        }

        public static void FirstLetter(GringottsContext context)
        {
            var wizards = context
                .WizzardDeposits
                .OrderBy(w => w.FirstName)
                .Where(w => w.DepositGroup == "Troll Chest")
                .Select(w => w.FirstName.Substring(0, 1))
                .Distinct();

            foreach (var wizard in wizards)
            {
                Console.WriteLine(wizard);
            }
        }

        public static void DeleteProjectById(SoftUniContext context)
        {
            try
            {
                var projectToDelete = context.Projects.Find(2);

                foreach (var employee in projectToDelete.Employees)
                {
                    employee.Projects.Remove(projectToDelete);
                }

                context.Projects.Remove(projectToDelete);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            var projects = context.Projects.Take(10).ToList();
            foreach (var project in projects)
            {
                Console.WriteLine(project.Name);
            }

        }

        public static void RemoveTown(SoftUniContext context)
        {
            var town = Console.ReadLine();

            var adressesToNull = context
                .Employees
                .Where(a => a.Address.Town.Name == town)
                .ToList();

            Console.WriteLine($"{adressesToNull.Count} address in {town} was deleted");

            //updating the adress id which will be deleted to null
            foreach (var adress in adressesToNull)
            {

            }

            var adressesToRemove = context
                .Addresses
                .Where(a => a.Town.Name == town)
                .ToList();

            foreach (var adress in adressesToRemove)
            {
                context.Addresses.Remove(adress);
                context.SaveChanges();
            }

            var townsToRemove = context
                .Towns
                .Where(t => t.Name == town);

            foreach (var townToRemove in townsToRemove)
            {
                context.Towns.Remove(townToRemove);
                context.SaveChanges();
            }
        }

        public static void MeasureTimeDiff(SoftUniContext context)
        {
            var timer = new Stopwatch();
            timer.Start();
            PrintNamesWithNativeQuery(context);
            timer.Stop();
            Console.WriteLine($"Native: {timer.Elapsed}");

            timer.Restart();
            PrintNamesWithLinq(context);
            timer.Stop();
            Console.WriteLine($"Linq: {timer.Elapsed}");
        }

        public static void PrintNamesWithNativeQuery(SoftUniContext context)
        {
            var employees = context.Database.SqlQuery<string>(@"SELECT DISTINCT e.FirstName 
                          FROM Employees AS e 
                          JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
                          JOIN Projects AS p ON p.ProjectID = ep.ProjectID
                          WHERE DATEPART(YEAR, p.StartDate) = 2002").ToArray();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public static void PrintNamesWithLinq(SoftUniContext context)
        {
            var employees = context
                .Employees
                .ToList()
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002));
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }
        }

        public static string ConvertDate(DateTime date)
        {
            return date.ToString("M'/'d'/'yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        }

    }
}