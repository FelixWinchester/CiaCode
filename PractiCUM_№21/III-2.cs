using System;
using System.IO;

class Node
{
    public readonly int Data;
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int data)
    {
        Data = data;
    }
}

class Tree
{
    public Node RootNode { get; private set; }

    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (RootNode == null)
        {
            RootNode = newNode;
            return;
        }

        Node currentNode = RootNode;
        while (true)
        {
            if (newNode.Data == currentNode.Data)
                throw new Exception("Дерево не может содержать 2 одинаковых узла");
            // Новый узел будет определен в левую часть дерева
            else if (newNode.Data < currentNode.Data)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    return;
                }
                currentNode = currentNode.Left;
            }
            // Новый узел будет определен в правую часть дерева
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    return;
                }
                currentNode = currentNode.Right;
            }
        }
    }

    // Проверка идеальной сбалансированности дерева
    public bool IsBalanced()
    {
        return CheckBalance(RootNode) != -1;
    }

    // Рекурсивная функция для проверки баланса
    private int CheckBalance(Node node)
    {
        if (node == null)
            return 0;

        // Рекурсивно получаем высоту левого поддерева
        int leftHeight = CheckBalance(node.Left);
        if (leftHeight == -1)
            return -1; // Несбалансированное поддерево, прерываем проверку

        // Рекурсивно получаем высоту правого поддерева
        int rightHeight = CheckBalance(node.Right);
        if (rightHeight == -1)
            return -1; // Несбалансированное поддерево, прерываем проверку

        // Проверяем, сбалансировано ли текущее поддерево
        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1; // Несбалансированное поддерево

        // Возвращаем высоту текущего поддерева
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}

class Program
{
    static void Main()
    {
        // Путь к файлу
        string filePath = "input.txt";

        // Проверка наличия файла
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }

        // Создание экземпляра дерева
        Tree tree = new Tree();

        // Чтение данных из файла и добавление их в дерево
        try
        {
            string[] values = File.ReadAllText(filePath).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string value in values)
            {
                int num;
                if (int.TryParse(value, out num))
                {
                    tree.Add(num);
                }
                else
                {
                    Console.WriteLine($"Ошибка чтения данных из файла: Некорректное значение \"{value}\"");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения данных из файла: {ex.Message}");
            return;
        }

        // Проверка на идеальную сбалансированность дерева
        if (tree.IsBalanced())
            Console.WriteLine("Дерево идеально сбалансировано");
        else
            Console.WriteLine("Дерево не является идеально сбалансированным");

        Console.ReadKey();
    }
}

50 25 75 10 40 60 80 5 15 30 45 55 70 85
