using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ConsoleApp13
{
    public class Programm
    {
        static void Main(string[] args)
        {
            var student = new Student[]
            {
            new Student("A", "a", new int[,] { { 1,2,3},{ 3,5,6} }),
            new Student("B", "b", new int[,] { { 1, 2, 3 }, { 6, 7, 8 } }),
            new Student("C", "c", new int[,] {{ 3, 5, 6 }, { 6, 7, 8 } })
            };
            student[0][0, 0] = 5;
            foreach (var s in student) { Console.WriteLine(s[0, 1]); }
            string str = "I am student!";
            string str2 = "Not!";
            str = "No!";
            str2 = str;
            //str2 = str.Substring(4, 3);
            //str2 = str.Replace("dfgmd", "d", StringComparison.InvarianCultureIgnoreCase);
            //str2 = str.ToLower();    //формируется новая строка, нужно сохранять
            //int a=str.IndexOf("a");
            var strings=str.Split(new char[] { ".", "?", "!" };     // убирать пустые строки
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var c in "Gfghjukl")
            { 
                bool isletter=Char.IsSeparator(c);
                bool isdigit=Char.IsDigit(c);
                bool isSpaceTabNewLine=Char.IsSeparator(c);
                bool isSpaceTabNewLine = Char.IsPunctuation(c);
            }
            string output = $"New\ntext\ron\r\neach{Environment.NewLine}line!";
            Console.WriteLine(str);
            Console.WriteLine(str2);
            StringBuilder sb=new StringBuilder();
            sb.Append("fghjk");
            sb.Remove(1, 5);
            sb.ToString();

            //Regex regex = new Regex("[\d+]");    //  регулярные выражения, пока что нельзя пользоваться
            //var result=regex.Match("sdfgh"+"sdfgd");
            //foreach (var match in result.Value)
            //{ 
            
            //    Console.WriteLine(match);
            //}
        }
    }
    public class Student
    {
        string _name; string _surname;
        int[,] _marks; double[] _averageMark;
        public int[,] Marks => (int[,])_marks.Clone();
        public double[] AverageMarks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
                var average = new double[_marks.GetLength(0)];
                for (int i = 0; i < average.Length; i++)
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        average[i] += (double)_marks[i, j] / _marks.GetLength(1);
                    }
                return average;
            }
        }
        //public double this[int idx]
        //{ get { return AverageMarks[idx]; } }

        public char this[int idx]
        { get { return _name[idx]; } }
        public double this[int i, int j]
        {
            get { return _marks[i, j]; }
            set
            {
                if (value >= 2 && value <= 5) _marks[i, j] = value;
            }
        }
        public Student(string name, string surname, int[,] marks = null)
        {
            _name = name; _surname = surname;
            if (marks != null)
            { _marks = (int[,])marks.Clone(); }
        }
        public override string ToString()
        {
            var output= _name+" "+_surname;
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    XmlOutputMethod += _marks[i, j] + " ";
                }
                output = output.TrimEnd();
                output += Environment.NewLine;
            }
            return output;
            StringBuilder sb=new StringBuilder(_name);
            sb.Append("...");
            sb.AppendLine(_surname);
            for (int i = 0; i < _marks.GetLength(0); i++)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    sb.Append(_marks[i, j]).Append(" ");
                }
                output = output.TrimEnd();
                output += Environment.NewLine;
            }
        }
    }
}
