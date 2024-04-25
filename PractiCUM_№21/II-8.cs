using System;
using System.IO;

class Node
{
    private int data;
    private Node left;
    private Node right;

    public Node(int value)
    {
        data = value;
        left = null;
        right = null;
    }

    public void Insert(int value)
    {
        if (value < data)
        {
            if (left == null)
                left = new Node(value);
            else
                left.Insert(value);
        }
        else
        {
            if (right == null)
                right = new Node(value);
            else
                right.Insert(value);
        }
    }

    private int Height(Node node)
    {
        if (node == null)
            return -1;
        else
        {
            int leftHeight = Height(node.left);
            int rightHeight = Height(node.right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }

    public void PrintHeights()
    {
        PrintHeightsRecursive(this);
    }

    private void PrintHeightsRecursive(Node node)
    {
        if (node != null)
        {
            PrintHeightsRecursive(node.left);
            Console.WriteLine($"Node with data {node.data} has height {Height(node)}");
            PrintHeightsRecursive(node.right);
        }
    }
}

class Program
{
    static void Main()
    {
        // Чтение данных из файла
        string input = File.ReadAllText("input.txt");
        string[] numbers = input.Split(' ');

        // Построение дерева бинарного поиска
        Node root = null;
        foreach (string number in numbers)
        {
            int value = int.Parse(number);
            if (root == null)
                root = new Node(value);
            else
                root.Insert(value);
        }

        // Вывод высот узлов дерева
        root.PrintHeights();
    }
}

5 3 8 2 4 7 9 1 6 10 12 11 15 13 14
