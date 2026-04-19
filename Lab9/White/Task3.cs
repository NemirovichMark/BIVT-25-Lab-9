namespace Lab9.White
{
    public class Task3 : White
    {
        private string[,] _codes; // поле для хранения таблицы
        private string _output;
        public string Output => _output;
        public string[,] Codes => _codes;
        public Task3(string input, string[,] codes) : base(input) 
        {
            _codes = codes; ;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_input) || _codes == null)
            {
                _output = _input;
                return;
            }

            // Добавляем пробелы по краям, чтобы Split и поиск работали корректно
            // и создаем массив слов, чтобы не менять части внутри слов
            string[] words = _input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                // Убираем знаки препинания только для проверки совпадения (опционально)
                for (int j = 0; j < _codes.GetLength(0); j++)
                {
                    if (words[i] == _codes[j, 0])
                    {
                        words[i] = _codes[j, 1];
                        break; // Нашли замену — переходим к следующему слову
                    }
                }
            }

            //  Собираем слова обратно в строку
            _output = string.Join(" ", words);
        }

        public override string ToString()
        {
            return _output ?? " ";
        }
    }
}
