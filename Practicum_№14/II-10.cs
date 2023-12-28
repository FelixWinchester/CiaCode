using System;
using System.IO;

class chisla
{
    public struct Sgroup : IComparable<Sgroup>
    {
        public string fam, name, second_name;
        public int group, course;
        public double time;

        public Sgroup(string fam, string name, string second_name, int group, int course, double time)
        {
            this.name = name;
            this.fam = fam;
            this.second_name = second_name;
            this.group = group;
            this.course = course;
            this.time = time;
        }

        public int CompareTo(Sgroup obj)
        {
            if (this.time > obj.time) return -1;
            else if (this.time < obj.time) return 1;
            else return 0;
        }

        public void Show(StreamWriter fileout)
        {
            fileout.Write("{0} {1} {2} {3} {4} {5}", name, fam, second_name, group, course, time);
            fileout.WriteLine();
        }

        public void Show()
        {
            Console.Write("{0} {1} {2} {3} {4} {5}", name, fam, second_name, group, course, time);
            Console.WriteLine();
        }
    }

    static public Sgroup[] Input(ref int n)
    {
        using (StreamReader fileIn = new StreamReader("input.txt"))
        {
            n = int.Parse(fileIn.ReadLine());
            Sgroup[] ar = new Sgroup[n];
            for (int i = 0; i < n; i++)
            {
                string[] text = fileIn.ReadLine().Split(' ');
                ar[i] = new Sgroup(text[0], text[1], text[2], int.Parse(text[3]), int.Parse(text[4]), double.Parse(text[5]));
            }
            return ar;
        }
    }

    static void Print(Sgroup[] array)
    {
        foreach (Sgroup student in array)
        {
            student.Show();
        }
    }

    static void Main()
    {
        int n = 0;
        Sgroup[] groupmates = Input(ref n);
        Array.Sort(groupmates);
        int count = 1;
        using (StreamWriter fileout = new StreamWriter("output.txt"))
        {
            fileout.WriteLine("Top 3 Students:");
            groupmates[0].Show(fileout);

            for (int i = 1; i < n; i++)
            {
                if (count < 3 || groupmates[i].time == groupmates[i - 1].time)
                {
                    groupmates[i].Show(fileout);

                    if (groupmates[i].time != groupmates[i - 1].time)
                    {
                        count++;
                    }
                    else if (count == 3)
                    {
                        count++;
                        fileout.WriteLine("Additional Students with the Same Result:");
                    }
                }
            }
        }

        chisla.Print(groupmates);
    }
}
/*
5
Иванов Иван Иванович 1 2 10.5
Петров Петр Петрович 2 1 9.8
Сидоров Сидор Сидорович 3 1 10.2
Кузнецов Андрей Иванович 4 2 9.5
Михайлова Елена Викторовна 5 1 10.2
*/
