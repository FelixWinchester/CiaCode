using System;
using System.IO;
using System.Collections.Generic;

public struct City
{
    public string Name;
    public int X;
    public int Y;

    public City(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Чтение входных данных из файла
        string[] lines = File.ReadAllLines("input.txt");
        int n = int.Parse(lines[0]);
        City[] cities = new City[n];
        bool[,] adjacencyMatrix = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] parts = lines[i + 1].Split(' ');
            cities[i] = new City(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
        }

        for (int i = 0; i < n; i++)
        {
            string[] parts = lines[i + n + 1].Split(' ');
            for (int j = 0; j < n; j++)
            {
                adjacencyMatrix[i, j] = parts[j] == "1";
            }
        }

        // Определение городов A, B и D
        Console.Write("Введите город A: ");
        string cityA = Console.ReadLine();
        Console.Write("Введите город B: ");
        string cityB = Console.ReadLine();
        Console.Write("Введите город D: ");
        string cityD = Console.ReadLine();

        // Находим индексы городов A, B и D
        int indexA = Array.FindIndex(cities, city => city.Name == cityA);
        int indexB = Array.FindIndex(cities, city => city.Name == cityB);
        int indexD = Array.FindIndex(cities, city => city.Name == cityD);

        // Модификация матрицы смежности для учета расстояний
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (adjacencyMatrix[i, j] && (i == indexD || j == indexD))
                {
                    int distance = CalculateDistance(cities[i], cities[j]);
                    adjacencyMatrix[i, j] = false;
                    adjacencyMatrix[j, i] = false;
                    adjacencyMatrix[i, indexD] = false;
                    adjacencyMatrix[indexD, i] = false;
                    adjacencyMatrix[j, indexD] = false;
                    adjacencyMatrix[indexD, j] = false;
                    adjacencyMatrix[i, j] = distance <= 0; // Если расстояние нулевое, города считаются связанными
                    adjacencyMatrix[j, i] = distance <= 0;
                }
            }
        }

        // Находим кратчайший путь с помощью алгоритма Дейкстры
        int shortestPath = Dijkstra(adjacencyMatrix, indexA, indexB);

        Console.WriteLine($"Кратчайший путь между городами {cityA} и {cityB}, не проходящий через город {cityD}, составляет {shortestPath}.");
    }

    static int CalculateDistance(City city1, City city2)
    {
        return (int)Math.Sqrt(Math.Pow(city2.X - city1.X, 2) + Math.Pow(city2.Y - city1.Y, 2));
    }

    static int Dijkstra(bool[,] graph, int startNode, int endNode)
    {
        int n = graph.GetLength(0);
        int[] distances = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[startNode] = 0;

        for (int count = 0; count < n - 1; count++)
        {
            int u = MinDistance(distances, visited);
            visited[u] = true;

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] && distances[u] != int.MaxValue && distances[u] + 1 < distances[v])
                {
                    distances[v] = distances[u] + 1;
                }
            }
        }

        return distances[endNode];
    }

    static int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < distances.Length; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}

8
Городск 200 300
Долина 150 250
Живой 180 200
Зелёный 100 150
Ивановка 50 200
Красногорск 80 100
ЛеснаяПоляна 130 50
Малиновка 180 80
0 1 1 0 0 0 0 0
1 0 1 1 0 0 0 0
1 1 0 1 0 0 0 0
0 1 1 0 1 0 0 0
0 0 0 1 0 1 0 0
0 0 0 0 1 0 1 0
0 0 0 0 0 1 0 1
0 0 0 0 0 0 1 0
