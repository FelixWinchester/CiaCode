using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массива n: ");
        int n = int.Parse(Console.ReadLine());

        // Инициализация ступенчатого массива
        int[][] array = new int[n][];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите элементы {i + 1}-й строки через пробел:");
            string[] input = Console.ReadLine().Split(' ');
            array[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                array[i][j] = int.Parse(input[j]);
            }
        }

        Console.WriteLine("\nИсходный массив:");
        PrintArray(array);

        // Уплотнение массива
        int[][] resultArray = CompactArray(array);

        Console.WriteLine("\nРезультат уплотнения:");
        PrintArray(resultArray);
    }

    static int[][] CompactArray(int[][] inputArray)
    {
        int rowCount = inputArray.Length;
        int colCount = inputArray[0].Length;

        // Флаги для определения, какие строки и столбцы нужно удалить
        bool[] deleteRows = new bool[rowCount];
        bool[] deleteCols = new bool[colCount];

        // Проверка каждой строки на наличие ненулевых элементов
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                if (inputArray[i][j] != 0)
                {
                    // Если найден ненулевой элемент, то строку не удаляем
                    deleteRows[i] = false;
                    break;
                }
                else
                {
                    // Если строка состоит из одних нулей, то помечаем ее для удаления
                    deleteRows[i] = true;
                }
            }
        }

        // Проверка каждого столбца на наличие ненулевых элементов
        for (int j = 0; j < colCount; j++)
        {
            for (int i = 0; i < rowCount; i++)
            {
                if (inputArray[i][j] != 0)
                {
                    // Если найден ненулевой элемент, то столбец не удаляем
                    deleteCols[j] = false;
                    break;
                }
                else
                {
                    // Если столбец состоит из одних нулей, то помечаем его для удаления
                    deleteCols[j] = true;
                }
            }
        }

        // Создаем новый массив с учетом флагов удаления строк и столбцов
        int newRowCount = rowCount - CountTrueValues(deleteRows);
        int newColCount = colCount - CountTrueValues(deleteCols);

        int[][] resultArray = new int[newRowCount][];
        int rowIndex = 0;

        for (int i = 0; i < rowCount; i++)
        {
            if (!deleteRows[i])
            {
                resultArray[rowIndex] = new int[newColCount];
                int colIndex = 0;

                for (int j = 0; j < colCount; j++)
                {
                    if (!deleteCols[j])
                    {
                        resultArray[rowIndex][colIndex] = inputArray[i][j];
                        colIndex++;
                    }
                }

                rowIndex++;
            }
        }

        return resultArray;
    }

    static int CountTrueValues(bool[] array)
    {
        int count = 0;
        foreach (bool value in array)
        {
            if (value)
            {
                count++;
            }
        }
        return count;
    }

    static void PrintArray(int[][] array)
    {
        foreach (var row in array)
        {
            foreach (var element in row)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
