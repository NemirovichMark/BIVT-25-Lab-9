namespace Classwork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Student[]
            {
                new Student("A","B",new int[,]{ { 1, 2, 3 }, { 4, 5, 4 } }),
                new Student("C","D",new int[,]{ { 2, 2, 3 }, { 4, 5, 5 } }),
                new Student("E","F",new int[,]{ { 3, 2, 3 }, { 5, 5, 5 } })
            };
            //foreach (var student in students)
            //{
            //    student[0, 0] = 5;
            //    Console.WriteLine(student[0]);
            //}
            string str = "Ima bad student";
            string str2 = "Yeah ,me 2!";
            str = "Yeah ,me 2!";
            str2 = str;
            //str2 = str.Substring(1, 7);
            str2 = str.Replace("Me", "you", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine(str2);
            bool isLetter = Char.IsPunctuation('-');
            Console.WriteLine(isLetter);
        }
        
    }
    public class Student
    {
        string _name;
        string _surname;
        int[,] _marks;

        //public double this[int idx]
        //{
        //    get
        //    {
        //        return AverageMarks[idx];
        //    }

        //}
        public char this[int idx]
        {
            get
            {
                return _name[idx];
            }
        }
        public int this[int i, int j]
        {
            get
            {
                return _marks[i, j];
            }
            set
            {
                _marks[i,j] = value;
            }
        }

        public int[,] Marks => (int[,])_marks.Clone();
        public double[] AverageMarks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0)
                    return null;
                var average = new double[_marks.GetLength(0)];
                for (int i = 0;  i < _marks.GetLength(0); i++)
                {
                    for (int j = 0;  j < _marks.GetLength(1); j++)
                    {
                        average[i] += (double)_marks[i, j] / _marks.GetLength(1);
                    }
                }
                return average;
            }
        }
        public override string ToString()
        {
            return $"{_name} {_surname}";
        }
        public Student(string name, string surname, int[,] marks = null)
        {
            _name = name;
            _surname = surname;
            if (marks != null)
            {
                _marks = marks;
            }
            else
                _marks = new int[0, 0];
        }

    }
}
