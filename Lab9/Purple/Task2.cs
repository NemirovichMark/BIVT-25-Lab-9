using System.Text;

namespace Lab9.Purple;

public class Task2 : Purple
{
    public Task2(string input) : base(input) {}
    public string[] Output {get;private set;}
    public override string ToString()
    {
        if (Output == null) return string.Empty;
        return string.Join(Environment.NewLine,Output);
    }
    public override void Review()
    {
        int len = 50;
        int index = 0;
        string[] answer = new string[0];
        string[] words = Input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        while (index < words.Length)
        {
            int count = 0;
            int start = index;
            int currentLength = 0;
            StringBuilder temp = new StringBuilder();
            
            while (index < words.Length)
            {
                if (currentLength == 0)
                {
                    currentLength+=words[index].Length;
                    count++;
                    index++;
                }
                else
                {
                    if (currentLength + 1 + words[index].Length <= len)
                    {
                        currentLength += words[index].Length + 1;
                        count++;
                        index++;
                    }
                    else break;
                }
            }

            if (count == 1)
            {
                temp.Append(words[start]);
            }
            else
            {
                int letters = 0;
                for (int i=start; i < start+count; i++)
                    letters+= words[i].Length;
                
                int gaps = count -1;
                int spaces = len - letters;
                int needSpaces = spaces / gaps;
                int extrSpaces = spaces % gaps;

                for (int i=0; i<count; i++)
                {
                    temp.Append(words[start+i]);
                    if (i < gaps)
                    {
                        int spcs = needSpaces;
                        if (extrSpaces > 0)
                        {
                            spcs++;
                            extrSpaces--;
                        }
                        temp.Append(' ',spcs);    
                    }
                }
            }

            Array.Resize(ref answer, answer.Length+1);
            answer[^1] = temp.ToString();
        }

        Output = answer;
    }
}
