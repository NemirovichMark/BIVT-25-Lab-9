using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("A", "a", new int[,] { { 1, 2 }, { 3, 4 } }),
                new Student("B", "b", new int[,] { { 5, 2 }, { 2, 4 } }),
                new Student("C", "c", new int[,] { { 5, 4 }, { 2, 1 } }),
            };
            //foreach (var s in students)
            //    Console.WriteLine(s[0]);
            string str = "Im good";
            string str2 = "Not! im";
            str = "Not! im";
            str2 = str;
            Console.WriteLine(str2);
            Console.WriteLine(str);
            str2 = str.Replace("im", "Yes");
            str2 = str.Replace("c", "a");

            Console.WriteLine(str2);
            //StringSplitOptions.RemoveEmptyEntries

            foreach (var c in "В 9-й работае разрешены кое-какие методы")
            {
                bool isletter = Char.IsLetter(c);
                bool isdigit = Char.IsDigit(c);
                bool isSpaceTab = Char.IsSeparator(c);
                bool isPunc = Char.IsPunctuation(c);

            }
            string output = $"New\ntext\ron\r\neach{Environment.NewLine}line!";
            Console.WriteLine(output);
        }
    }
    public class Student
    {
        string _name;
        string _surname;
        int[,] _marks;
        public int[,] Marks => _marks;
        public double[] AverageMarks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
                var average = new double[0];
                for (int i = 0; i <  _marks.GetLength(0); i++)
                {
                    for (int j = 0;  j < _marks.GetLength(1); j++)
                    {
                        average[i] = (double)_marks[i, j] / _marks.GetLength(1);
                    }
                }
                return average;
            }
        }

        public double this[int idx]
        {
            get { return AverageMarks[idx]; }
        }
        public int this[int i, int j]
        {
            get { return _marks[i, j]; }
            set
            {
                if (value >= 2 && value <= 5) _marks[i, j] = value;
            }
        }
        public Student(string name, string surname, int[,] marks=null)
        {
            _name = name;
            _surname = surname;
            if (_marks != null) _marks = (int[,])marks.Clone();
        }
    }
}
