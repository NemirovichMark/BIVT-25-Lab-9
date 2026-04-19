namespace Lab9.Purple
{
    public abstract class Purple
    {
        protected string _input;
        public string Input => _input;
        protected Purple(string input)
        {
            _input = input?? string.Empty;
        }
        public abstract void Review();
        public virtual void ChangeText(string text)
        {
            _input = text?? string.Empty;
            Review();
        }
         public abstract string ToString();
    }
}
