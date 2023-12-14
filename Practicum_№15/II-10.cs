using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// Определение класса Employee с публичными свойствами
public class Employee
{
    public string FullName { get; set; } // Имя
    public int YearOfEmployment { get; set; } // Год
    public string Position { get; set; } // Должность
    public decimal Salary { get; set; } // Зарплата
    public int WorkExperience { get; set; } // Опыт
}
class Program
{
    // Основной метод программы
    static void Main(string[] args)
    {
        // Считывание данных из файла и создание списка сотрудников
        List<Employee> employees = File.ReadAllLines("input.txt")
            .Select(line => line.Split(','))
            .Select(parts => new Employee
            {
                FullName = parts[0],
                YearOfEmployment = int.Parse(parts[1]),
                Position = parts[2],
                Salary = decimal.Parse(parts[3]),
                WorkExperience = int.Parse(parts[4])
            })
            .ToList();

        // Группировка сотрудников по должности и сортировка
        var groupedEmployees = employees.GroupBy(e => e.Position)
            .OrderBy(g => g.Key)
            .ToList();

        // Создание и использование объекта StreamWriter для записи в файл
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            // Перебор групп сотрудников и запись информации о каждом в файл
            foreach (var group in groupedEmployees)
            {
                writer.WriteLine($"Position: {group.Key}");
                foreach (var employee in group)
                {
                    writer.WriteLine($"{employee.FullName}, {employee.YearOfEmployment}, {employee.Salary}, {employee.WorkExperience}");
                }
                writer.WriteLine();
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
