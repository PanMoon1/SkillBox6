using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"d:\Skill.txt";
            if (!File.Exists(path))
                using (FileStream fs = File.Create(path))
                { }

            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (c == '1')
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string s = string.Empty;
                    do
                    {
                        s = sr.ReadLine();
                        SplitAndWrite(s);
                    } while (s != null);
                }
            }
            else if (c == '2')
            {
                int i = 0;
                string[] info = NewNote();
                using (StreamReader sr = new StreamReader(path))
                {
                    do
                    {
                        i++;
                    } while (sr.ReadLine() != null);
                }
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine();
                    sw.Write(Convert.ToString(i));
                    foreach (string s in info)
                    {
                        sw.Write("#");
                        sw.Write(s);
                    }
                }
            }
            Console.ReadKey();
        }

        static void SplitAndWrite(string s)
        {
            if (s != null)
            {
                string[] words = s.Split('#');
                foreach (string ww in words)
                {
                    Console.Write(ww + " ");
                }
                Console.WriteLine();
            }
        }

        static string[] NewNote()
        {
            string[] str = new string[6];
            str[0] = DateTime.Now.ToString();
            Console.WriteLine("Full Name");
            str[1] = Console.ReadLine();
            Console.WriteLine("y.o.");
            str[2] = Console.ReadLine();
            Console.WriteLine("Height");
            str[3] = Console.ReadLine();
            Console.WriteLine("Birth Date");
            str[4] = Console.ReadLine();
            Console.WriteLine("Birth Place");
            str[5] = Console.ReadLine();
            return str;
        }
    }
}
