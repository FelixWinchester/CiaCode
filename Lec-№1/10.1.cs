using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите объем куба:");
        double V = Convert.ToDouble(Console.ReadLine());
        double rez = Math.Pow(V, 1.0/3.0);
        Console.WriteLine($"Результат= {rez}");
    }
}
