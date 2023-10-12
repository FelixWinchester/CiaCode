class Program
{
    static void Main()
    {
        int n = GetArraySize();
        int[,] array = CreateAndFillArray(n);
        int[] resultArray = FindPositiveElements(array, n);
        PrintResults(resultArray, array, n);
    }

    static int GetArraySize()
    {
        Console.Write("Введите размер массива n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        return n;
    }

    static int[,] CreateAndFillArray(int n)
    {
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
        return array;
    }
    
    static int[] FindPositiveElements(int[,] array, int n)
    {
        int[] resultArray = new int[n];
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
        return resultArray;
    }


    static void PrintResults(int[] resultArray, int[,] array, int n)
    {
        Console.WriteLine("Результаты:");
        Console.WriteLine("Массив с результатами:");
        for (int j = 0; j < n; j++)
        {
            Console.WriteLine($"Результат Массива[{j}]: {resultArray[j]}");
        }

        Console.WriteLine("Конечный массив:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
