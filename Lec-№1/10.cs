using System;
class Task
{
    static void Main()
    {
        Console.Write("Введите ваше имя: ");
        string? name = Console.ReadLine();
        Console.Write("Введите ваш возраст: ");
        int age = Convert.ToInt32(Console.ReadLine());
        int rez = (2009 - age);
        Console.Write($"{name}, ты родился в {rez} году");
        
    }
}
