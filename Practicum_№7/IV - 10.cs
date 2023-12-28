using System;

class Program
{
    static void Main()
    {
        // Задаем размерность массива
        Console.Write("Введите размерность массива n: ");
        int n = int.Parse(Console.ReadLine());

        // Инициализируем массив и заполняем его случайными значениями
        int[,] originalArray = new int[n, n];
        Random random = new Random();

        Console.WriteLine("Исходный массив:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                originalArray[i, j] = random.Next(-10, 11); // Заполняем элементы случайными значениями от -10 до 10
                Console.Write(originalArray[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Создаем новый массив для хранения первых положительных элементов каждого столбца
        int[] firstPositiveElements = new int[n];

        // Находим первый положительный элемент для каждого столбца
        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < n; i++)
            {
                if (originalArray[i, j] > 0)
                {
                    firstPositiveElements[j] = originalArray[i, j];
                    break;
                }
            }
        }

        // Выводим результаты
        Console.WriteLine("\nМассив первых положительных элементов каждого столбца:");
        for (int j = 0; j < n; j++)
        {
            Console.Write(firstPositiveElements[j] + " ");
        }

        Console.ReadLine(); // Для удобства просмотра результатов
    }
}
