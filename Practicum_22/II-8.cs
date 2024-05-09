using System;
using System.Collections.Generic;
using System.IO;

class Graph
{
    private int[,] adjacencyMatrix; // Матрица смежности графа
    private int size; // Количество вершин в графе

    public Graph(string filePath)
    {
        // Конструктор класса Graph, который инициализирует граф на основе входных данных из файла
        string[] lines = File.ReadAllLines(filePath); // Считываем все строки из файла
        size = int.Parse(lines[0]); // Первая строка содержит количество вершин графа
        adjacencyMatrix = new int[size, size]; // Инициализируем матрицу смежности размером size x size

        // Заполнение матрицы смежности
        for (int i = 0; i < size; i++)
        {
            string[] parts = lines[i + 1].Split(' '); // Разбиваем строку на части по пробелу
            for (int j = 0; j < size; j++)
            {
                adjacencyMatrix[i, j] = int.Parse(parts[j]); // Заполняем ячейку матрицы смежности
            }
        }
    }

    // Метод для поиска эйлерова цикла в графе
    public void SearchEulerianCycle(int v, ref int[,] a, ref Stack<int> c)
    {
        // Рекурсивная функция для поиска эйлерова цикла
        for (int i = 0; i < size; i++)
        {
            if (a[v, i] != 0)
            {
                a[v, i] = 0;
                a[i, v] = 0;
                SearchEulerianCycle(i, ref a, ref c); // Рекурсивный вызов для следующей вершины
            }
        }
        c.Push(v); // После прохода по всем смежным вершинам добавляем текущую вершину в стек
    }

    // Метод для определения вершины, которая была просмотрена максимальное количество раз при поиске эйлерова цикла
    public int FindMaxVisitedVertex()
    {
        int[] visitedCount = new int[size]; // Массив для подсчета количества посещений вершин
        for (int i = 0; i < size; i++)
        {
            visitedCount[i] = 0; // Инициализация счетчиков посещений нулями
        }

        int[,] copyMatrix = (int[,])adjacencyMatrix.Clone(); // Создаем копию матрицы смежности
        Stack<int> cycle = new Stack<int>(); // Создаем стек для хранения эйлерова цикла
        SearchEulerianCycle(0, ref copyMatrix, ref cycle); // Запускаем поиск эйлерова цикла

        // Подсчет количества посещений вершин в эйлеровом цикле
        while (cycle.Count != 0)
        {
            visitedCount[cycle.Pop()]++; // Увеличиваем счетчик посещений для каждой вершины цикла
        }

        // Находим вершину, которая была посещена максимальное количество раз
        int maxCount = 0;
        int maxCountVertex = -1;
        for (int i = 0; i < size; i++)
        {
            if (visitedCount[i] > maxCount)
            {
                maxCount = visitedCount[i];
                maxCountVertex = i;
            }
        }

        return maxCountVertex + 1; // Возвращаем номер вершины с максимальным количеством посещений
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляра класса Graph на основе входных данных из файла
        Graph graph = new Graph("input.txt");
        // Определение вершины, которая была просмотрена максимальное количество раз при поиске эйлерова цикла
        int maxVisitedVertex = graph.FindMaxVisitedVertex();
        // Вывод результата на консоль
        Console.WriteLine($"Вершина, просмотренная максимальное количество раз: {maxVisitedVertex}");
    }
}

7
0 1 1 0 0 0 0
1 0 1 0 1 0 1
1 1 0 1 1 0 0
0 0 1 0 1 0 0
0 1 1 1 0 1 0
0 0 0 0 1 0 1
0 1 0 0 0 1 0
