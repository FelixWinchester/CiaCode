using System;
class Task
{
    static void Main()
    {
        Console.WriteLine("Введите первое число:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите второе число:");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(a + "+" + b + "=" + (a + b) + "=" + b + "+" + a);
    }
}
  
