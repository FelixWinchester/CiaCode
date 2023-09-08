using System;

class Program {
  static void Main() {
    Console.WriteLine("Введите сумму вклада = ");
    double a = Convert.ToDouble(Console.ReadLine());
    
    Console.WriteLine("Введите процент по вкладу = ");
    double b = Convert.ToDouble(Console.ReadLine());
    
    double c = a * (b/100);
    
    Console.WriteLine("Сумма Денег = " + c.ToString("F2"));
    
  }
}
