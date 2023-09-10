using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трехзначное число: ");
        int inputNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число A для проверки: ");
        int numberA = Convert.ToInt32(Console.ReadLine());

        // Вычисляем сумму цифр трехзначного числа
        int digit1 = inputNumber / 100;           // Первая цифра
        int digit2 = (inputNumber % 100) / 10;    // Вторая цифра
        int digit3 = inputNumber % 10;            // Третья цифра
        int sumOfDigits = digit1 + digit2 + digit3;

        // Проверяем, кратна ли сумма цифр числу A
        bool isMultiple = (sumOfDigits % numberA) == 0;

        string result = isMultiple
            ? $"Сумма цифр числа {inputNumber} кратна числу {numberA}."
            : $"Сумма цифр числа {inputNumber} не кратна числу {numberA}.";

        Console.WriteLine(result);
    }
}
