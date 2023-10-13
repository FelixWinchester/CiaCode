using System;

class Program
{
    // Объявляем статический метод CountUppercaseWords, который будет считать количество слов, состоящих только из прописных букв
    static int CountUppercaseWords(string message)
    {
        // Разбиваем сообщение на слова, используя разделители: пробел, запятая, точка, точка с запятой, двоеточие, восклицательный знак, вопросительный знак
        string[] words = message.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        // Инициализируем переменную count, которая будет хранить количество слов, состоящих только из прописных букв
        int count = 0;

        // Итерируемся по каждому слову из массива words
        foreach (string word in words)
        {
            // Инициализируем переменную isUppercase, которая будет хранить информацию о том, состоит ли слово только из прописных букв
            bool isUppercase = true;

            // Итерируемся по каждому символу в слове
            foreach (char c in word)
            {
                // Если символ не является прописной буквой, устанавливаем isUppercase в false и выходим из цикла
                if (!char.IsUpper(c))
                {
                    isUppercase = false;
                    break;
                }
            }

            // Если слово состоит только из прописных букв, увеличиваем count на 1
            if (isUppercase)
            {
                count++;
            }
        }

        // Возвращаем количество слов, состоящих только из прописных букв
        return count;
    }

    static void Main()
    {
        // Выводим на экран сообщение с просьбой ввести текстовое сообщение
        Console.Write("Введите текстовое сообщение: ");
        // Считываем введенное пользователем сообщение
        string message = Console.ReadLine();

        // Вызываем метод CountUppercaseWords, чтобы посчитать количество слов, состоящих только из прописных букв
        int count = CountUppercaseWords(message);
        // Выводим на экран количество слов, состоящих только из прописных букв
        Console.WriteLine("Количество слов, состоящих только из прописных букв: " + count);

        Console.ReadLine();
    }
}
