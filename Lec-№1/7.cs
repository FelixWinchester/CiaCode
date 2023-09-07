//костыли...
using System;

class Task
{
    static void Main()
    {
        Console.WriteLine("Введите номинал купюры:");
        int nom = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество купюр:");
        int kol = Convert.ToInt32(Console.ReadLine());
        int rez = (nom * kol);
        Console.WriteLine($"Номинал купюры= {nom}");
        Console.WriteLine($"Количество купюр= {kol}");
        Console.WriteLine($"Сумма денег={rez},00р");
    }
}
