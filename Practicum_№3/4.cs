using System;

class Task
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int A = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int B = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите нужную цифру: ");
        int X = Convert.ToInt32(Console.ReadLine());
        for (int i = A; i < B; i++)
        {
            if (i % 10 == X)
            {
                Console.Write($"{i} ");
            }

        }
    }
}
