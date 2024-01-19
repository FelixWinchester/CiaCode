using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите размеры массива (через пробел):");
        string[] dimensions = Console.ReadLine().Split();
        int numRows = int.Parse(dimensions[0]);
        int numCols = int.Parse(dimensions[1]);

        int[,] originalArray = new int[numRows, numCols];

        Console.WriteLine("Введите элементы массива построчно (через пробел):");
        for (int i = 0; i < numRows; i++)
        {
            string[] rowElements = Console.ReadLine().Split();
            for (int j = 0; j < numCols; j++)
            {
                originalArray[i, j] = int.Parse(rowElements[j]);
            }
        }

        Console.WriteLine("\nИсходный массив:");
        PrintArray(originalArray);

        CompactArray(ref originalArray);

        Console.WriteLine("\nУплотненный массив (перезаписанный в исходном массиве):");
        PrintArray(originalArray);
    }

    static void CompactArray(ref int[,] originalArray)
    {
        int numRows = originalArray.GetLength(0);
        int numCols = originalArray.GetLength(1);

        // Найти количество ненулевых строк и столбцов
        int nonZeroRows = 0;
        int nonZeroCols = 0;

        for (int i = 0; i < numRows; i++)
        {
            bool hasNonZero = false;
            for (int j = 0; j < numCols; j++)
            {
                if (originalArray[i, j] != 0)
                {
                    hasNonZero = true;
                    break;
                }
            }

            if (hasNonZero)
            {
                nonZeroRows++;
            }
        }

        for (int j = 0; j < numCols; j++)
        {
            bool hasNonZero = false;
            for (int i = 0; i < numRows; i++)
            {
                if (originalArray[i, j] != 0)
                {
                    hasNonZero = true;
                    break;
                }
            }

            if (hasNonZero)
            {
                nonZeroCols++;
            }
        }

        // Создать временный массив для перезаписи
        int[,] tempArray = new int[nonZeroRows, nonZeroCols];
        int tempRow = 0;
        int tempCol = 0;

        // Перезаписать ненулевые элементы во временный массив
        for (int i = 0; i < numRows; i++)
        {
            bool hasNonZero = false;
            for (int j = 0; j < numCols; j++)
            {
                if (originalArray[i, j] != 0)
                {
                    hasNonZero = true;
                    tempArray[tempRow, tempCol] = originalArray[i, j];
                    tempCol++;
                }
            }

            if (hasNonZero)
            {
                tempRow++;
                tempCol = 0;
            }
        }

        // Перезаписать временный массив в исходный
        originalArray = tempArray;
    }

    static void PrintArray(int[,] array)
    {
        int numRows = array.GetLength(0);
        int numCols = array.GetLength(1);

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
