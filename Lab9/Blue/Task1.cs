using System.Text;

namespace Lab9.Blue;

public class Task1 : Blue
{
    public Task1(string text) : base(text) {}
    public string[] Output{get;private set;}
    public override string ToString()
    {
        if (Output == null) return "";
        else return string.Join(Environment.NewLine,Output);
    }
    public override void Review()
    {
        int len = 50;
        int index = 0;
        string[] answer = new string[0];
        string[] words = Input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        while (index < words.Length)
        {
            int start = index;
            int count = 0;
            int currentLength = 0;
            while (index < words.Length)
            {
                if (count == 0)
                {
                    currentLength = words[start].Length;
                    count = 1;
                    index++;
                }
                else if (currentLength + 1 + words[index].Length <= len)
                {
                    currentLength += 1 + words[index].Length;
                    count++;
                    index++;
                }
                else break;
            }
            StringBuilder str = new StringBuilder();
            for(int i=start; i<start + count; i++)
            {
                str.Append(words[i]);
                if (i != start + count - 1)  str.Append(' ');
            }
            Array.Resize(ref answer,answer.Length+1);
            answer[^1] = str.ToString();
        }
        Output = answer;
    }
}