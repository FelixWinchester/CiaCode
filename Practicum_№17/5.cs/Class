using System;

class IntArray
{
    int[] intArray;

    //конструкторы
    public IntArray()
    {
        intArray = new int[0];
    }
    public IntArray(int n)
    {
        intArray = new int[n];
    }
    public IntArray(int[] array)
    {
        intArray = new int[array.Length];
        Array.Copy(array, intArray, array.Length);
    }

    //методы
    public static IntArray ConsoleInput()
    {
        Console.WriteLine("Введите размерность массива: ");
        int n = int.Parse(Console.ReadLine());
        IntArray a = new IntArray(n);
        Console.WriteLine("Введите элементы массива: ");
        string[] inp = Console.ReadLine().Split(" ");
        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(inp[i]);
        }
        return a;
    }

    public void ConsoleOutput()
    {
        Console.WriteLine("Массив содержит следующие элементы: ");
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write("{0} ", intArray[i]);
        }
        Console.WriteLine();
    }

    public void Sort()
    {
        Array.Sort(intArray);
    }

    public override string ToString()
    {
        string res = "";
        for (int i = 0; i < intArray.Length; i++)
        {
            res += intArray[i] + " ";
        }
        return res;
    }

    //свойства
    public int Size
    {
        get { 
            return intArray.Length; 
        }

    }
    public int Multiply
    {
        set
        {
            for(int i = 0; i < intArray.Length; i++)
            {
                intArray[i] *= value;
            }
        }

    }

    //индексатор
    public int this[int i]
    {
        get
        {
            if(i < 0 || i >= intArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return intArray[i];
            }
        }
        set
        {
            if(i<0 || i >= intArray.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                intArray[i] = value;
            }
        }
    }

    
    //перегрузка
    public static IntArray operator ++(IntArray a)
    {
        IntArray temp = new IntArray(a);
        for(int i = 0; i < a.Size; i++)
        {
            temp[i] = a[i] + 1;
        }
        return temp;
    }

    public static IntArray operator --(IntArray a)
    {
        IntArray temp = new IntArray(a);
        for (int i = 0; i < a.Size; i++)
        {
            temp[i] = a[i] - 1;
        }
        return temp;
    }

    public static bool operator !(IntArray a)
    {
        int[] temp = new int[a.Size];
        Array.Copy(a, temp, a.Size);
        Array.Sort(temp);
        for(int i = 0; i < a.Size; i++)
        {
            if (temp[i] != a[i])
            {
                return true;
            }
        }
        return false;
    }
    public static IntArray operator *(IntArray a, int b)
    {
        IntArray temp = new IntArray(a);
        for(int i = 0; i < a.Size; i++)
        {
            temp[i] = a[i] * b;
        }
        return temp;
    }
    public static IntArray operator *(int b, IntArray a)
    {
        return a * b;
    }

    //неявное преобразование типов
    public static implicit operator int[](IntArray a)
    {
        int[] temp = new int[a.Size];
        for (int i = 0; i < a.Size; i++)
        {
            temp[i] = a[i];
        }
        return temp;
    }
    public static implicit operator IntArray(int[] a)
    {
        return new IntArray(a);
    }

}
