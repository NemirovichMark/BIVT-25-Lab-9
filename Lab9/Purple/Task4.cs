namespace Lab9.Purple
{
    public class Task4 : Purple
    {
        private string _output;
        private (string, char)[] _table;

        public string Output => _output;
        public Task4(string input, (string, char)[] table) : base(input)
        {
            _output = default;
            _table = table;
        }


        public override string ToString()
        {
            return _output;
        }

        public override void Review()
        {
            if (_table == null || _table.Length == 0)
            {
                return;
            }

            int lenTable = _table.Length;
            char code;
            string pair;
            bool fl;

            for (int i = 0; i < _input.Length; i++)
            {
                fl = true;
                for (int j = 0; j < lenTable; j++)
                {
                    (pair, code) = _table[j];
                    if (_input[i] == code)
                    {
                        _output += pair;
                        fl = false;
                        break;
                    }
                }
                if (fl)
                {
                    _output += _input[i];
                }
            }
        }
    }
}
