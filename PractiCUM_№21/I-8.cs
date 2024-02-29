using System; // Подключение пространства имен System для работы с базовыми классами и структурами .NET
using System.IO; // Подключение пространства имен System.IO для работы с файловой системой

public class Node
{
    public int Data; // Значение узла
    public Node Left, Right; // Ссылки на левого и правого потомка узла

    public Node(int data) // Конструктор класса Node, принимает значение узла
    {
        Data = data;
        Left = Right = null; // Инициализация ссылок на потомков как null
    }
}

public class BinarySearchTree
{
    public Node root; // Корневой узел дерева

    public BinarySearchTree() // Конструктор класса BinarySearchTree
    {
        root = null; // Инициализация корневого узла как null
    }

    public void Insert(int data) // Метод вставки значения в дерево
    {
        root = InsertRecursive(root, data); // Вызов рекурсивного метода вставки
    }

    private Node InsertRecursive(Node root, int data) // Рекурсивный метод вставки значения в дерево
    {
        if (root == null) // Если текущий узел пустой
        {
            root = new Node(data); // Создаем новый узел с переданным значением
            return root;
        }

        if (data < root.Data) // Если значение меньше значения текущего узла
            root.Left = InsertRecursive(root.Left, data); // Рекурсивно вставляем значение в левое поддерево
        else if (data > root.Data) // Если значение больше значения текущего узла
            root.Right = InsertRecursive(root.Right, data); // Рекурсивно вставляем значение в правое поддерево

        return root; // Возвращаем корень поддерева
    }

    public int FindMaxLeaf() // Метод для поиска максимального значения среди листьев дерева
    {
        if (root == null) // Если дерево пустое
            throw new InvalidOperationException("Tree is empty"); // Генерируем исключение

        return FindMaxLeafRecursive(root); // Вызов рекурсивного метода поиска максимального значения
    }

    private int FindMaxLeafRecursive(Node node) // Рекурсивный метод поиска максимального значения среди листьев
    {
        if (node.Left == null && node.Right == null) // Если текущий узел - лист
            return node.Data; // Возвращаем его значение

        int maxLeft = int.MinValue; // Переменная для хранения максимального значения в левом поддереве
        int maxRight = int.MinValue; // Переменная для хранения максимального значения в правом поддереве

        if (node.Left != null) // Если есть левый потомок
            maxLeft = FindMaxLeafRecursive(node.Left); // Рекурсивно ищем максимальное значение в левом поддереве

        if (node.Right != null) // Если есть правый потомок
            maxRight = FindMaxLeafRecursive(node.Right); // Рекурсивно ищем максимальное значение в правом поддереве

        return Math.Max(node.Data, Math.Max(maxLeft, maxRight)); // Возвращаем максимальное из трех значений
    }
}

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt"); // Чтение строк из файла input.txt

        BinarySearchTree tree = new BinarySearchTree(); // Создание объекта бинарного дерева

        foreach (string line in lines) // Итерация по строкам файла
        {
            if (int.TryParse(line, out int value)) // Попытка преобразовать строку в целое число
            {
                tree.Insert(value); // Вставка числа в дерево
            }
            else
            {
                Console.WriteLine($"Invalid input: {line}"); // Вывод сообщения об ошибке, если строка не удалось преобразовать в число
            }
        }

        try
        {
            int maxLeafValue = tree.FindMaxLeaf(); // Поиск максимального значения среди листьев дерева
            Console.WriteLine($"Max value of leaf nodes: {maxLeafValue}"); // Вывод максимального значения
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message); // Обработка исключения при пустом дереве
        }
    }
}
/*
5
3
88
10
4
6
9
8
100
*/
