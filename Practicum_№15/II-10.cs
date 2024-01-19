using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    public struct Stuff
    {
        public string Surname, Name, MiddleName, Post;
        public int Year, Experience;
        public double Salary;

        public Stuff(string surname, string name, string middleName, string post, int year, int experience, double salary)
        {
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            Post = post;
            Year = year;
            Experience = experience;
            Salary = salary;
        }
    }

    static Stuff[] Input(ref int n)
    {
        using (StreamReader fileIn = new StreamReader("input.txt"))
        {
            n = int.Parse(fileIn.ReadLine());
            Stuff[] stuffs = new Stuff[n];
            for (int i = 0; i < n; i++)
            {
                string[] text = fileIn.ReadLine().Split(' ');
                stuffs[i] = new Stuff(text[0], text[1], text[2], text[3], int.Parse(text[4]), int.Parse(text[5]), double.Parse(text[6]));
            }
            return stuffs;
        }
    }

    static void Main()
    {
        int n = 0;
        Stuff[] stuffs = Input(ref n);

        var query = stuffs.OrderBy(member => member.Post).GroupBy(member => member.Post);

        using (StreamWriter fileout = new StreamWriter("output.txt", false))
        {
            foreach (var group in query)
            {
                fileout.WriteLine($"{group.Key}:");
                foreach (var member in group)
                {
                    fileout.WriteLine($"{member.Surname} {member.Name} {member.MiddleName}, " +
                                      $"Год принятия: {member.Year}, Должность: {member.Post}, " +
                                      $"Зарплата: {member.Salary}, Стаж: {member.Experience}");
                }
                fileout.WriteLine();
            }
        }

        Console.WriteLine("Программа завершена. Результат записан в файл output.txt.");
    }
}


/*
input.txt

5
Smith John M Manager 2010 8 60000.0
Johnson Mary A Accountant 2015 5 50000.0
Williams James T Engineer 2018 3 70000.0
Jones Linda K Analyst 2017 4 55000.0
Miller Robert J Developer 2019 2 75000.0

*/
/*
output.txt

Accountant:
Johnson Mary A, Год принятия: 2015, Должность: Accountant, Зарплата: 50000, Стаж: 5

Analyst:
Jones Linda K, Год принятия: 2017, Должность: Analyst, Зарплата: 55000, Стаж: 4

Developer:
Miller Robert J, Год принятия: 2019, Должность: Developer, Зарплата: 75000, Стаж: 2

Engineer:
Williams James T, Год принятия: 2018, Должность: Engineer, Зарплата: 70000, Стаж: 3

Manager:
Smith John M, Год принятия: 2010, Должность: Manager, Зарплата: 60000, Стаж: 8

*/
