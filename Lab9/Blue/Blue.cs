namespace Lab9.Blue
{
    public abstract class Blue
    {
        public string Input {get; private set;}
        protected Blue (string text) => Input = text;
        public abstract void Review();
        public void ChangeText(string text)
        {
            Input = text;
            Review();
        }
    }
}