using System;
class Task
{
    static void Main()
    {
        Console.WriteLine("Введите ваше имя:");
        string? name = Console.ReadLine();
        Console.WriteLine("Введите ваш возраст:");
        int age = Convert.ToInt32(Console.ReadLine());
        int rez = (2009 - age);
        Console.WriteLine($"{name}, ты родился в {rez} году");
    }
}
