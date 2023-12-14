using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    public class Employee
    {
        public string FullName { get; set; }
        public int YearOfEmployment { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int WorkExperience { get; set; }
    }

    public static class EmployeeExtensions
    {
        public static string GetFullName(this Employee employee)
        {
            return $"{employee.FullName}, {employee.YearOfEmployment}, {employee.Position}, {employee.Salary}, {employee.WorkExperience}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            using (StreamReader reader = new StreamReader("input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Employee employee = new Employee
                    {
                        FullName = string.Join(" ", parts.Take(3)),
                        YearOfEmployment = int.Parse(parts[3]),
                        Position = parts[4],
                        Salary = int.Parse(parts[5]),
                        WorkExperience = int.Parse(parts[6])
                    };
                    employees.Add(employee);
                }
            }

            var groupedEmployees = employees.GroupBy(e => e.Position);

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var group in groupedEmployees)
                {
                    writer.WriteLine($"Должность: {group.Key}");
                    foreach (var employee in group)
                    {
                        writer.WriteLine(employee.GetFullName());
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
/* input.txt
Иванов, Иван, Иваныч, 2000, инженер, 10000, 20
Иванов, Иван, Иванович, 2006, менеджер, 20000, 14
Петров, Петр, Петрович, 2007, менеджер, 21000, 13
Петров, Петр, Петрович, 2001, инженер, 12000, 19
Сидоров, Сидор, Сидорович, 2008, менеджер, 22000, 12
Иванова, Мария, Ивановна, 2009, менеджер, 23000, 11
Петрова, Анна, Петровна, 2010, менеджер, 24000, 10
Иванова, Мария, Ивановна, 2003, инженер, 13000, 17
Петрова, Анна, Петровна, 2004, инженер, 14000, 16
Сидорова, Елена, Сидоровна, 2011, менеджер, 25000, 9
Сидоров, Сидор, Сидорович, 2002, инженер, 11000, 18
Сидорова, Елена, Сидоровна, 2005, инженер, 15000, 15
*/
/* output.txt
Должность:  инженер
Иванов  Иван  Иваныч, 2000,  инженер, 10000, 20
Петров  Петр  Петрович, 2001,  инженер, 12000, 19
Сидоров  Сидор  Сидорович, 2002,  инженер, 11000, 18
Иванова  Мария  Ивановна, 2003,  инженер, 13000, 17
Петрова  Анна  Петровна, 2004,  инженер, 14000, 16
Сидорова  Елена  Сидоровна, 2005,  инженер, 15000, 15

Должность:  менеджер
Иванов  Иван  Иванович, 2006,  менеджер, 20000, 14
Петров  Петр  Петрович, 2007,  менеджер, 21000, 13
Сидоров  Сидор  Сидорович, 2008,  менеджер, 22000, 12
Иванова  Мария  Ивановна, 2009,  менеджер, 23000, 11
Петрова  Анна  Петровна, 2010,  менеджер, 24000, 10
Сидорова  Елена  Сидоровна, 2011,  менеджер, 25000, 9
*/
