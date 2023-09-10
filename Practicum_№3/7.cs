using System;

class Task
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int A = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int B = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите шаг h: ");
        int h = Convert.ToInt32(Console.Read());
        for (int i = A; i < B; i++)
        {
       
            
                Console.Write($"{i + h} ");
            

        }
    }
}
