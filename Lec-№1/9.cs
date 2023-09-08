using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите сумму вклада = ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите процент по вкладу = ");
        double b = Convert.ToDouble(Console.ReadLine());

        double c = a + a * (b / 100);

        Console.WriteLine("Через год сумма на вкладе = " + c.ToString("F2"));

    }
}
