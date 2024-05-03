using System;
using System.Collections.Generic;
using System.IO;

namespace Gagik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Чтение входного файла
            string input = File.ReadAllText("input.txt");

            // Разбиение входной строки на отдельные числа
            string[] numbersAsString = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Преобразование входных данных в список целых чисел
            List<int> numbers = new List<int>();
            foreach (string numStr in numbersAsString)
            {
                numbers.Add(int.Parse(numStr));
            }

            // Построение бинарного дерева поиска
            BinarySearchTree tree = new BinarySearchTree();
            foreach (int number in numbers)
            {
                tree.Insert(number);
            }

            // Проверка, является ли дерево идеально сбалансированным
            bool isPerfectlyBalanced = tree.IsPerfectlyBalanced();

            // Вывод результата
            Console.WriteLine("Является ли дерево идеально сбалансированным?: " + isPerfectlyBalanced);
        }
    }
}

------______________-----------

using System;
using System.Collections.Generic;
using System.IO;

namespace Gagik
{
    // Класс BinarySearchTree представляет бинарное дерево поиска
    public class BinarySearchTree
    {
        // Корневой узел дерева
        public Node Root { get; set; }

        // Метод вставки значения в дерево
        public void Insert(int value)
        {
            // Если дерево пустое, создать корневой узел
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                // Вставка значения в соответствующее поддерево
                Insert(Root, value);
            }
        }

        // Рекурсивный метод вставки значения в поддерево
        private void Insert(Node node, int value)
        {
            // Если значение меньше, чем узел, и нет левого поддерева, создать новый узел слева
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    // Рекурсивно вставить значение в левое поддерево
                    Insert(node.Left, value);
                }
            }
            else
            {
                // Если значение больше или равно узлу и нет правого поддерева, создать новый узел справа
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    // Рекурсивно вставить значение в правое поддерево
                    Insert(node.Right, value);
                }
            }
        }

        // Метод проверки сбалансированности дерева
        public bool IsPerfectlyBalanced()
        {
            return IsPerfectlyBalanced(Root);
        }

        // Рекурсивный метод проверки сбалансированности поддерева
        private bool IsPerfectlyBalanced(Node node)
        {
            // Если узел пустой, он считается сбалансированным
            if (node == null)
            {
                return true;
            }

            // Вычисление высот левого и правого поддеревьев
            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            // Проверка сбалансированности и рекурсивная проверка для левого и правого поддеревьев
            return Math.Abs(leftHeight - rightHeight) <= 1 &&
                IsPerfectlyBalanced(node.Left) &&
                IsPerfectlyBalanced(node.Right);
        }

        // Метод вычисления высоты поддерева
        private int GetHeight(Node node)
        {
            // Если узел пустой, высота равна 0
            if (node == null)
            {
                return 0;
            }

            // Рекурсивно вычислить высоту левого и правого поддеревьев и вернуть максимум плюс один
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
    }

    // Класс Node представляет узел в бинарном дереве поиска
    public class Node
    {
        // Значение узла
        public int Value { get; set; }
        
        // Левое и правое поддеревья
        public Node Left { get; set; }
        public Node Right { get; set; }

        // Конструктор узла с заданным значением
        public Node(int value)
        {
            Value = value;
        }
    }
}

15 7 23 3 11 18 26 1 5 9 13 17 21 25 29 2 4 6 8 10 112 
