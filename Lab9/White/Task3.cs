namespace Lab9.White
{
    public class Task3 : White
    {
        private string _output;
        private string[,] _codes;

        public string Output => _output;

        public Task3(string input, string[,] codes) : base(input)
        {
            _output = "";
            _codes = codes;
        }

        public override void Review()
        {
            _output = "";

            string palabra = "";

            foreach (char c in Input)
            {
                if (char.IsLetter(c) || c == '-' || c == '\'' || c == '`')
                {
                    palabra += c;
                }
                else
                {
                    if (palabra.Length > 0)
                    {
                        _output += GetCodeOrWord(palabra);
                        palabra = "";
                    }

                    _output += c;
                }
            }

            if (palabra.Length > 0)
            {
                _output += GetCodeOrWord(palabra);
            }
        }

        private string GetCodeOrWord(string palabra)
        {
            if (_codes == null)
            {
                return palabra;
            }

            for (int i = 0; i < _codes.GetLength(0); i++)
            {
                if (_codes[i, 0] == palabra)
                {
                    return _codes[i, 1];
                }
            }

            return palabra;
        }

        public override string ToString()
        {
            return _output;
        }
    }
}