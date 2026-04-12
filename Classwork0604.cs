public class Program
{
    public static void Main()
    {
        // classwork 6-04
        System.Console.WriteLine("classwork 6-04");
        var students = new Student[]
        {
            new Student("A","a", new int[,] {{4,5,3},{4,5,2}}),
            new Student("B","b", new int[,] {{4,2,3},{4,5,3}}),
            new Student("C","c", new int[,] {{5,5,5},{4,5,5}})
        };
        System.Console.WriteLine(students[0][0,1]);

        string str = "hell0 my name is maksim";
        string str2 = "Nah i'm build different";
        str = "Ha OMG Ha OMG ";

        str2 = str.ToLower();
        System.Console.WriteLine(str2);

        str2 = str.Substring(0,5);
        System.Console.WriteLine(str2);

        str2 = str.Replace("Ha","LALALA");
        System.Console.WriteLine(str2);
        str2 = str.Replace('O','S');
        System.Console.WriteLine(str2);

        string[] strings1 = str2.Split();
        string[] strings2 = str2.Split(new char[]{'.','?','!'},StringSplitOptions.RemoveEmptyEntries);
        // StringSplitOptions.RemoveEmptyEntries <- убирает пустоты
        System.Console.WriteLine(str.IndexOf('O'));

        System.Console.WriteLine(char.IsLetter(str[0]));
        System.Console.WriteLine(char.IsDigit(str[0]));
        System.Console.WriteLine(char.IsSeparator(str[0]));
        System.Console.WriteLine(char.IsPunctuation(str[0]));

        string output = $"New\ntext\ron\r\neach{Environment.NewLine}line";
        System.Console.WriteLine(output);

        StringBuilder sb = new StringBuilder();
        sb.Append("Hello my name is Maksim"); // Replace , Remove 
        string a = sb.ToString();
        System.Console.WriteLine(sb);
        System.Console.WriteLine(a);

        Regex regex = new Regex("[/d+]");
        System.Console.WriteLine(regex);
        string pat = "122tHAhdadbwuadu987dwd";
        var result = regex.Match(pat);
        foreach (var match in result.Value)
        {
            System.Console.WriteLine(match);
        }
    }
}

public class Student
{
    string _name;
    string _surname;
    int[,] _marks;

    // public double this[int idx] => AverageMarks[idx];
    public char this[int idx] => _name[idx];
    public double this[int i, int j]
    {
        get{ return _marks[i,j];}
        set
        {
            if (value >=2 && value <=5){}
                // _marks[i,j] = value;
        }
    }
    public int[,] Marks => (int[,])_marks.Clone();
    public double[] AverageMarks
    {
        get
        {
            if (_marks==null || _marks.GetLength(0) == 0 || _marks.GetLength(1)==0)
                return null;
            var average = new double[_marks.GetLength(0)];
            for (int i=0; i < _marks.GetLength(0); i++)
            {
                for (int j=0; j<_marks.GetLength(1);j++)
                    average[i]+= (double)_marks[i,j]/_marks.GetLength(1);
            }
            return average;
        }
    }
    
    public Student(string name, string surname,int[,] marks = null)
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
        var output =  _name + " " + _surname;
        for (int i=0; i<_marks.GetLength(0); i++)
        {
            for (int j=0 ; j<_marks.GetLength(1); j++)
            {
                output += _marks[i,j] + " ";
            }
            output=output.TrimEnd(); // отрезает пробелы
            output += Environment.NewLine;
        }
        return output;
        // StringBuilder sb = new StringBuilder(_name);
        // sb.Append(" ");
        // sb.Append(_surname);
        // for (int i=0; i<_marks.GetLength(0); i++)
        // {
        //     for (int j=0 ; j<_marks.GetLength(1); j++)
        //     {
        //         sb.Append(_marks[i,j]).Append(" ");
        //     }
        //     sb.Remove(sb.Length-1,1);
        //     sb.AppendLine();
        // }
        // return sb.ToString();
    }
}
