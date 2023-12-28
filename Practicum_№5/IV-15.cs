using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите натуральное число n: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            Console.WriteLine($"Возможные разложения числа {n} на слагаемые:");
            PrintPartitions(n, n, "");
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Введите натуральное число больше 0.");
        }
    }

    static void PrintPartitions(int remainingSum, int maxAddend, string currentPartition)
    {
        if (remainingSum == 0)
        {
            // Если сумма стала равна 0, значит, достигнуто разложение, выводим его
            Console.WriteLine(currentPartition.TrimEnd(' ', '+') + $" = {CalculateSum(currentPartition)}");
            return;
        }

        for (int i = 1; i <= Math.Min(remainingSum, maxAddend); i++)
        {
            // Рекурсивно вызываем метод для оставшейся части суммы и добавляем слагаемое к текущему разложению
            PrintPartitions(remainingSum - i, i, $"{currentPartition}{i} + ");
        }
    }

    static int CalculateSum(string partition)
    {
        string[] addends = partition.TrimEnd(' ', '+').Split('+');
        int sum = 0;

        foreach (string addend in addends)
        {
            if (int.TryParse(addend, out int num))
            {
                sum += num;
            }
        }

        return sum;
    }
}
