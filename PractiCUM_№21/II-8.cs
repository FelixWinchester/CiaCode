using System;
using System.Collections.Generic;
using System.IO;

namespace Gagik{
class Program
{
    static void Main(string[] args)
    {
        // Считываем содержимое файла
        string input = File.ReadAllText("input.txt");

        // Разбиваем строку ввода на отдельные числа
        string[] numbersAsString = input.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Преобразуем ввод в массив целых чисел
        int[] numbers = Array.ConvertAll(numbersAsString, int.Parse);

        // Строим двоичное дерево поиска на основе введенных чисел
        BinarySearchTree tree = new BinarySearchTree();
        foreach (int number in numbers)
        {
            tree.Insert(number);
        }

        // Рассчитываем высоту каждого узла в дереве
        foreach (BinarySearchTreeNode node in tree.GetNodes())
        {
            int height = tree.GetHeight(node);
            Console.WriteLine($"Узел {node.Value} имеет высоту {height}");
        }
    }
}

}


_____________------------___________

using System;
using System.Collections.Generic;
using System.IO;

namespace Gagik{

// Класс для представления бинарного дерева поиска
class BinarySearchTree
{
    // Корень дерева
    public BinarySearchTreeNode Root { get; private set; }

    // Метод для вставки значения в дерево
    public void Insert(int value)
    {
        // Если дерево пустое, создаем корень
        if (Root == null)
        {
            Root = new BinarySearchTreeNode(value);
        }
        // Иначе вызываем рекурсивный метод вставки для корня
        else
        {
            Root.Insert(value);
        }
    }

    // Метод для получения всех узлов дерева
    public IEnumerable<BinarySearchTreeNode> GetNodes()
    {
        // Если корень не равен null, возвращаем его и все его дочерние узлы
        if (Root != null)
        {
            yield return Root;
            foreach (BinarySearchTreeNode node in Root.GetNodes())
            {
                yield return node;
            }
        }
    }

    // Метод для получения высоты узла в дереве
    public int GetHeight(BinarySearchTreeNode node)
    {
        // Если узел null, возвращаем 0
        if (node == null)
        {
            return 0;
        }

        // Рекурсивно находим высоты левого и правого поддеревьев и выбираем максимальную
        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}

// Класс для представления узла бинарного дерева поиска
class BinarySearchTreeNode
{
    // Значение узла
    public int Value { get; private set; }
    // Левый потомок
    public BinarySearchTreeNode Left { get; private set; }
    // Правый потомок
    public BinarySearchTreeNode Right { get; private set; }

    // Конструктор узла с заданным значением
    public BinarySearchTreeNode(int value)
    {
        Value = value;
    }

    // Метод для вставки значения в поддерево с корнем в текущем узле
    public void Insert(int value)
    {
        // Если значение меньше значения текущего узла, вставляем в левое поддерево
        if (value < Value)
        {
            // Если левый потомок пуст, создаем новый узел, иначе вызываем метод вставки для левого потомка
            if (Left == null)
            {
                Left = new BinarySearchTreeNode(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        // Если значение больше значения текущего узла, вставляем в правое поддерево
        else if (value > Value)
        {
            // Если правый потомок пуст, создаем новый узел, иначе вызываем метод вставки для правого потомка
            if (Right == null)
            {
                Right = new BinarySearchTreeNode(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }

    // Метод для получения всех узлов поддерева с корнем в текущем узле
    public IEnumerable<BinarySearchTreeNode> GetNodes()
    {
        // Если левый потомок не равен null, возвращаем все узлы из левого поддерева
        if (Left != null)
        {
            foreach (BinarySearchTreeNode node in Left.GetNodes())
            {
                yield return node;
            }
        }

        // Возвращаем текущий узел
        yield return this;

        // Если правый потомок не равен null, возвращаем все узлы из правого поддерева
        if (Right != null)
        {
            foreach (BinarySearchTreeNode node in Right.GetNodes())
            {
                yield return node;
            }
        }
    }
}
}



101 123 156 134 145 178 12 34 56 78 90 112 167 189 190 201 212 223 234 245
