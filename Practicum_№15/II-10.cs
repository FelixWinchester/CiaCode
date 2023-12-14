using System;
using System.Collections.Generic;
using System.IO;

struct Employee
{
    public string FullName;     // Полное имя сотрудника
    public int HireYear;        // Год найма
    public string Position;     // Должность
    public decimal Salary;      // Зарплата
    public int WorkExperience;  // Опыт работы
}

// Определение класса Program
class Program
{
    static void Main(string[] args)
    {
        // Создание списка сотрудников
        List<Employee> employees = new List<Employee>();

        // Чтение данных из файла input.txt
        string[] lines = File.ReadAllLines("input.txt");
        foreach (string line in lines)
        {
            // Разделение строки на части по запятым
            string[] parts = line.Split(',');

            // Создание нового экземпляра сотрудника и заполнение его полей
            Employee employee = new Employee
            {
                FullName = parts[0],
                HireYear = int.Parse(parts[1]),
                Position = parts[2],
                Salary = decimal.Parse(parts[3]),
                WorkExperience = int.Parse(parts[4])
            };

            // Добавление сотрудника в список
            employees.Add(employee);
        }

        // Группировка сотрудников по должности
        Dictionary<string, List<Employee>> groupedEmployees = new Dictionary<string, List<Employee>>();
        foreach (Employee employee in employees)
        {
            // Проверка наличия должности в словаре
            if (!groupedEmployees.ContainsKey(employee.Position))
            {
                // Если должности нет, создание нового списка сотрудников
                groupedEmployees[employee.Position] = new List<Employee>();
            }

            // Добавление сотрудника в список соответствующей должности
            groupedEmployees[employee.Position].Add(employee);
        }

        // Запись результирующей информации в файл output.txt
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            foreach (KeyValuePair<string, List<Employee>> group in groupedEmployees)
            {
                // Запись названия должности в файл
                writer.WriteLine($"Должность: {group.Key}");

                // Запись информации о каждом сотруднике в файл
                foreach (Employee employee in group.Value)
                {
                    writer.WriteLine($"{employee.FullName}, {employee.HireYear}, {employee.Position}, {employee.Salary}, {employee.WorkExperience}");
                }

                // Добавление пустой строки для разделения групп сотрудников
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
