using System;
using System.IO;
using Test;

namespace ConsoleApp1
{
    internal class MainProgramm
    {
        static void Main()
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                BinaryTree tree = new BinaryTree();
                string line = fileIn.ReadToEnd();
                string[] data = line.Split(' ');
                foreach (string item in data)
                {
                    tree.Add(int.Parse(item));
                }
                tree.Preorder();
                Console.WriteLine();
                tree.F();
            }
        }
    }
}

________________________________

using System;

namespace Test
{
    internal class Node
    {
        public int inf;
        public int leftcount;
        public int rightcount;
        public Node left;
        public Node right;

        public Node(int nodeInf)
        {
            inf = nodeInf;
            leftcount = 0;
            rightcount = 0;
            left = null;
            right = null;
        }

        public static void Add(ref Node r, int nodeInf)
        {
            if (r == null)
            {
                r = new Node(nodeInf);
            }
            else
            {
                if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                {
                    r.leftcount++;
                    Add(ref r.left, nodeInf);
                }
                else
                {
                    r.rightcount++;
                    Add(ref r.right, nodeInf);
                }
            }
        }

        public static void Proverka(Node t, ref bool flag, int Schet)
        {
            if (Schet == 1)
            {
                if (t != null)
                {
                    if (Math.Abs(t.leftcount - t.rightcount) > 2)
                    {
                        flag = false;
                    }
                    Proverka(t.left, ref flag, Schet);
                    Proverka(t.right, ref flag, Schet);
                }
            }
            if (Schet == 2)
            {
                if (t != null)
                {
                    Proverka(t.left, ref flag, Schet);
                    Proverka(t.right, ref flag, Schet);
                    if (Math.Abs(t.leftcount - t.rightcount) >= 2)
                    {
                        flag = false;
                    }
                }
            }
        }

        public static void Count(Node t, ref int counter)
        {
            if (t != null)
            {
                if (Math.Abs(t.leftcount - t.rightcount) == 2)
                {
                    counter++;
                }
                Count(t.left, ref counter);
                Count(t.right, ref counter);
            }
        }

        public static void F(Node t, ref bool flag, ref int counter)
        {
            int Schet = 1;
            Proverka(t, ref flag, Schet);
            if (flag)
            {
                Count(t, ref counter);
                if (counter > 1)
                {
                    flag = false;
                }
                else
                {
                    Schet = 2;
                    Proverka(t, ref flag, Schet);
                }
            }
        }

        public static void Preorder(Node r)
        {
            if (r != null)
            {
                Console.Write("{0} ", r.inf);
                Preorder(r.left);
                Preorder(r.right);
            }
        }
    }
}

______________________________________________

using System;

namespace Test
{
    internal class BinaryTree
    {
        Node tree;

        public int Root
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }

        public BinaryTree()
        {
            tree = null;
        }

        private BinaryTree(Node r)
        {
            tree = r;
        }

        public void Add(int nodeInf)
        {
            Node.Add(ref tree, nodeInf);
        }

        public void F()
        {
            int counter = 0;
            bool flag = true;
            Node.F(tree, ref flag, ref counter);
            if (flag)
            {
                Console.WriteLine("Дерево можно сделать идеально сбалансированным");
            }
            else
            {
                Console.WriteLine("Дерево нельзя идеально сбалансировать");
            }
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }
    }
}
