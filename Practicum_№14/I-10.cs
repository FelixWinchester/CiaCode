using System;
using System.IO;
using System.Collections.Generic;

struct SPoint
{
    public double X { get; set; }
    public double Y { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Чтение данных из файла
        string[] lines = File.ReadAllLines("points.txt");
        List<SPoint> points = new List<SPoint>();
        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[1]);
            points.Add(new SPoint { X = x, Y = y });
        }

        // Поиск точки, для которой шар максимального радиуса содержит максимальное число точек
        double maxRadius = 0;
        SPoint center = new SPoint();
        foreach (SPoint point in points)
        {
            double radius = 0;
            int count = 0;
            foreach (SPoint otherPoint in points)
            {
                double distance = Math.Sqrt(Math.Pow(point.X - otherPoint.X, 2) + Math.Pow(point.Y - otherPoint.Y, 2));
                if (distance <= radius)
                {
                    count++;
                }
                else
                {
                    break;
                }
                radius++;
            }
            if (count > maxRadius)
            {
                maxRadius = count;
                center = point;
            }
        }

        // Запись результата в файл
        using (StreamWriter writer = new StreamWriter("result.txt"))
        {
            writer.WriteLine("Координаты центра: " + center.X + " " + center.Y);
            writer.WriteLine("Максимальное число точек: " + maxRadius);
        }
    }
}
/* points.txt
1 2
3 4
5 6
7 8
9 10
11 12
13 14
15 16
17 18
19 20
21 22
23 24
25 26
27 28
29 30
31 32
33 34
35 36
37 38
39 40
41 42
43 44
45 46
47 48
49 50
*/
// result.txt : Координаты центра: 1 2
   //           Максимальное число точек: 1
