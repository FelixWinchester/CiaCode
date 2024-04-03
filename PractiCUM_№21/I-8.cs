// 1 файл - CLASS
using System;
using System.IO;
namespace Programmy{
public class Node
{
    private int data;
    private Node left;
    private Node right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }

    public int Data
    {
        get { return data; }
        set { data = value; }
    }

    public Node Left
    {
        get { return left; }
        set { left = value; }
    }

    public Node Right
    {
        get { return right; }
        set { right = value; }
    }
}

public class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
            root.Left = InsertRec(root.Left, data);
        else if (data > root.Data)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public int FindLargestLeafValue()
    {
        Node current = root;

        while (current.Right != null)
            current = current.Right;

        return current.Data;
    }
}

}

// 2 файл - MAIN

using System;
using System.IO;
namespace Programmy{
public class Program
{
    public static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();

        // Считываем последовательность целых чисел из файла input.txt
        string[] lines = File.ReadAllLines("input.txt");
        foreach (string line in lines)
        {
            string[] numbers = line.Split(' ');
            foreach (string number in numbers)
            {
                int num;
                if (int.TryParse(number, out num))
                    bst.Insert(num);
            }
        }

        // Находим наибольшее из значений листьев
        int largestLeafValue = bst.FindLargestLeafValue();
        Console.WriteLine("Наибольшее значение листьев: " + largestLeafValue);
    }
}
}

// Input

// 8 83 7 13 57 64 13 11 5 3
