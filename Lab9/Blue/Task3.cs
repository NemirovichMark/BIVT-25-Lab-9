using System.Data.Common;

namespace Lab9.Blue;

public class Task3 : Blue
{
    public Task3(string text) : base(text) {}
    public (char,double)[] Output {get; private set;}
    public override string ToString() => 
        string.Join(Environment.NewLine, Output.Select(t => $"{t.Item1}:{t.Item2:F4}"));
    public override void Review()
    {
        int index = 0;
        string[] words = Input.Split();
        Pair[] pairs = new Pair[0];
        while (index < words.Length)
        {
            if (char.IsLetter(words[index][0]))
            {
                Pair pair = pairs.FirstOrDefault(p => p.Symbol == char.ToLower(words[index][0]));
                if (pair != null) pair.RaiseCount();
                else
                {
                    Pair term = new Pair(char.ToLower(words[index][0]));
                    Array.Resize(ref pairs, pairs.Length+1);
                    pairs[^1] = term;
                }
            }
            index++;
        }
        
        int totalSymbols = words.Length;
        (char,double)[] answer = new (char,double)[pairs.Length];
        for (int i=0; i<pairs.Length; i++)
        {
            char symbol = char.ToLower(pairs[i].Symbol);
            double percent = pairs[i].Count/(double)totalSymbols * 100;
            answer[i] = (symbol,percent);
        }

        Array.Sort(answer, CompairNumbers);
        Output = answer;
    }

    private static int CompairNumbers ((char,double) a, (char,double) b)
    {
        int res = -a.Item2.CompareTo(b.Item2);
        if (res != 0) return res;
        return a.Item1.CompareTo(b.Item1);
    }
    private class Pair
    {
        public char Symbol{get; private set;}
        public int Count{get; private set;}
        public Pair (char symbol)
        {
            Symbol =  symbol;
            Count = 1;  
        }
        public void RaiseCount() => Count++;
    }
}