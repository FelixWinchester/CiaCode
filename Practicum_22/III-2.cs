using System; // Подключаем пространство имен для базовых классов и функций .NET
using System.Collections.Generic; // Подключаем пространство имен для работы с коллекциями
using System.IO; // Подключаем пространство имен для работы с файлами и потоками
using System.Linq; // Подключаем пространство имен для работы с LINQ запросами

class Program // Объявляем класс программы
{
    public struct City // Определяем структуру для хранения информации о городах
    {
        public string Name; // Название города
        public int X; // Координата X
        public int Y; // Координата Y
        public City(string name, int x, int y) // Конструктор для структуры City
        {
            Name = name; // Инициализируем название города
            X = x; // Инициализируем координату X
            Y = y; // Инициализируем координату Y
        }
    }

    static void Main(string[] args) // Главная функция программы
    {
        // Читаем входные данные из файла
        string[] lines = File.ReadAllLines("input.txt");
        int N = int.Parse(lines[0]); // Количество городов

        // Считываем информацию о городах
        City[] cities = new City[N]; // Массив городов
        Dictionary<string, int> cityIndex = new Dictionary<string, int>(); // Словарь для хранения индексов городов
        for (int i = 0; i < N; i++) // Проходим по всем городам
        {
            var parts = lines[i + 1].Split(); // Разбиваем строку на части
            string name = parts[0]; // Название города
            int x = int.Parse(parts[1]); // Координата X
            int y = int.Parse(parts[2]); // Координата Y
            cities[i] = new City(name, x, y); // Создаем экземпляр города
            cityIndex[name] = i; // Записываем индекс города в словарь
        }

        // Считываем матрицу смежности
        int[,] adjacencyMatrix = new int[N, N]; // Матрица смежности
        for (int i = 0; i < N; i++) // Проходим по строкам матрицы
        {
            var parts = lines[N + 1 + i].Split(); // Разбиваем строку на части
            for (int j = 0; j < N; j++) // Проходим по столбцам матрицы
            {
                adjacencyMatrix[i, j] = int.Parse(parts[j]); // Заполняем элемент матрицы
            }
        }

        // Получаем названия городов A, B и D от пользователя
        Console.Write("Город A: ");
        string cityA = Console.ReadLine();
        Console.Write("Город B: ");
        string cityB = Console.ReadLine();
        Console.Write("Город D: ");
        string cityD = Console.ReadLine();

        // Проверяем наличие введенных городов в словаре
        if (!cityIndex.ContainsKey(cityA) || !cityIndex.ContainsKey(cityB) || !cityIndex.ContainsKey(cityD))
        {
            Console.WriteLine("Некорректное имя города.");
            return; // В случае ошибки завершаем выполнение программы
        }

        // Получаем индексы городов A, B и D
        int indexA = cityIndex[cityA];
        int indexB = cityIndex[cityB];
        int indexD = cityIndex[cityD];

        // Создаем матрицу расстояний между городами
        double[,] distanceMatrix = new double[N, N];
        for (int i = 0; i < N; i++) // Проходим по всем городам
        {
            for (int j = 0; j < N; j++) // Проходим по всем городам
            {
                if (adjacencyMatrix[i, j] == 1) // Если есть дорога между городами
                {
                    distanceMatrix[i, j] = CalculateDistance(cities[i], cities[j]); // Вычисляем расстояние между городами
                }
                else
                {
                    distanceMatrix[i, j] = double.PositiveInfinity; // Устанавливаем бесконечное расстояние, если нет дороги
                }
            }
        }

        // Выполняем алгоритм Дейкстры для поиска кратчайшего пути
        double distanceWithoutD = Dijkstra(distanceMatrix, indexA, indexB, indexD);

        // Выводим результат
        if (distanceWithoutD == double.PositiveInfinity) // Если путь не найден
        {
            Console.WriteLine("Нельзя пройти дальше. " + cityD);
        }
        else
        {
            Console.WriteLine("Кратчайший путь из города " + cityA + " в " + cityB + " избегая город " + cityD + " равен: " + distanceWithoutD);
        }
    }

    // Реализация алгоритма Дейкстры
    static double Dijkstra(double[,] distanceMatrix, int start, int end, int avoid)
    {
        int N = distanceMatrix.GetLength(0); // Получаем количество городов
        bool[] visited = new bool[N]; // Массив для отслеживания посещенных городов
        double[] distances = new double[N]; // Массив для хранения расстояний до городов
        for (int i = 0; i < N; i++) // Проходим по всем городам
        {
            distances[i] = double.PositiveInfinity; // Устанавливаем начальные расстояния как бесконечность
        }
        distances[start] = 0; // Устанавливаем начальное расстояние для стартового города

        for (int i = 0; i < N; i++) // Выполняем итерации алгоритма для всех городов
        {
           
            int u = -1; // Индекс текущего города
            for (int j = 0; j < N; j++) // Поиск непосещенного города с минимальным расстоянием
            {
                if (!visited[j] && (u == -1 || distances[j] < distances[u]))
                {
                    u = j; // Обновляем текущий город
                }
            }

            if (u == -1 || distances[u] == double.PositiveInfinity) // Если не найден следующий город для посещения
            {
                break; // Завершаем выполнение алгоритма
            }

            visited[u] = true; // Отмечаем текущий город как посещенный

            for (int v = 0; v < N; v++) // Обновляем расстояния до соседних городов
            {
                if (!visited[v] && distanceMatrix[u, v] != double.PositiveInfinity && u != avoid && v != avoid)
                {
                    double newDist = distances[u] + distanceMatrix[u, v]; // Вычисляем новое расстояние
                    if (newDist < distances[v]) // Если новое расстояние меньше текущего
                    {
                        distances[v] = newDist; // Обновляем расстояние
                    }
                }
            }
        }

        return distances[end]; // Возвращаем кратчайшее расстояние до конечного города
    }

    // Вычисление евклидова расстояния между двумя городами
    static double CalculateDistance(City city1, City city2)
    {
        return Math.Sqrt(Math.Pow(city2.X - city1.X, 2) + Math.Pow(city2.Y - city1.Y, 2)); // Вычисляем расстояние по формуле
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
