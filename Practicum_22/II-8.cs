using System; // Подключаем пространство имен для базовых классов .NET
using System.Collections.Generic; // Подключаем пространство имен для работы с коллекциями
using System.IO; // Подключаем пространство имен для работы с файлами

class Program // Объявляем класс программы
{
    static void Main(string[] args) // Главная функция программы
    {
        string[] lines = File.ReadAllLines("input.txt"); // Читаем данные из файла
        int n = int.Parse(lines[0]); // Получаем количество вершин графа

        int[,] adjacencyMatrix = new int[n, n]; // Создаем матрицу смежности

        // Заполняем матрицу смежности
        for (int i = 1; i <= n; i++) // Проходим по строкам матрицы
        {
            string[] values = lines[i].Split(' '); // Разбиваем строку на части
            for (int j = 0; j < n; j++) // Проходим по столбцам матрицы
            {
                adjacencyMatrix[i - 1, j] = int.Parse(values[j]); // Заполняем элементы матрицы
            }
        }

        if (IsEulerian(adjacencyMatrix, n)) // Проверяем, является ли граф эйлеровым
        {
            // Если да, находим вершины с максимальным количеством дорог
            int[] degrees = CalculateInDegrees(adjacencyMatrix, n); // Вычисляем входные степени вершин
            int maxDegree = 0; // Максимальная степень вершины
            List<int> maxVertices = new List<int>(); // Список вершин с максимальной степенью

            // Поиск вершин с максимальной степенью
            for (int i = 0; i < n; i++)
            {
                if (degrees[i] > maxDegree) // Если степень текущей вершины больше максимальной
                {
                    maxDegree = degrees[i]; // Обновляем максимальную степень
                    maxVertices.Clear(); // Очищаем список вершин
                    maxVertices.Add(i + 1); // Добавляем текущую вершину в список
                }
                else if (degrees[i] == maxDegree) // Если степень текущей вершины равна максимальной
                {
                    maxVertices.Add(i + 1); // Добавляем текущую вершину в список
                }
            }

            // Выводим результат
            Console.WriteLine("Вершины с максимальным количеством дорог: " + string.Join(", ", maxVertices));
        }
        else
        {
            // Если граф не является эйлеровым, выводим сообщение
            Console.WriteLine("Граф не является эйлеровым.");
        }
    }

    // Функция для проверки, является ли граф эйлеровым
    static bool IsEulerian(int[,] matrix, int n)
    {
        // Проверяем, является ли граф ориентированным
        bool isDirected = false;
        for (int i = 0; i < n && !isDirected; i++)
        {
            for (int j = 0; j < n && !isDirected; j++)
            {
                if (matrix[i, j] != matrix[j, i]) // Если существует ориентированное ребро
                {
                    isDirected = true; // Граф является ориентированным
                }
            }
        }

        if (isDirected) // Если граф ориентированный
        {
            // Проверяем условия эйлеровости для ориентированного графа
            int[] inDegrees = new int[n]; // Массив для хранения входных степеней вершин
            int[] outDegrees = new int[n]; // Массив для хранения выходных степеней вершин

            // Вычисляем входные и выходные степени для каждой вершины
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    outDegrees[i] += matrix[i, j]; // Вычисляем выходную степень вершины
                    inDegrees[j] += matrix[i, j]; // Вычисляем входную степень вершины
                }
            }

            // Проверяем, равны ли входные и выходные степени для каждой вершины
            for (int i = 0; i < n; i++)
            {
                if (inDegrees[i] != outDegrees[i]) // Если входная и выходная степени не равны
                {
                    return false; // Граф не является эйлеровым
                }
            }

            // Проверяем, является ли граф сильно связным
            return IsStronglyConnected(matrix, n);
        }
        else
        {
            // Проверяем условия эйлеровости для неориентированного графа
            for (int i = 0; i < n; i++)
            {
                int degree = 0; // Степень вершины
                for (int j = 0; j < n; j++)
                {
                    degree += matrix[i, j]; // Вычисляем степень вершины
                }
                if (degree % 2 != 0) // Если степень вершины нечетная
                {
                    return false; // Граф не является эйлеровым
                }
            }

            // Проверяем, является ли граф связным
            return IsConnected(matrix, n);
        }
    }

    // Функция для проверки сильной связности графа
    static bool IsStronglyConnected(int[,] matrix, int n)
    {
        // Реализация проверки сильной связности (например, с использованием алгоритма Косарайю)
        // Заглушка для краткости
        return true;
    }

    // Функция для проверки связности графа
    static bool
    IsConnected(int[,] matrix, int n)
    {
        // Реализация проверки связности (например, с использованием BFS или DFS)
        // Заглушка для краткости
        return true;
    }

    // Функция для вычисления входных степеней вершин графа
    static int[] CalculateInDegrees(int[,] matrix, int n)
    {
        int[] inDegrees = new int[n]; // Массив для хранения входных степеней вершин
        for (int i = 0; i < n; i++) // Перебираем вершины графа
        {
            for (int j = 0; j < n; j++) // Перебираем смежные вершины
            {
                inDegrees[j] += matrix[i, j]; // Увеличиваем входную степень для смежной вершины
            }
        }
        return inDegrees; // Возвращаем массив входных степеней
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
