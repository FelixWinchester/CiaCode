using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите необходимое число: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Все возможные разложения числа {n} на слагаемые:");
        PrintPartitions(n, n, "");
    }

    static void PrintPartitions(int n, int max, string partition)
    {
        if (n == 0)
        {
            Console.WriteLine(partition);
           
        }

        for (int i = Math.Min(max, n); i >= 1; i--)
        {
            PrintPartitions(n - i, i, partition + i.ToString() + " ");
        }
    }
}
