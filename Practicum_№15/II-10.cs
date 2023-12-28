using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Структура для представления информации о сотруднике
struct Employee
{
    public string FullName;
    public int HiringYear;
    public string Position;
    public double Salary;
    public int Experience;
}

class Program
{
    static void Main()
    {
        // Путь к файлам ввода и вывода
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        // Чтение данных из файла
        List<Employee> employees = ReadEmployeesFromFile(inputFile);

        // Группировка сотрудников по должности
        var groupedByPosition = GroupEmployeesByPosition(employees);

        // Вывод результатов в новый файл
        WriteGroupedDataToFile(groupedByPosition, outputFile);

        Console.WriteLine("Программа завершена. Результат записан в файл output.txt.");
    }

    // Метод для чтения данных из файла и создания списка сотрудников
    static List<Employee> ReadEmployeesFromFile(string filePath)
    {
        List<Employee> employees = new List<Employee>();

            // Чтение строк из файла
            string[] lines = File.ReadAllLines(filePath);

            // Обработка каждой строки и добавление сотрудника в список
            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                Employee employee = new Employee
                {
                    FullName = data[0],
                    HiringYear = int.Parse(data[1]),
                    Position = data[2],
                    Salary = double.Parse(data[3]),
                    Experience = int.Parse(data[4])
                };
                employees.Add(employee);
            }
        }

        return employees;
    }

    // Метод для группировки сотрудников по должности
    static Dictionary<string, List<Employee>> GroupEmployeesByPosition(List<Employee> employees)
    {
        // Группировка по должности с использованием LINQ
        var groupedByPosition = employees.GroupBy(e => e.Position)
                                         .ToDictionary(g => g.Key, g => g.ToList());

        return groupedByPosition;
    }

    // Метод для записи результатов в новый файл
    static void WriteGroupedDataToFile(Dictionary<string, List<Employee>> groupedData, string filePath)
    {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Запись группированных данных в файл
                foreach (var group in groupedData)
                {
                    writer.WriteLine($"Должность: {group.Key}");
                    foreach (var employee in group.Value)
                    {
                        writer.WriteLine($"ФИО: {employee.FullName}, Год принятия: {employee.HiringYear}, Зарплата: {employee.Salary}, Стаж: {employee.Experience}");
                    }
                    writer.WriteLine(); // Пустая строка между группами
                }
            }
        }
    }

/*
input.txt

Иванова Ольга Сергеевна;2012;Менеджер;48000;9
Петрова Анна Игоревна;2016;Разработчик;62000;4
Смирнова Мария Александровна;2013;Бухгалтер;54000;7
Кузнецов Сергей Николаевич;2017;Менеджер;55000;5
Васнецов Дмитрий Владимирович;2015;Разработчик;68000;6
Козлов Николай Васильевич;2014;Бухгалтер;52000;8
*/
/*
output.txt

Должность: Менеджер
ФИО: Иванова Ольга Сергеевна, Год принятия: 2012, Зарплата: 48000, Стаж: 9
ФИО: Кузнецов Сергей Николаевич, Год принятия: 2017, Зарплата: 55000, Стаж: 5

Должность: Разработчик
ФИО: Петрова Анна Игоревна, Год принятия: 2016, Зарплата: 62000, Стаж: 4
ФИО: Васнецов Дмитрий Владимирович, Год принятия: 2015, Зарплата: 68000, Стаж: 6

Должность: Бухгалтер
ФИО: Смирнова Мария Александровна, Год принятия: 2013, Зарплата: 54000, Стаж: 7
ФИО: Козлов Николай Васильевич, Год принятия: 2014, Зарплата: 52000, Стаж: 8
*/
