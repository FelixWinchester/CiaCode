using System;

class Program
{
    static void Main()
    {
        // Вводим размерность массива
        Console.WriteLine("Введите размерность массива (n):");
        int n = int.Parse(Console.ReadLine());

        // Создаем ступенчатый массив
        int[][] array = new int[n][];
        for (int i = 0; i < n; i++)
        {
            array[i] = new int[n];
        }

        // Для примера, заполняем массив случайными числами, где 0 и 1 - просто для иллюстрации
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i][j] = random.Next(2);
            }
        }

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        // Вызываем функцию для уплотнения массива
        int[][] resultArray = CompactArray(array);

        Console.WriteLine("Массив после уплотнения:");
        PrintArray(resultArray);
    }

    // Функция для уплотнения массива
    static int[][] CompactArray(int[][] array)
    {
        // Подсчитываем количество строк и столбцов без одних нулей
        int rowCount = 0;
        int colCount = 0;

        foreach (var row in array)
        {
            if (!IsRowAllZeros(row))
            {
                rowCount++;
            }
        }

        for (int colIndex = 0; colIndex < array.Length; colIndex++)
        {
            if (!IsColumnAllZeros(array, colIndex))
            {
                colCount++;
            }
        }

        // Создаем новый массив с уменьшенными размерами
        int[][] resultArray = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
        {
            resultArray[i] = new int[colCount];
        }

        // Копируем значения из исходного массива в новый, пропуская строки и столбцы из одних нулей
        int rowIndex = 0;
        foreach (var row in array)
        {
            if (!IsRowAllZeros(row))
            {
                int colIndex = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (!IsColumnAllZeros(array, i))
                    {
                        resultArray[rowIndex][colIndex] = array[rowIndex][i];
                        colIndex++;
                    }
                }
                rowIndex++;
            }
        }

        return resultArray;
    }

    // Функция для проверки, состоит ли вся строка из нулей
    static bool IsRowAllZeros(int[] row)
    {
        foreach (var element in row)
        {
            if (element != 0)
            {
                return false;
            }
        }
        return true;
    }

    // Функция для проверки, состоит ли весь столбец из нулей
    static bool IsColumnAllZeros(int[][] array, int columnIndex)
    {
        foreach (var row in array)
        {
            if (row[columnIndex] != 0)
            {
                return false;
            }
        }
        return true;
    }

    // Функция для вывода массива
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
