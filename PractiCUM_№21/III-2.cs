using System;
using System.IO;
using System.Text;

namespace Pr21_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader("input.txt", Encoding.GetEncoding(0)))
            {
                using (StreamWriter fileOut = new StreamWriter("output.txt", false))
                {
                    string line = fileIn.ReadToEnd();
                    char[] sep = { ' ', '\n', '\r', '\t', '.' }; //массив разделителей
                    string[] numbers = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    int[] mas = new int [numbers.Length];
                    for (int i = 0; i < numbers.Length; i++)
                        mas[i] = int.Parse(numbers[i]);
                    BinaryTree tree = new BinaryTree();
                    foreach (int item in mas)
                    {
                        tree.Add(item);
                    }
                    if (tree.CheckBalance()) Console.WriteLine("Дерево идеально сбалансированное");
                    else Console.WriteLine("Дерево не идеально сбалансированное");

                }
            }
        }
    }
}

_______________________________________


using System;
using System.Collections.Generic;

namespace Pr21_2
{
    public class BinaryTree
    {
        //вложенный класс, отвечающий за узлы и операции допустимы для дерева бинарного
        //поиска
        private class Node
        {
            public object inf; //информационное поле
            public Node left; //ссылка на левое поддерево
            public Node right; //ссылка на правое поддерево
                               //конструктор вложенного класса, создает узел дерева
            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                right = null;
            }
            //добавляет узел в дерево так, чтобы дерево оставалось деревом бинарного поиска
            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.right, nodeInf);
                    }
                }
            }

            public static void Preorder(Node r) //прямой обход дерева
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.right);
                }
            }
            public static void Inorder(Node r) //симметричный обход дерева
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ", r.inf);
                    Inorder(r.right);
                }
            }
            public static void Postorder(Node r) //обратный обход дерева
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.right);
                    Console.Write("{0} ", r.inf);
                }
            }
            public static void Degree1(Node r, ref int count) //прямой обход дерева с поиском узлов со степенью 1
            {
                if (r != null)
                {
                    if ((r.left == null && r.right != null) || (r.left != null && r.right == null))
                        count++;
                    Degree1(r.left, ref count);
                    Degree1(r.right, ref count);

                }
            }
            
            public static void SummLev(Node r, ref int count, ref int summ, int level) 
            {
                if (r != null)
                {
                    //Console.Write("{0} ", r.inf);
                    //Console.Write("({0}) ", count);
                    if (count >= level) summ += (int)r.inf;
                    count++;
                    SummLev(r.left, ref count, ref summ, level);
                    SummLev(r.right, ref count, ref summ, level);
                    count--;
                }
            }

            public int ZeroInf;
            public int LeftCount = -1;
            public int RightCount = -1;
            public static void CheckBalance(Node r, ref int count)
            {
                if (r != null)
                {
                    if (count == -1) r.ZeroInf = (int) r.inf;
                    count++;
                    //Console.Write("{0} ", r.inf);
                    //Console.Write("({0}) ", count);
                    CheckBalance(r.left, ref count);
                    if ((int)r.inf == r.ZeroInf) r.LeftCount = count;
                    CheckBalance(r.right, ref count);
                    r.RightCount = count - r.LeftCount;
                }
            }
            //поиск ключевого узла в дереве
            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }
                        else
                        {
                            Search(r.right, key, out item);
                        }
                    }
                }
            }
            //методы Del и Delete позволяют удалить узел в дереве так, чтобы дерево при этом
            //оставалось деревом бинарного поиска
            private static void Del(Node t, ref Node tr)
            {
                if (tr.right != null)
                {
                    Del(t, ref tr.right);
                }
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }
            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                {
                    throw new Exception("Данное значение в дереве отсутствует");
                }
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0)
                    {
                        Delete(ref t.left, key);
                    }
                    else
                    {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0)
                        {
                            Delete(ref t.right, key);
                        }
                        else
                        {
                            if (t.left == null)
                            {
                                t = t.right;
                            }
                            else
                            {
                                if (t.right == null)
                                {
                                    t = t.left;
                                }
                                else
                                {
                                    Del(t, ref t.left);
                                }
                            }
                        }
                    }
                }
            }
        } //конец вложенного класса
        Node tree; //ссылка на корень дерева
                   //свойство позволяет получить доступ к значению информационного поля корня дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public BinaryTree() //открытый конструктор
        {
            tree = null;
        }
        private BinaryTree(Node r) //закрытый конструктор
        {
            tree = r;
        }
        public void Add(object nodeInf) //добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }
        //организация различных способов обхода дерева
        public void Preorder()
        {
            Node.Preorder(tree);
        }
        public void Inorder()
        {
            Node.Inorder(tree);
        }
        public void Postorder()
        {
            Node.Postorder(tree);
        }
        public void Degree1(ref int count)
        {
            Node.Degree1(tree, ref count);
        }
        public void SummLev(ref int count, ref int summ, int level)
        {
            Node.SummLev(tree, ref count, ref summ, level);
        }
        public bool CheckBalance()
        {
            int count = -1;
            Node.CheckBalance(tree, ref count);
            Console.WriteLine("Левое поддерево = {0}\nПравое поддерево = {1}", tree.LeftCount, tree.RightCount);
            if (Math.Abs(tree.LeftCount - tree.RightCount) <= 1) return true;
            else return false;
        }
        //поиск ключевого узла в дереве
        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            BinaryTree t = new BinaryTree(r);
            return t;
        }
        //удаление ключевого узла в дереве
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }
    }
}


//45 17 23 56 16 6 19 80 49 101 14 0 95    
//10 7 25 31 18 6 3 12 22 8    
//9 53 51 44 30 16 87 36 8 65  
//48 38 18 23 67 44 2 76 54 45 
//4 6 
