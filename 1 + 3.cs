using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое число:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите второе число:");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите третье число:");
        int c = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(a + "+" + b + "+" + c + "=" + (a + b + c));

    }
}
