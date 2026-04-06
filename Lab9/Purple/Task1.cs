namespace Lab9.Purple
{
    public class Task1 : Purple
    {
        public Task1(string input) : base(input) {}
        public string Output {get; private set;}
        public override string ToString() => Output;  
        public override void Review()
        {
            char[] symbols = Input.ToCharArray();
            int index = 0;
            while (index < symbols.Length)
            {
                if (!char.IsWhiteSpace(symbols[index]))
                {
                    int left = index, right = index;
                    while ( right < symbols.Length && 
                            !char.IsWhiteSpace(symbols[right]))
                    {right++;}
                    right--;

                    char[] word = new char[right-left+1];
                    Array.Copy(symbols,left,word,0,right-left+1);

                    bool has_letter = word.Any(c => char.IsLetter(c));
                    bool last_symbol_is_punctuation = char.IsPunctuation(word[word.Length-1]);

                    if (has_letter)
                    {
                        if (last_symbol_is_punctuation)
                        {
                            Array.Reverse(word,0,right-left);
                        }
                        else Array.Reverse(word);
                    }

                    Array.Copy(word,0,symbols,left,word.Length);
                    index = right+2;
                }
                else index++;
            }
            Output = new string (symbols);
        }
         
    }
}