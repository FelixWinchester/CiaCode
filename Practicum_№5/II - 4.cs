using System;

class Program
{
    static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number != 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static int FindClosestNumber(int A)
    {
        int closestNumber = A - 1;
        int closestSum = SumOfDigits(closestNumber);
        while (closestSum != SumOfDigits(A))
        {
            closestNumber--;
            closestSum = SumOfDigits(closestNumber);
        }
        return closestNumber;
    }

    static void Main()
    {
        Console.Write("Введите начало отрезка a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите конец отрезка b: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите значение C: ");
        int c = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число A: ");
        int A = Convert.ToInt32(Console.ReadLine());

        // a) Вывод суммы цифр для каждого числа на отрезке [a, b]
        Console.WriteLine("Суммы цифр для каждого числа на отрезке [a, b]:");
        for (int i = a; i <= b; i++)
        {
            int sum = SumOfDigits(i);
            Console.WriteLine($"Сумма цифр числа {i}: {sum}");
        }

        Console.WriteLine();

        // b) Вывод чисел отрезка [a, b], у которых сумма цифр равна C
        Console.WriteLine($"Числа отрезка [a, b], у которых сумма цифр равна {c}:");
        for (int i = a; i <= b; i++)
        {
            int sum = SumOfDigits(i);
            if (sum == c)
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine();

        // c) Вывод чисел отрезка [a, b], у которых сумма цифр нечетная
        Console.WriteLine($"Числа отрезка [a, b], у которых сумма цифр нечетная:");
        for (int i = a; i <= b; i++)
        {
            int sum = SumOfDigits(i);
            if (sum % 2 != 0)
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine();

        // d) Вывод ближайшего предшествующего числа с такой же суммой цифр, как у числа A
        Console.WriteLine($"Ближайшее предшествующее число к {A} с такой же суммой цифр:");
        int closestNumber = FindClosestNumber(A);
        Console.WriteLine(closestNumber);
    }
}
