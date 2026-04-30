namespace Lab9.White
{
    public class Task4 : White
    {
        private int _output;

        public int Output => _output;

        public Task4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            _output = 0;

            foreach (char c in Input)
            {
                if (char.IsDigit(c))
                {
                    _output += c - '0';
                }
            }
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}