// Импортирование необходимых пространств имен
using System;
using System.IO;

// Объявление класса Program
class Program
{
    // Объявление метода Main
    static void Main()
    {
        // Инициализация переменных с именами файлов
        string inputFile = "f.txt";
        string outputFilePunctuation = "g.txt";
        string outputFileOther = "h.txt";

        // Чтение символов из файла f и запись в соответствующие файлы g и h
        using (StreamReader reader = new StreamReader(inputFile)) // Создание объекта StreamReader для чтения из файла inputFile
        {
            using (StreamWriter writerPunctuation = new StreamWriter(outputFilePunctuation)) // Создание объекта StreamWriter для записи в файл outputFilePunctuation
            {
                using (StreamWriter writerOther = new StreamWriter(outputFileOther)) // Создание объекта StreamWriter для записи в файл outputFileOther
                {
                    int character;
                    while ((character = reader.Read()) != -1) // Чтение символа из файла и проверка на конец файла
                    {
                        char c = (char)character; // Преобразование символа в тип char
                        if (IsPunctuation(c)) // Проверка, является ли символ знаком препинания
                        {
                            writerPunctuation.Write(c); // Запись символа в файл outputFilePunctuation
                        }
                        else
                        {
                            writerOther.Write(c); // Запись символа в файл outputFileOther
                        }
                    }
                }
            }
        }

        Console.WriteLine("Готово!"); // Вывод сообщения "Готово!"
    }

    // Метод для проверки, является ли символ знаком препинания
    static bool IsPunctuation(char c)
    {
        return char.IsPunctuation(c); // Возвращает true, если символ является знаком препинания, иначе false
    }
}
