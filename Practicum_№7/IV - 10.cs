// Для каждого столбца найти первый положительный элемент и записать данные в новый массив.

using System;

class Program
{
    static void Main()
    {
        // Ввод размера массива
        Console.Write("Введите размер массива n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Создание и заполнение исходного массива
        int[,] array = new int[n, n];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Массив[{i},{j}]: ");
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Создание нового массива для хранения результатов
        int[] resultArray = new int[n];

        // Нахождение первого положительного элемента для каждого столбца
        for (int j = 0; j < n; j++)
        {
            int positiveElement = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i, j] > 0)
                {
                    positiveElement = array[i, j];
                    break;
                }
            }
            resultArray[j] = positiveElement;
        }

        // Вывод результатов
        Console.WriteLine("Результаты:");
        for (int j = 0; j < n; j++)
        {
            Console.WriteLine($"Результат Массива[{j}]: {resultArray[j]}");
        }
    }
}
