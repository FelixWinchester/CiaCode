using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int[,] newArr = new int[n, n];
        int newN = n;
        for (int i = 0; i < n; i++)
        {
            bool isRowZero = true;
            for (int j = 0; j < n; j++)
            {
                if (arr[i, j] != 0)
                {
                    isRowZero = false;
                    break;
                }
            }
            if (!isRowZero)
            {
                for (int j = 0; j < n; j++)
                {
                    newArr[i, j] = arr[i, j];
                }
            }
            else
            {
                newN--;
            }
        }

        for (int i = 0; i < n; i++)
        {
            bool isColZero = true;
            for (int j = 0; j < n; j++)
            {
                if (arr[j, i] != 0)
                {
                    isColZero = false;
                    break;
                }
            }
            if (!isColZero)
            {
                for (int j = 0; j < newN; j++)
                {
                    newArr[j, i] = arr[j, i];
                }
            }
        }

        Console.WriteLine("Уплотненный массив:");
        for (int i = 0; i < newN; i++)
        {
            for (int j = 0; j < newN; j++)
            {
                Console.Write(newArr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
