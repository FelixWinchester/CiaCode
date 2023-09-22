using System;

class Task
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int A = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int B = Convert.ToInt32(Console.ReadLine());
        if (A % 2 == 1)
        {
            A += 1;
        }
            for (int i = A; i < B; i += 2)
            {
                if (i % 3 == 0)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
