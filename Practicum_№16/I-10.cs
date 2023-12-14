using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    // Создание статического класса Extensions
    public static class Extensions
    {
        // Метод расширения, вычитающий 100 из каждого элемента IEnumerable<int>
        public static IEnumerable<int> Subtract100(this IEnumerable<int> numbers)
        {
            return numbers.Select(n => n - 100);
        }
    }

    // Основной класс программы
    class Program
    {
        // Главный метод программы
        static void Main(string[] args)
        {
            // Создание списка целых чисел
            List<int> numbers = new List<int>();

            // Чтение данных из файла "input.txt" и добавление их в список numbers
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    numbers.Add(int.Parse(line));
                }
            }

            // Фильтрация трехзначных чисел из списка numbers
            var threeDigitNumbers = numbers.Where(n => n >= 100 && n <= 999);
            
            // Вычитание 100 из каждого трехзначного числа
            var result = threeDigitNumbers.Subtract100();

            // Запись результатов в файл "output.txt"
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var number in result)
                {
                    writer.WriteLine(number);
                }
            }
        }
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
/* output.txt
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
