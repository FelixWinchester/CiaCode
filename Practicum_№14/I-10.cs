using System;
using System.Collections.Generic;
using System.IO;

public class SPoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public SPoint(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

public class Program
{
    public static double Distance(SPoint point1, SPoint point2)
    {
        return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
    }

    public static Tuple<SPoint, int> FindMaxPoints(List<SPoint> points, double R)
    {
        int maxCount = 0;
        SPoint maxPoint = null;

        foreach (SPoint point in points)
        {
            int count = 0;
            foreach (SPoint otherPoint in points)
            {
                if (Distance(point, otherPoint) <= R)
                {
                    count++;
                }
            }
            if (count > maxCount)
            {
                maxCount = count;
                maxPoint = point;
            }
        }

        return new Tuple<SPoint, int>(maxPoint, maxCount);
    }

    public static void Main()
    {
        // Чтение данных из файла
        List<SPoint> points = new List<SPoint>();
        using (StreamReader sr = new StreamReader("input.txt")) // Измените путь к файлу при необходимости
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] coordinates = line.Split(' ');
                double x = double.Parse(coordinates[0]);
                double y = double.Parse(coordinates[1]);
                double z = double.Parse(coordinates[2]);
                points.Add(new SPoint(x, y, z));
            }
        }

        // Радиус шара
        double radius = 2.5;

        // Найдем точку, содержащую максимальное количество точек
        var result = FindMaxPoints(points, radius);
        SPoint maxPoint = result.Item1;
        int maxCount = result.Item2;

        // Вывод результатов в файл
        using (StreamWriter sw = new StreamWriter("output.txt")) // Измените путь к файлу при необходимости
        {
            sw.WriteLine($"Точка: ({maxPoint.X}, {maxPoint.Y}, {maxPoint.Z}) содержит {maxCount} точек внутри шара радиуса {radius}");
        }

        Console.WriteLine("Результаты записаны в output.txt");
    }
}
