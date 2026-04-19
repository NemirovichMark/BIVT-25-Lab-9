namespace Lab9.Green
{
    public class Task1 : Green
    {
        private string _output;
        public string Output => _output;

        public Task1(string text) : base(text)
        {
            _output = string.Empty;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = string.Empty;
            }
            else
            {
                _output = Input.ToUpper(); 
            }
        }

        public override string ToString()
        {
            return _output?.ToString() ?? string.Empty;
        }
    }
}
