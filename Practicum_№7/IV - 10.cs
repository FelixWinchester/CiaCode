using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массива n: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[,] originalArray = GenerateRandomArray(n);
            Console.WriteLine("Исходный массив:");
            PrintArray(originalArray);

            int[] firstPositiveElements = FindFirstPositiveElements(originalArray);
            Console.WriteLine("\nПервые положительные элементы каждого столбца:");
            PrintArray(firstPositiveElements);
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Введите натуральное число больше 0.");
        }
    }

    static int[,] GenerateRandomArray(int n)
    {
        int[,] array = new int[n, n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = random.Next(-10, 11); // Заполняем случайными числами от -10 до 10
            }
        }

        return array;
    }

    static void PrintArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + "\t");
        }
        Console.WriteLine();
    }

    static int[] FindFirstPositiveElements(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[] firstPositiveElements = new int[cols];

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (array[i, j] >= 0) // Условие изменено, теперь 0 считается положительным
                {
                    firstPositiveElements[j] = array[i, j];
                    break; // Найден положительный элемент, переходим к следующему столбцу
                }
            }
        }

        return firstPositiveElements;
    }
}
