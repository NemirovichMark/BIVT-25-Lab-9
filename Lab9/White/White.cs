namespace Lab9.White
{
    public abstract class White
    {
        private string _input;

        public string Input
        {
            get { return _input; }
        }

        protected White(string text)
        {
            _input = text;
        }

        public abstract void Review();

        public virtual void ChangeText(string text)
        {
            _input = text;
            Review();
        }

        protected bool IsWordChar(char c)
        {
            return char.IsLetter(c) || c == '-' || c == '\'' || c == '`';
        }

        protected bool IsSentenceEnd(char c)
        {
            return c == '.' || c == '!' || c == '?';
        }

        protected bool IsTextSeparator(char c)
        {
            return char.IsSeparator(c) || c == '\n' || c == '\r' || c == '\t';
        }

        protected bool IsVowel(char c)
        {
            char lower = char.ToLower(c);
            string vowels = "аеёиоуыэюяaeiouy";
            return vowels.IndexOf(lower) >= 0;
        }

        protected int CountSyllables(string word)
        {
            if (word == null)
            {
                return 1;
            }

            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                count = 1;
            }

            return count;
        }
    }
}
