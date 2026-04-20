public static void Main(string[] args)
{
    var students = new Student[]
    {
        new Student("A", "a", new int[,] { { 4, 5, 3 }, { 4, 5, 2 } }),
        new Student("B", "b", new int[,] { { 4, 2, 3 }, { 4, 5, 3 } }),
        new Student("C", "c", new int[,] { { 5, 5, 5 }, { 4, 5, 5 } })
    };
    Console.WriteLine("Students:");
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
    Console.WriteLine("Indexers:");
    Console.WriteLine(students[0][0]);
    Console.WriteLine(students[0][0, 1]);
    students[0][0, 1] = 5;
    Console.WriteLine(students[0][0, 1]);
    Console.WriteLine("Average marks:");
  
    foreach (var value in students[0].AverageMarks)
    {
        Console.WriteLine(value);
    }
  
    string str = "Hello World! Programming in C# is fun!";
    string str2 = str;

    str2 = str.ToLower();
    Console.WriteLine(str2);

    str2 = str.Substring(6, 5);
    Console.WriteLine(str2);

    str2 = str.Replace("World", "Universe");
    Console.WriteLine(str2);

    str2 = str.Replace('o', '0');
    Console.WriteLine(str2);

    string[] strings1 = str.Split(' ');
    string[] strings2 = str.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine(str.IndexOf('C'));

    foreach (var c in str)
    {
        bool isLetter = Char.IsLetter(c);
        bool isDigit = Char.IsDigit(c);
        bool isSeparator = Char.IsSeparator(c);
        bool isPunctuation = Char.IsPunctuation(c);
    }

    string output = $"Line1\nLine2\r\nLine3{Environment.NewLine}End";
    Console.WriteLine(output);

    StringBuilder sb = new StringBuilder();
    sb.Append("Learning C# step by step");
    sb.Remove(8, 2);
    Console.WriteLine(sb.ToString());

    Regex regex = new Regex(@"\d+");
    var matches = regex.Matches("Test123 example45 data6");
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Value);
    }
}
