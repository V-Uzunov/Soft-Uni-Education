namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Startup
    {
        public static void Main()
        {
            var employeesCount = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();
            var departmentAvSalary = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < employeesCount; i++)
            {
                var input = Console.ReadLine().Split();

                var name = input[0];
                var salary = decimal.Parse(input[1]);
                var position = input[2];
                var department = input[3];

                var employee = new Employee(name, salary, position, department);

                if (!departmentAvSalary.ContainsKey(department))
                {
                    departmentAvSalary[department] = new List<decimal>();
                }

                departmentAvSalary[department].Add(salary);

                if (input.Length > 4)
                {
                    if (input.Length == 5)
                    {
                        var age = 0;
                        var isAge = int.TryParse(input[4], out age);

                        if (isAge)
                        {
                            employee.age = age;
                        }

                        else
                        {
                            employee.email = input[4];
                        }
                    }

                    else
                    {
                        employee.age = int.Parse(input[5]);
                        employee.email = input[4];
                    }
                }

                employees.Add(employee);
            }

            var result = departmentAvSalary.OrderByDescending(d => d.Value.Average()).First();
            var highestAverageDepartment = result.Key;
            var employeesResult = employees.Where(e => e.department == highestAverageDepartment)
                .OrderByDescending(s => s.salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {highestAverageDepartment}");
            foreach (var em in employeesResult)
            {
                Console.WriteLine($"{em.name} {em.salary:f2} {em.email} {em.age}");
            }
        }
    }
}
