using System.Text;
using System.Text.RegularExpressions;

namespace Indexators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("A", "B", new int[,] {{1,2,3}, {5, 5, 5}}),  
                new Student("A", "b", new int[,] {{4,4,5}, {5, 4, 5}}),  
                new Student("A", "c", new int[,] {{2,2,2}, {2, 3, 2}})  

            };

            // foreach(var s in students)
            // {
            //     System.Console.WriteLine(s[0]);
            // }

            string str = "im a good student";
            string str2 = "no! im!";
            str = "no! im!";
            str2 = str;

            System.Console.WriteLine(str2);
            // str2 = str.Substring(4, 3);
            //str2 = str.Replace("no", "yes"); //StringComparison.InvariantCultureIgnoreCase
            // int a = str.IndexOf('a');
            var strings = str.Split(new char[]{'.','?','!'}, StringSplitOptions.RemoveEmptyEntries);

            string text = "sdaljfhsajfhas";

            foreach (var c in text)
            {
                bool isLetter = Char.IsLetter(c);
                bool isDigit = Char.IsDigit(c);
                bool isSpaceTabNewLine = Char.IsSeparator(c);
                bool isPunctuation = Char.IsPunctuation(c);
            }

            string output = $"new\ntext\ron\r\neach{Environment.NewLine}line";
            System.Console.WriteLine(output);

            StringBuilder s = new StringBuilder();
            s.Append("fsadf");
            s.Remove(1, 5);

            s.ToString();

            Regex regex = new Regex(@"\d+1");
        }
    }

    public class Student
    {
        string _name;
        string _surname;

        int[,] _marks;

        public int[,] Marks => (int[,])_marks.Clone();
        public double[] avgMarks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0)
                    return null;
                var avg = new double[_marks.GetLength(0)];
                for (int i = 0; i < avg.Length; i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        avg[i] += (double)_marks[i, j] / _marks.GetLength(1);
                    }
                }
                return avg;
            }
        }

        // public double this[int idx] => avgMarks[idx];

        public char this[int idx] => _name[idx];
 
        public int this[int i, int j] => _marks[i, j];

        public Student(string name, string surname, int[,] marks = null)
        {
            _name = name;
            _surname = surname;
            if (_marks != null)
                _marks = marks;
        }

        public override string ToString()
        {
            var output =  _name + " " + _surname;
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    output += _marks[i, j] + " ";
                }
                output = output.TrimEnd();
                output += Environment.NewLine;
            }
            return output;

            // StringBuilder sb = new StringBuilder(_name);
            // sb.Append(" ").Append(_surname);
            // for (int i = 0; i < _marks.GetLength(0); i++)
            // {
            //     for (int j = 0; j < _marks.GetLength(1); j++)
            //     {
            //         sb.Append(_marks[i, j]).Append(" ");
            //     }
            //     sb = sb.Remove(sb.Length-1, 1);
            //     sb.AppendLine();
            // }
            // sb.ToString();
        }
    }
}
