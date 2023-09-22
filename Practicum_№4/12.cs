using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (IsPrime(number))
        {
            Console.WriteLine($"{number} является простым числом.");
        }
        else
        {
            Console.WriteLine($"{number} не является простым числом. Его делители:");
            PrintDivisors(number);
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    static void PrintDivisors(int number)
    {
        for (int i = 1; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine(i);
                if (i != number / i)
                    Console.WriteLine(number / i);
            }
        }
    }
}
