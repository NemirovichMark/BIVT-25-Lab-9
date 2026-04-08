using System.Text;

namespace Lab9.Blue;

public class Task2 : Blue
{
    private string _symbols;
    public Task2(string text, string symbols) 
        : base(text) => _symbols = symbols;
    public string Output {get;private set;}
    public override string ToString() => Output;
    public override void Review()
    {
        int index = 0;
        string[] words = Input.Split();
        StringBuilder str = new StringBuilder();
        while (index < words.Length)
        {
            if (!words[index].Contains(_symbols))
            {
                str.Append(" "); 
                str.Append(words[index]);
            }
            else if (words[index].Contains(_symbols) && 
                    words[index].Any(char.IsPunctuation))
            {
                char[] punct = words[index].Where(char.IsPunctuation).ToArray();
                if (punct.Length >=2) str.Append(" ");
                str.Append(punct);
            }
                    
            index++;
        }
        string correct = str.ToString().TrimEnd();
        correct = correct.TrimStart();
        Output = correct;
    }
}