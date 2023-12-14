using System;
using System.Collections.Generic;
using System.IO;

struct Employee
{
    public string FullName;
    public int HireYear;
    public string Position;
    public decimal Salary;
    public int WorkExperience;
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        // Чтение данных из файла input.txt
        string[] lines = File.ReadAllLines("input.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            Employee employee = new Employee
            {
                FullName = parts[0],
                HireYear = int.Parse(parts[1]),
                Position = parts[2],
                Salary = decimal.Parse(parts[3]),
                WorkExperience = int.Parse(parts[4])
            };
            employees.Add(employee);
        }

        // Группировка сотрудников по должности
        Dictionary<string, List<Employee>> groupedEmployees = new Dictionary<string, List<Employee>>();
        foreach (Employee employee in employees)
        {
            if (!groupedEmployees.ContainsKey(employee.Position))
            {
                groupedEmployees[employee.Position] = new List<Employee>();
            }
            groupedEmployees[employee.Position].Add(employee);
        }

        // Запись результирующей информации в файл output.txt
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            foreach (KeyValuePair<string, List<Employee>> group in groupedEmployees)
            {
                writer.WriteLine($"Должность: {group.Key}");
                foreach (Employee employee in group.Value)
                {
                    writer.WriteLine($"{employee.FullName}, {employee.HireYear}, {employee.Position}, {employee.Salary}, {employee.WorkExperience}");
                }
                writer.WriteLine();
            }
        }
    }
}
/* input.txt
Иванов Иван Иванович, 2010, Директор, 100000, 10
Петров Петр Петрович, 2012, Главный бухгалтер, 80000, 8
Сидоров Сидор Сидорович, 2015, Инженер, 60000, 5
Васильев Василий Васильевич, 2011, Менеджер, 70000, 9
Алексеев Алексей Алексеевич, 2013, Программист, 75000, 7
*/
/* output.txt
Должность:  Директор
Иванов Иван Иванович, 2010,  Директор, 100000, 10

Должность:  Главный бухгалтер
Петров Петр Петрович, 2012,  Главный бухгалтер, 80000, 8

Должность:  Инженер
Сидоров Сидор Сидорович, 2015,  Инженер, 60000, 5

Должность:  Менеджер
Васильев Василий Васильевич, 2011,  Менеджер, 70000, 9

Должность:  Программист
Алексеев Алексей Алексеевич, 2013,  Программист, 75000, 7
*/
