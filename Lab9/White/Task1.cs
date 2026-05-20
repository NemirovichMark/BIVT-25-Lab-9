namespace Lab9.White;
public class Task1 : White
{
    private double _output;
    public double Output => _output;
    public Task1(string text) : base(text)
    {
        Review();
    }

    public override void Review()
    {
        if (Input == null || Input.Length == 0)
        {
            _output = 0;
            return;
        }

        int sentenceCount = 0;
        int totalComplexity = 0;
        int currentComplexity = 0;
        bool inWord = false;

        foreach (char symbol in Input)
        {
            if (char.IsLetter(symbol) || symbol == '-' || symbol == '`')
            {
                if (!inWord)
                {
                    currentComplexity++;
                    inWord = true;
                }
            }
            else
            {
                inWord = false;

                if (char.IsPunctuation(symbol))
                    currentComplexity++;

                if (symbol == '.' || symbol == '!' || symbol == '?')
                {
                    sentenceCount++;
                    totalComplexity += currentComplexity;
                    currentComplexity = 0;
                }
            }
        }

        if (currentComplexity > 0)
        {
            sentenceCount++;
            totalComplexity += currentComplexity;
        }

        _output = sentenceCount == 0 ? 0 : (double)totalComplexity / sentenceCount;
    }

    public override string ToString()
    {
        return Output.ToString();
    }
}
