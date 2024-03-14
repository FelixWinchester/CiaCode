// 1 файл
using System;
using System.IO;

namespace Prog{

class Program
{
    static void Main()
    {
        // Чтение данных из файла input.txt
        string input = File.ReadAllText("input.txt");
        string[] numbers = input.Split(' ');

        BinaryTree tree = new BinaryTree();

        // Построение дерева бинарного поиска
        foreach (string number in numbers)
        {
            int value = int.Parse(number);
            tree.Insert(value);
        }

        // Проверка на сбалансированность
        if (tree.IsBalanced(tree.root))
            Console.WriteLine("Дерево является идеально сбалансированным.");
        else
            Console.WriteLine("Дерево не является идеально сбалансированным.");
    }
  }
}
// 2 файл
using System;

namespace Prog{
    class TreeNode
{
    public int data;
    public TreeNode left, right;

    public TreeNode(int value)
    {
        data = value;
        left = right = null;
    }
}

class BinaryTree
{
    public TreeNode root;

    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    TreeNode InsertRec(TreeNode root, int value)
    {
        if (root == null)
        {
            root = new TreeNode(value);
            return root;
        }

        if (value < root.data)
            root.left = InsertRec(root.left, value);
        else if (value > root.data)
            root.right = InsertRec(root.right, value);

        return root;
    }

    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
            return true;

        int leftHeight = Height(root.left);
        int rightHeight = Height(root.right);

        return Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    int Height(TreeNode node)
    {
        if (node == null)
            return 0;

        return 1 + Math.Max(Height(node.left), Height(node.right));
    }
  }
}
// input
5 3 8 2 4 6 9
