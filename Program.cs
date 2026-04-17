using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace april_06
{
    public class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("A", "a", new int[,] { { 1, 2, 3 }, { 5, 5, 5 } }),
                new Student("B", "b", new int[,] { { 4, 4, 5 }, { 5, 4, 5 } }),
                new Student("C", "c", new int[,] { { 2, 2, 2 }, { 2, 3, 2 } })
            };
            students[0][0, 0] = 5;
            foreach (var s in students)
            {
                Console.WriteLine(s[0, 1]);
            }

            string str = "I am a good student.";
            string str2 = "No! I AM NOT A GOOD STUDENT!";
            str = "No! I AM NOT A GOOD STUDENT!";
            str2 = str;
            
            Console.WriteLine(str2);
            //str2 = str.Replace("a", "c", StringComparison.InvariantCultureIgnoreCase); //игнорирование регистра
            //str2 = str.Substring( 4, 8 );
            var strings = str.Split(new char[] {'.', '?', '!'},
                StringSplitOptions.RemoveEmptyEntries); //убрать лишни пустые 
            //Console.WriteLine(str2);
            //int a = str.IndexOf("O");
            //Console.WriteLine(a);
            
            //16-й, 16th century
            foreach (var c in "В 9-1 работе разрешеныметоды следующих классов:")
            {
                bool IsLetter = Char.IsLetter(c);
                bool IsDigit = Char.IsDigit(c);
                bool IsSpaceTabNewLine = Char.IsSeparator(c);
                bool IsPunctuation = Char.IsPunctuation(c);
            }
            
            //в базовом классе сделать массив символов для работы

            string output = $"New text on each{Environment.NewLine}line.";
            Console.WriteLine(output);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("I am a good student.");
            sb.Remove(1, 5);
            //преобразование динамичного массива символов в строку
            sb.ToString();
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
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) 
                    return null;

                var average = new double[_marks.GetLength(0)];
                for (int i = 0; i < average.Length; i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                        average[i] = (double) _marks[i, j] / _marks.GetLength(1) ;
                }

                return average;
            }
        }

        public char this[int idx]
        {
            get { return _name[idx]; }
        }
        
        // public double this[int idx]
        // {
        //     get { return AverageMarks[idx]; }
        // }

        public int this[int i, int j]
        {
            get {return _marks[i, j]; }
            set { if (value >= 2 && value <= 5)
                    _marks[i, j] = value; }
        }

        public Student(string name, string surname, int[,] marks = null)
        {
            _name = name;
            _surname = surname;
            if (marks != null)
            {
                _marks = (int[,])marks.Clone();
            }
        }
        
        //разобраться с Regex

        public override string ToString()
        {
            var output = _name + " " + _surname;
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    output += _marks[i, j] + " ";
                }
                output = output.TrimEnd(); //Trim - с обеих сторон отрубает то, что указано в скобках
                output += Environment.NewLine;
            }
            return output;
        }
    }
}