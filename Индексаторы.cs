using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice_after_KR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[] {
                new Student("A", "a", new double[,] { { 1, 2, 3 }, { 5, 5, 5 } }),
                new Student("B", "b", new double[,] { { 2, 2, 2 }, { 4, 4, 4 } })
            };
        

            //foreach (var s in students){
            //    Console.WriteLine(s[0]);
            //}
            string str1 = "I am a good student! ";
            string str2 = "Not! I am!";
            str1 = "Not! I am!";
            str2 = str1;

            //str2 = str2.Replace("am", "you", StringComparison.InvariantCultureIgnoreCase); // - юез регистра будет менять
            //str2 = str1.Substring(4, 3);
            //int a = str2.IndexOf('z');
            var strings = str2.Split(new char[] {'.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries); // удаляет пустые строчки

            // 16th centure, 1-й
            foreach (var c in "В 9-й работе разрешены методы следующих классов:") { 
                bool isLetter = Char.IsLetter(c);
                bool isdigit = Char.IsDigit(c);
                bool isSpaceTabNewLine = Char.IsSeparator(c);
                bool isPunctuation = Char.IsPunctuation(c);
            }

            string output = $"New\n text\r\non\r\neach{Environment.NewLine}line"; // Лучше юзать Environment.NewLine, чтобы не было проблем с тестами
            Console.WriteLine(output);

            StringBuilder sb = new StringBuilder();
            sb.Append("daad");
            sb.Remove(1, 5);
            // преобразование стрингбилда в строку
            sb.ToString();

            string h = "joaji5waf8";
            Regex regex = new Regex("[/d+]"); // регулярки
            //var res = regex.Match(h);
            //foreach(var match in res.Value)
            //{
            //    Console.WriteLine(match);
            //}
        }
    }

    public class Student
    {
        string _name;
        string _surname;

        double[,] _marks;

        public double[,] Marks => _marks;
        public double[] AverageMarks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks == null)
                    return null;
                var average = new double[_marks.GetLength(0)];
                for (int i = 0; i < average.Length; i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        average[i] += (double)_marks[i, j] / _marks.GetLength(1);
                    }

                }
                return average;
            }
        }

        

        //public double this[int dx]
        //{
        //    get { return AverageMarks[dx]}
        //}
        //public double this[int i,  int j]
        //{
        //    get { return _marks[i, j]; }
        //}

        public char this[int idx]
        {
            get { return _name[idx]; }
        }
        public Student(string name, string surname, double[,] marks)
        {
            _name = name;
            _surname = surname;
            if (marks != null)
            {
                _marks = marks;
            }
            _marks = marks;
        }

        public override string ToString()
        {
            string output = _name + " " + _surname;
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                for (int j = 0; j < _marks.GetLength(1) ; j++)
                {
                    output += _marks[i, j] + " ";
                }
                output = output.Trim();
                output += Environment.NewLine;
            }
            return output;

            StringBuilder sb = new StringBuilder(_name);
            sb.Append(" ");
            sb.AppendLine(_surname);
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                // ....
            }
        }
    }
}
