using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "f.txt";
        string outputFilePunctuation = "g.txt";
        string outputFileOther = "h.txt";

        // Чтение символов из файла f и запись в соответствующие файлы g и h
        using (StreamReader reader = new StreamReader(inputFile))
        {
            using (StreamWriter writerPunctuation = new StreamWriter(outputFilePunctuation))
            {
                using (StreamWriter writerOther = new StreamWriter(outputFileOther))
                {
                    int character;
                    while ((character = reader.Read()) != -1)
                    {
                        char c = (char)character;
                        if (IsPunctuation(c))
                        {
                            writerPunctuation.Write(c);
                        }
                        else
                        {
                            writerOther.Write(c);
                        }
                    }
                }
            }
        }

        Console.WriteLine("Готово!");
    }

    // Метод для проверки, является ли символ знаком препинания
    static bool IsPunctuation(char c)
    {
        return char.IsPunctuation(c);
    }
}

