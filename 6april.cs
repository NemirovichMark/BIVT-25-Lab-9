using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1;

class Program
{
    public static void Main()
    {
        var students = new Student[]
        {
            new Student("A", "a", new int[,] { { 1, 2, 3 }, { 5, 5, 5 } }),
            new Student("B", "b", new int[,] { { 4, 4, 5 }, { 5, 4, 5 } }),
            new Student("C", "c", new int[,] { { 2, 2, 2 }, { 2, 3, 2 } })
        };

        students[0][0, 0] = 5;
        // foreach (var s in students)
        // {
        //     Console.WriteLine(s[0]);
        //     Console.WriteLine(s[0, 0]);
        // }

        string str = "I am a good student!";
        string str2 = "Not! I am!";
        str = "Not! I am! Ammy, you're mistaken!";
        str2 = str;
        
        Console.WriteLine(str2);
        // str2 = str.Substring(4, 3);
        // str2 = str.Replace("am", "you", StringComparison.InvariantCultureIgnoreCase);
        // int a = str.IndexOf("a");
        var strings = str.Split(new char[] {'.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);

        string output = $"New\ntext\ron\r\neach{Environment.NewLine}line!";

        Console.WriteLine(str2);
        
        StringBuilder builder = new StringBuilder();
        builder.Append("dfgsdfsdg");
        builder.Remove(1, 5);
        builder.ToString();
        Console.WriteLine(builder);

        Regex regex = new Regex("[/d+]");
        var matches = regex.Matches("В 9-й работе разрешены методы следующих классов: Console, Math, Random, Array, Linq.");
        
    }

    public class Student
    {
        string _name;
        string _surname;
        int[,] _marks;
        int[] _averageMarks;
            
        public int[,] Marks => (int[,])_marks.Clone();

        public double[] AverageMarks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0)
                {
                    return null;
                }

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

        // public double this[int idx]
        // {
        //     get {return AverageMarks[idx];}
        // }

        public char this[int idx]
        {
            get { return _name[idx]; }
        }
        
        public int this[int i,  int j]
        {
            get { return _marks[i, j]; }
            set
            {
                if (value >= 2 && value <= 5)
                {
                    _marks[i, j] = value;
                }
            }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(_name);
            sb.Append(" ");
            sb.AppendLine(_surname);
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    sb.Append(_marks[i, j]).Append(" ");
                }

                sb = sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}