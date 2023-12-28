using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //демонстрация работы методов класса
        IntArray a1 = IntArray.ConsoleInput();
        Console.WriteLine("Вывод массива");
        Console.WriteLine(a1.ToString());
        a1.Sort();
        Console.WriteLine("Массив после сортировки");
        Console.WriteLine(a1.ToString());
        Console.WriteLine();
        Console.WriteLine();

        //демонстрация перегрузок операций
        //++
        Console.WriteLine("Операция ++");
        IntArray a2 = a1++;
        Console.WriteLine(a2.ToString());
        Console.WriteLine(a1.ToString());
        Console.WriteLine();
        //--
        Console.WriteLine("Операция --");
        a2 = a1--;
        Console.WriteLine(a2.ToString());
        Console.WriteLine(a1.ToString());
        Console.WriteLine();
        //!
        Console.WriteLine("Операция !");
        int[] a3 = { 5, 4, 3, 2, 1 };
        a2 = new IntArray(a3);
        Console.WriteLine(!a1); //элементы a1 упорядочены по возрастанию
        Console.WriteLine(!a2); //элементы a2 не упорядочены по возрастанию
        Console.WriteLine();
        //*
        Console.WriteLine("Операция умножения");
        Console.WriteLine("Введите целое число: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine((a1 * b).ToString());
        Console.WriteLine((b * a1).ToString());
        Console.WriteLine();
        //приведение типов
        Console.WriteLine("Приведение типов");
        Array.Sort(a2); //применяю метод класса Array к IntArray
        Console.WriteLine(a1.ToString());
        Console.WriteLine();
        Console.WriteLine();

        //Свойства класса
        Console.WriteLine("Свойства");
        Console.WriteLine("Размер введенного массива равен {0}", a1.Size);
        Console.WriteLine("Умножение всех элементов массива на скаляр");
        Console.WriteLine("Введите целое число: ");
        b = int.Parse(Console.ReadLine());
        a1.Multiply = b;
        Console.WriteLine(a1.ToString());
        Console.WriteLine();
        Console.WriteLine();

        //конструкторы
        Console.WriteLine("Пустой конструктор");
        IntArray z1 = new IntArray();
        Console.WriteLine(z1.ToString());
        Console.WriteLine();
        Console.WriteLine("Конструктор, позволяющий создать массив размерности n");
        Console.WriteLine("Введите число: ");
        int n = int.Parse(Console.ReadLine());
        z1 = new IntArray(n);
        Console.WriteLine(z1.ToString());
        Console.WriteLine();
        Console.WriteLine("Конструктор, использующий целочиленный массив в качестве аргумента");
        int[] t = { 5, 4, 3, 2, 1 };
        z1 = new IntArray(t);
        Console.WriteLine(z1.ToString());
        Console.WriteLine();
        Console.WriteLine();

        //обращение по индексу
        Console.WriteLine("Обращаюсь к элементам класса по индексу");
        Console.WriteLine(z1[4]);
        Console.WriteLine(z1[2]);
        //Console.WriteLine(z1[-5]); //демонстрация работы исключений
    }
}
