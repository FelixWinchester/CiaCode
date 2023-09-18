using System;

class Task
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int a = Convert.ToInt32(Console.Read());
        Console.Write("Введите второе число: ");
        int b = Convert.ToInt32(Console.Read());

        for (int i =a; i<=b; i++)
        {
            if (i % 1 == 0 || i % i == 0)
            {
                Console.Write($"Число {i} является простым.");
            }
            else
            {

            }
        }
        








    }
}
