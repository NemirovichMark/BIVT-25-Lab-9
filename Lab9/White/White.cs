namespace Lab9.White
{
    public abstract class White
    {
        private string _currentText;
        
        public string Input { get; private set; }
        
        protected string Text
        {
            get => _currentText;
            set => _currentText = value;
        }

        protected White(string input)
        {
            Input = input;
            _currentText = input;
        }

        public abstract void Review();

        public virtual void ChangeText(string text)
        {
            _currentText = text;
            Review();
        }

        public abstract override string ToString();
    }
}
