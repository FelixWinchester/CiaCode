using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Чтение данных из файла
        string[] lines = File.ReadAllLines("input.txt");
        int N = int.Parse(lines[0]);
        int[,] A = new int[N, N];
        for (int i = 1; i <= N; i++)
        {
            string[] parts = lines[i].Split(' ');
            for (int j = 0; j < N; j++)
            {
                A[i - 1, j] = int.Parse(parts[j]);
            }
        }

        // Обход графа и вывод соседних вершин
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Вершина {i + 1} имеет соседние вершины: ");
            for (int j = 0; j < N; j++)
            {
                if (A[i, j] != 0)
                {
                    Console.Write($"{j + 1} ");
                }
            }
            Console.WriteLine(); // Переход на новую строку после вывода соседних вершин для текущей вершины
        }
    }
}


5
0 1 1 0 1
0 0 0 1 0
0 0 0 0 1
1 0 1 0 0
0 1 0 1 0
