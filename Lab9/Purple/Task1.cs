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

                    ReverseWord(word);

                    Array.Copy(word,0,symbols,left,word.Length);
                    index = right+2;
                }
                else index++;
            }
            Output = new string (symbols);
        }
        private void ReverseWord(char[] word)
        {
            bool hasLetter = word.Any(char.IsLetter);
            bool hasDigit = word.Any(char.IsDigit);

            if (hasLetter && !hasDigit)
            {
                int firstLetterIndex = Array.FindIndex(word, char.IsLetter);
                int lastLetterIndex = Array.FindLastIndex(word, char.IsLetter);

                if (firstLetterIndex >= 0 && lastLetterIndex >= firstLetterIndex)
                {
                    Array.Reverse(word, firstLetterIndex, lastLetterIndex - firstLetterIndex + 1);
                }
            }
        }
    }
}
