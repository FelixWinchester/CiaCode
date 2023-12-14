using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Чтение чисел из файла
        string[] numbers = File.ReadAllLines("input.txt");

        // Преобразование строк в числа и фильтрация трехзначных чисел
        var threeDigitNumbers = numbers
            .Select(int.Parse)
            .Where(n => n >= 100 && n <= 999);

        // Вычисление результирующей последовательности чисел
        var result = threeDigitNumbers
            .Select(n => n - 100);

        // Запись результирующей последовательности чисел в файл
        File.WriteAllLines("output.txt", result.Select(n => n.ToString()));
    }
}
/* input.txt
0 
12 
15
1 
123
456
789
101
202
303
404
505
606
707
808
909
1000
1111
1212
*/ 
/* output.txt:
23
356
689
1
102
203
304
405
506
607
708
809
*/
