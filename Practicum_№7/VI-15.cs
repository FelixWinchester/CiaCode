using System;


class Program
{
    static void Main()
    {
        // Ввод количества строк в массиве
        Console.Write("Введите количество строк в массиве: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        // Ввод количества столбцов в массиве
        Console.Write("Введите количество столбцов в массиве: ");
        int columns = Convert.ToInt32(Console.ReadLine());

        // Создание двумерного массива
        int[,] array = new int[rows, columns];

        // Ввод элементов массива
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Элемент [{i}, {j}]: ");
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Вывод введенного массива
        Console.WriteLine("Введенный массив:");
        PrintArray(array);

        // Уплотнение массива
        int[,] compactedArray = CompactArray(array);

        // Вывод уплотненного массива
        Console.WriteLine("Уплотненный массив:");
        PrintArray(compactedArray);
    }

    static int[,] CompactArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        bool[] rowHasZeros = new bool[rows];
        bool[] columnHasZeros = new bool[columns];

        // Проверка строк и столбцов на наличие нулей
        for (int i = 0; i < rows; i++)
        {
            bool allZeros = true;
            for (int j = 0; j < columns; j++)
            {
                if (array[i, j] != 0)
                {
                    allZeros = false;
                    break;
                }
            }
            rowHasZeros[i] = allZeros;
        }

        for (int j = 0; j < columns; j++)
        {
            bool allZeros = true;
            for (int i = 0; i < rows; i++)
            {
                if (array[i, j] != 0)
                {
                    allZeros = false;
                    break;
                }
            }
            columnHasZeros[j] = allZeros;
        }

        // Подсчет количества ненулевых строк и столбцов
        int compactedRows = 0;
        int compactedColumns = 0;

        for (int i = 0; i < rows; i++)
        {
            if (!rowHasZeros[i])
            {
                compactedRows++;
            }
        }

        for (int j = 0; j < columns; j++)
        {
            if (!columnHasZeros[j])
            {
                compactedColumns++;
            }
        }

        // Создание уплотненного массива
        int[,] compactedArray = new int[compactedRows, compactedColumns];
        int compactedRowIndex = 0;
        int compactedColumnIndex = 0;

        for (int i = 0; i < rows; i++)
        {
            if (!rowHasZeros[i])
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!columnHasZeros[j])
                    {
                        compactedArray[compactedRowIndex, compactedColumnIndex] = array[i, j];
                        compactedColumnIndex++;
                    }
                }

                compactedRowIndex++;
                compactedColumnIndex = 0;
            }
        }

        return compactedArray;
    }

    static void PrintArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        // Вывод массива на экран
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
