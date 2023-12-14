using System;
using System.IO;
using System.Linq;

public class Student : IComparable<Student>
{
    public string FullName { get; set; }
    public int Course { get; set; }
    public string Group { get; set; }
    public int RunResult { get; set; }

    public int CompareTo(Student other)
    {
        return other.RunResult.CompareTo(RunResult);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var students = new Student[100];
        int count = 0;

        using (var reader = new StreamReader("input.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(';');
                students[count] = new Student
                {
                    FullName = parts[0],
                    Course = int.Parse(parts[1]),
                    Group = parts[2],
                    RunResult = int.Parse(parts[3])
                };
                count++;
            }
        }

        Array.Sort(students, 0, count);

        using (var writer = new StreamWriter("output.txt"))
        {
            for (int i = 0; i < 3; i++)
            {
                writer.WriteLine(students[i].FullName + " " + students[i].Course + " " + students[i].Group + " " + students[i].RunResult);
            }
        }
    }
}
/* input.txt
Иванов;1;1;10
Петров;2;2;15
Сидоров;3;3;20
Кузнецов;1;1;10
Смирнов;2;2;15
Алексеев;3;3;20
Васильев;1;1;10
Николаев;2;2;15
Александров;3;3;20
Игнатьев;1;1;10
*/
/* output.txt
Сидоров 3 3 20
Алексеев 3 3 20
Александров 3 3 20
*/
