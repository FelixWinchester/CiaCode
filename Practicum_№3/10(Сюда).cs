using System;

class Task
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int A = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int B = Convert.ToInt32(Console.ReadLine());
        // Проверка числа на четность {Если оно нечетное, прибавляем к нему 1, делая его четным} //
        if (A % 2 == 1)
        {
            A += 1;
        }
        // Проходим по диапазону чисел и выводим нужные //
        for (int i = A; i < B; i += 2)
        {
            if (i % 3 == 0)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
