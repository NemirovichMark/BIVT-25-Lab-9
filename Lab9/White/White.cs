namespace Lab9.White
{
    public abstract class White
    {
        private string _input;
        private string _text;

        public string Input => _input;

        protected White(string input)
        {
            _input = input;
            _text = input;
        }

        protected string Text
        {
            get => _text;
            set => _text = value;
        }

        public abstract void Review();

        public virtual void ChangeText(string text)
        {
            _text = text;
            Review();
        }

        public abstract override string ToString();
    }
}
