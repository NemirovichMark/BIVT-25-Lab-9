using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("A", "a", new int[,] {{1, 2, 3}, {5, 5, 5}}),
                new Student("B", "b", new int[,] {{4, 4, 5}, {5, 4, 5}}),
                new Student("C", "c", new int[,] {{2, 2, 2}, {2, 3, 2}})
            };
            foreach (var student in students)
            {
                Console.WriteLine(student[0]);
            }

            string str = "I am a good student";
            string str2 = "Not! A am!";
            str = "Not! A am!";
            str2 = str;
            Console.WriteLine(str2);
            str2 = str.ToLower();
            Console.WriteLine(str2);

        }

        public class Student
        {
            string _name;
            string _surname;
            int[,] _marks;

            public char this[int idx]
            {
                get { return _name[idx];  }
            }

            //public double this[int idx]
            //{
            //    get { return AverageMarks[idx]; }
            //}

            public int this[int i, int j]
            {
                get { return _marks[i, j]; }
                set { if (value >= 2 && value <= 5)
                    _marks[i, j] = value;
                }
            }



            public int[,] Marks => _marks;
            public double[] AverageMarks
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
                    var average = new double[_marks.GetLength(0)];
                    for (int i=0;  i < average.Length; i++)
                    {
                        for (int j=0; j < _marks.GetLength(1); j++)
                        {
                            average[i] = (double)_marks[i, j]/_marks.GetLength(1);
                        }
                    }
                    return average;
                }
            }
            public Student(string name, string surname, int[,] marks)
            {
                _name = name;
                _surname = surname;
                if (marks != null)
                {
                    _marks = (int[,])marks.Clone();
                }
            }

            public override string ToString()
            {
                var output = _name + " " + _surname;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0;  j < _marks.GetLength(1); j++)
                    {
                        output += _marks[i, j] + " ";
                    }
                    output = output.TrimEnd();
                    output += Environment.NewLine;

                }
                return output;
            }

        }
    }
}
