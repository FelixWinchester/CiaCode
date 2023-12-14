using System;
using System.Collections.Generic;
using System.IO;

struct Employee // создание структуры Employee
{
    public string FullName; // определение полей структуры Employee
    public int HireYear;
    public string Position;
    public decimal Salary;
    public int WorkExperience;
}

class Program // создание класса Program
{
    static void Main(string[] args) // определение точки входа в программу
    {
        List<Employee> employees = new List<Employee>(); // создание списка сотрудников

        // Чтение данных из файла input.txt
        string[] lines = File.ReadAllLines("input.txt"); // чтение всех строк из файла input.txt
        foreach (string line in lines) // итерация по каждой строке
        {
            string[] parts = line.Split(','); // разделение строки на части
            Employee employee = new Employee // создание нового сотрудника
            {
                FullName = parts[0], // присвоение значений полям сотрудника
                HireYear = int.Parse(parts[1]),
                Position = parts[2],
                Salary = decimal.Parse(parts[3]),
                WorkExperience = int.Parse(parts[4])
            };
            employees.Add(employee); // добавление сотрудника в список
        }

        // Группировка сотрудников по должности
        Dictionary<string, List<Employee>> groupedEmployees = new Dictionary<string, List<Employee>>(); // создание словаря для группировки сотрудников
        foreach (Employee employee in employees) // итерация по каждому сотруднику
        {
            if (!groupedEmployees.ContainsKey(employee.Position)) // проверка наличия ключа в словаре
            {
                groupedEmployees[employee.Position] = new List<Employee>(); // добавление нового ключа в словарь
            }
            groupedEmployees[employee.Position].Add(employee); // добавление сотрудника в соответствующую группу
        }

        // Запись результирующей информации в файл output.txt
        using (StreamWriter writer = new StreamWriter("output.txt")) // открытие файла для записи
        {
            foreach (KeyValuePair<string, List<Employee>> group in groupedEmployees) // итерация по каждой группе
            {
                writer.WriteLine($"Должность: {group.Key}"); // запись названия должности
                foreach (Employee employee in group.Value) // итерация по сотрудникам в группе
                {
                    writer.WriteLine($"{employee.FullName}, {employee.HireYear}, {employee.Position}, {employee.Salary}, {employee.WorkExperience}"); // запись информации о сотруднике
                }
                writer.WriteLine(); // запись пустой строки для разделения групп
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
