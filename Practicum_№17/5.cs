using System;

// Объявление класса IntArray.
class IntArray
{
    // Объявление приватного массива intArray.
    private int[] intArray;

    // Конструктор класса IntArray, принимающий размер массива и инициализирующий intArray.
    public IntArray(int size)
    {
        intArray = new int[size];
    }

    // Метод InputArray, который запрашивает у пользователя ввод элементов массива и сохраняет их в intArray.
    public void InputArray()
    {
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write($"Введите {i + 1} элемент массива: ");
            intArray[i] = int.Parse(Console.ReadLine());
        }
    }

    // Метод PrintArray, который выводит элементы массива intArray на консоль.
    public void PrintArray()
    {
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write($"{intArray[i]} ");
        }
        Console.WriteLine();
    }

    // Метод SortArray, который сортирует элементы массива intArray.
    public void SortArray()
    {
        Array.Sort(intArray);
    }

    // Свойство Length, которое возвращает длину массива intArray.
    public int Length
    {
        get { return intArray.Length; }
    }

    // Метод MultiplyBy, который умножает каждый элемент массива intArray на заданное число scalar.
    public void MultiplyBy(int scalar)
    {
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] *= scalar;
        }
    }

    // Индексатор, который позволяет получить или установить значение элемента массива intArray по указанному индексу.
    public int this[int index]
    {
        get { return intArray[index]; }
        set { intArray[index] = value; }
    }

    // Перегрузка оператора ++, который увеличивает каждый элемент массива intArray на единицу.
    public static IntArray operator ++(IntArray array)
    {
        for (int i = 0; i < array.intArray.Length; i++)
        {
            array.intArray[i]++;
        }
        return array;
    }

    // Перегрузка оператора --, который уменьшает каждый элемент массива intArray на единицу.
    public static IntArray operator --(IntArray array)
    {
        for (int i = 0; i < array.intArray.Length; i++)
        {
            array.intArray[i]--;
        }
        return array;
    }

    // Перегрузка оператора !, который проверяет, отсортирован ли массив intArray в порядке возрастания.
    public static bool operator !(IntArray array)
    {
        for (int i = 0; i < array.intArray.Length - 1; i++)
        {
            if (array.intArray[i] > array.intArray[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    // Перегрузка оператора *, который умножает каждый элемент массива intArray на заданное число scalar.
    public static IntArray operator *(IntArray array, int scalar)
    {
        for (int i = 0; i < array.intArray.Length; i++)
        {
            array.intArray[i] *= scalar;
        }
        return array;
    }

    // Перегрузка неявного оператора преобразования типа IntArray в int[], которая возвращает массив intArray.
    public static implicit operator int[](IntArray array)
    {
        return array.intArray;
    }

    // Перегрузка явного оператора преобразования типа int[] в IntArray, которая создает новый объект IntArray и инициализирует его значением массива array.
    public static explicit operator IntArray(int[] array)
    {
        return new IntArray(array.Length) { intArray = array };
    }
}

// Объявление класса Program.
class Program
{
    // Метод Main, который является точкой входа в программу.
    static void Main(string[] args)
    {
        // Создание объекта array класса IntArray с размером 5.
        IntArray array = new IntArray(5);
        // Вызов метода InputArray для ввода элементов массива.
        array.InputArray();
        // Вывод на консоль исходного массива.
        Console.WriteLine("Исходный массив:");
        array.PrintArray();
        // Сортировка массива.
        array.SortArray();
        // Вывод на консоль отсортированного массива.
        Console.WriteLine("Отсортированный массив:");
        array.PrintArray();
        // Умножение массива на 2.
        array.MultiplyBy(2);
        // Вывод на консоль массива, умноженного на 2.
        Console.WriteLine("Массив, умноженный на 2:");
        array.PrintArray();
        // Увеличение каждого элемента массива на 1.
        Console.WriteLine("Массив после инкремента:");
        ++array;
        array.PrintArray();
        // Уменьшение каждого элемента массива на 1.
        Console.WriteLine("Массив после декремента:");
        --array;
        array.PrintArray();
        // Умножение массива на 3.
        Console.WriteLine("Массив умноженный на 3:");
        array *= 3;
        array.PrintArray();
        // Преобразование массива в одномерный массив и вывод его на консоль.
        Console.WriteLine("Массив в виде одномерного массива:");
        int[] arr = array;
        foreach (int i in arr)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }
}
