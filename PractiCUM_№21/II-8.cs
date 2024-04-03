// 1 файл - Class
using System;
using System.IO;
namespace Programmy{
class Node
{
    public int Data { get; private set; }
    public Node Left { get; private set; }
    public Node Right { get; private set; }

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public int Height()
    {
        if (Left == null && Right == null)
            return 0;
        else if (Left == null)
            return 1 + Right.Height();
        else if (Right == null)
            return 1 + Left.Height();
        else
            return 1 + Math.Max(Left.Height(), Right.Height());
    }
}
}
// 2 файл - MAIN

using System;
using System.IO;

namespace Programmy{

class Program
{
    static void Main(string[] args)
    {
        // Чтение чисел из файла
        string[] lines = File.ReadAllLines("input.txt");
        int[] numbers = Array.ConvertAll(lines[0].Split(' '), int.Parse);

        // Создание дерева бинарного поиска
        Node root = new Node(numbers[0]);
        for (int i = 1; i < numbers.Length; i++)
        {
            root.Insert(numbers[i]);
        }

        // Вычисление высоты для каждого узла и вывод результатов
        Console.WriteLine("Высота каждого узла в дереве:");
        CalculateAndPrintHeight(root);

        Console.ReadLine(); // Для удержания окна консоли открытым
    }

    static void CalculateAndPrintHeight(Node node, int level = 0)
    {
        if (node == null)
            return;

        if (node.Left != null || node.Right != null)
        {
            Console.WriteLine($"Узел {node.Data}: {level}");
            CalculateAndPrintHeight(node.Left, level + 1);
            CalculateAndPrintHeight(node.Right, level + 1);
        }
        else
        {
            Console.WriteLine($"Лист {node.Data}: Игнорируется");
        }
    }
}
}

// 8 83 7 13 57 64 23 11 5 3
