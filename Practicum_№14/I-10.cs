using System; // подключение пространства имен System
using System.IO; // подключение пространства имен System.IO
using System.Collections.Generic; // подключение пространства имен System.Collections.Generic

struct SPoint // объявление структуры SPoint
{
    public double X { get; set; } // объявление свойства X типа double
    public double Y { get; set; } // объявление свойства Y типа double
}

class Program // объявление класса Program
{
    static void Main(string[] args) // объявление метода Main с массивом аргументов args
    {
        // Чтение данных из файла
        string[] lines = File.ReadAllLines("points.txt"); // чтение строк из файла "points.txt"
        List<SPoint> points = new List<SPoint>(); // создание списка точек
        foreach (string line in lines) // цикл по строкам файла
        {
            string[] parts = line.Split(' '); // разделение строки на части по пробелу
            double x = double.Parse(parts[0]); // парсинг первой части как X
            double y = double.Parse(parts[1]); // парсинг второй части как Y
            points.Add(new SPoint { X = x, Y = y }); // добавление новой точки в список
        }

        // Поиск точки, для которой шар максимального радиуса содержит максимальное число точек
        double maxRadius = 0; // инициализация переменной maxRadius
        SPoint center = new SPoint(); // инициализация переменной center
        foreach (SPoint point in points) // цикл по точкам
        {
            double radius = 0; // инициализация переменной radius
            int count = 0; // инициализация переменной count
            foreach (SPoint otherPoint in points) // вложенный цикл по другим точкам
            {
                double distance = Math.Sqrt(Math.Pow(point.X - otherPoint.X, 2) + Math.Pow(point.Y - otherPoint.Y, 2)); // вычисление расстояния между точками
                if (distance <= radius) // проверка условия
                {
                    count++; // увеличение счетчика
                }
                else
                {
                    break; // выход из цикла
                }
                radius++; // увеличение радиуса
            }
            if (count > maxRadius) // проверка условия
            {
                maxRadius = count; // присваивание нового значения maxRadius
                center = point; // присваивание нового значения center
            }
        }

        // Запись результата в файл
        using (StreamWriter writer = new StreamWriter("result.txt")) // использование StreamWriter для записи в файл "result.txt"
        {
            writer.WriteLine("Координаты центра: " + center.X + " " + center.Y); // запись координат центра в файл
            writer.WriteLine("Максимальное число точек: " + maxRadius); // запись максимального числа точек в файл
        }
    }
}
