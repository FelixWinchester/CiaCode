using System;
using System.IO;

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

    public bool IsBalanced()
    {
        return IsBalancedRec(root);
    }

    private bool IsBalancedRec(Node root)
    {
        if (root == null)
            return true;

        int leftHeight = Height(root.Left);
        int rightHeight = Height(root.Right);

        return Math.Abs(leftHeight - rightHeight) <= 1 &&
               IsBalancedRec(root.Left) &&
               IsBalancedRec(root.Right);
    }

    private int Height(Node node)
    {
        if (node == null)
            return 0;

        return 1 + Math.Max(Height(node.Left), Height(node.Right));
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "input.txt";
        string[] inputData = File.ReadAllText(inputFilePath).Split();

        BinarySearchTree tree = new BinarySearchTree();

        foreach (string item in inputData)
        {
            int value = int.Parse(item);
            tree.Insert(value);
        }

        bool isBalanced = tree.IsBalanced();
        Console.WriteLine($"Is the tree balanced? {isBalanced}");
    }
}

50 30 70 20 40 60 80 10 25 35 45 55 65 75 85
