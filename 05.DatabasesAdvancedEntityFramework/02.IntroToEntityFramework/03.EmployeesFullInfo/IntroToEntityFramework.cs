using _03.EmployeesFullInfo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;

class IntroToEntityFramework
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        var context = new SoftUniContext();
        //EmployeesFullInfo(context);

        //EmpWithSalaryOver50000(context);

        //EmpFromSeatle(context);

        //AddingANewAddressAndUpdatingEmployee(context);

        //FindEmployeesInPeriod(context);

        //AddressesByTownName(context);

        //EmployeeWithId147(context);

        //DepartmentsWithMoreThan5Employees(context);

        //FindLatest10Projects(context);

        //IncreaseSalaries(context);

        //FindEmployeesByFirstNameStartingWithSA(context);

        //DeleteProjectById(context);
    }

    private static void DeleteProjectById(SoftUniContext context)
    {
        var project = context.Projects.Find(2);

        foreach (var proj in project.Employees)
        {
            proj.Projects.Remove(project);
        }

        context.Projects.Remove(project);
        context.SaveChanges();

        var projects = context.Projects.Take(10);
        foreach (var pr in projects)
        {
            Console.WriteLine(pr.Name);
        }
    }

    private static void FindEmployeesByFirstNameStartingWithSA(SoftUniContext context)
    {
        var employee = context.Employees.Where(e => e.FirstName.ToLower().StartsWith("sa"));

        foreach (var emp in employee)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary})");
        }
    }

    private static void IncreaseSalaries(SoftUniContext context)
    {
        var employees = context.Employees.Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services").ToList();
        foreach (var emp in employees)
        {
            emp.Salary = emp.Salary + (decimal)0.12 * emp.Salary;
            context.SaveChanges();
            Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary})");
        }
    }

    private static void FindLatest10Projects(SoftUniContext context)
    {
        var lastTenProj = context.Projects.OrderByDescending(e => e.StartDate).Take(10).OrderBy(e => e.Name).ToList();

        foreach (var proj in lastTenProj)
        {
            Console.WriteLine($"{proj.Name} {proj.Description} {proj.StartDate:M/d/yyyy h:mm:ss tt} {proj.EndDate:M/d/yyyy h:mm:ss tt}");
        }
    }

    private static void DepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var department = context.Departments
                    .Where(e => e.Employees.Count > 5)
                    .OrderBy(a => a.Employees.Count);

        foreach (var dep in department)
        {
            Console.WriteLine($"{dep.Name} {dep.Employee.FirstName}");

            foreach (Employee emp in dep.Employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
            }
        }
    }

    private static void EmployeeWithId147(SoftUniContext context)
    {
        var emp = context.Employees.Find(147); //Find primary key

        var projects = emp.Projects.OrderBy(p => p.Name).ToList();

        Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");

        foreach (var p in projects)
        {
            Console.WriteLine(p.Name);
        }
    }

    private static void AddressesByTownName(SoftUniContext context)
    {
        var address = context.Addresses
                    .OrderByDescending(e => e.Employees.Count)
                    .ThenBy(e => e.Town.Name)
                    .Take(10)
                    .ToList();

        foreach (var emp in address)
        {
            Console.WriteLine($"{emp.AddressText}," + $" {emp.Town.Name}" + $" - {emp.Employees.Count} employees");

        }
    }

    private static void FindEmployeesInPeriod(SoftUniContext context)
    {
        var employyes = context.Employees
                .Where(e => e.Projects.Any(p => 2001 <= p.StartDate.Year && p.StartDate.Year <= 2003))
                .Take(30);
        foreach (var emp in employyes)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Manager.FirstName}");

            foreach (var proj in emp.Projects)
            {
                Console.WriteLine($"--{proj.Name} {proj.StartDate:M'/'d'/'yyyy h:mm:ss tt} {proj.EndDate:M'/'d'/'yyyy h:mm:ss tt}");
            }
        }
    }

    private static void AddingANewAddressAndUpdatingEmployee(SoftUniContext context)
    {
        var address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownID = 4
        };

        context.Addresses.Add(address);
        context.SaveChanges();

        var empWithNameNakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
        empWithNameNakov.Address = address;
        context.SaveChanges();

        var addreses = context.Employees.OrderByDescending(e => e.AddressID).Take(10).Select(a => a.Address.AddressText).ToList();

        foreach (var adr in addreses)
        {
            Console.WriteLine($"{adr}");
        }
    }

    private static void EmpFromSeatle(SoftUniContext context)
    {
        var empFromSeatle = context.Employees.
                    Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(s => s.Salary)
                    .ThenByDescending(f => f.FirstName)
                    .ToList();
        foreach (var emp in empFromSeatle)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} from {emp.Department.Name} - ${emp.Salary:F2}");
        }
    }

    private static void EmpWithSalaryOver50000(SoftUniContext context)
    {
        var empWithSalary = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName).ToList();

        foreach (var emp in empWithSalary)
        {
            Console.WriteLine($"{emp}");
        }
    }

    private static void EmployeesFullInfo(SoftUniContext context)
    {

        var empInfo = context.Employees.ToList();

        foreach (var emp in empInfo.OrderBy(e => e.EmployeeID))
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary}");
        }
    }
}