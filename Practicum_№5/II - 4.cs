using System;

class Program
{
    static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static void Main()
    {
        Console.Write("Введите число N: ");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите начало отрезка a: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите конец отрезка b: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите значение C: ");
        int C = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Сумма цифр числа N: " + SumOfDigits(N));

        Console.WriteLine("Сумма цифр для каждого числа на отрезке [a, b]:");
        for (int i = a; i <= b; i++)
        {
            Console.WriteLine($"Число: {i}, Сумма цифр: {SumOfDigits(i)}");
        }

        Console.WriteLine($"Числа на отрезке [a, b] с суммой цифр равной {C}:");
        for (int i = a; i <= b; i++)
        {
            if (SumOfDigits(i) == C)
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine($"Числа на отрезке [a, b] с нечетной суммой цифр:");
        for (int i = a; i <= b; i++)
        {
            if (SumOfDigits(i) % 2 != 0)
            {
                Console.WriteLine(i);
            }
        }

        Console.Write("Введите число A: ");
        int A = Convert.ToInt32(Console.ReadLine());

        int closestNumber = a;
        int closestSum = SumOfDigits(a);

        for (int i = a + 1; i <= b; i++)
        {
            int currentSum = SumOfDigits(i);
            if (currentSum == SumOfDigits(A))
            {
                closestNumber = i;
                break;
            }
            else if (currentSum < SumOfDigits(A) && currentSum > closestSum)
            {
                closestNumber = i;
                closestSum = currentSum;
            }
        }

        Console.WriteLine($"Ближайшее предшествующее число к {A} с равной суммой цифр: {closestNumber}");
    }
}
