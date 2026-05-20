namespace Lab9.White;

public class Task3 : White
{
    // итоговый текст после замены слов
    private string _output;
    // таблица кодов: 1-й столбец слово, 2-й столбец код
    private string[,] _codes;
    // свойство результата
    public string Output => _output;
    // конструктор
    public Task3(string text, string[,] codes) : base(text)
    {
        _codes = codes;
        Review();
    }
    // анализ и замена текста
    public override void Review()
    {
        if (Input == null)
        {
            _output = "";
            return;
        }

        if (_codes == null)
        {
            _output = Input;
            return;
        }

        string result = "";
        string word = "";

        foreach (char symbol in Input + " ")
        {
            // собираем слово
            if (char.IsLetter(symbol) || symbol == '-' || symbol == '`')
            {
                word += symbol;
            }
            else
            {
                if (word.Length > 0)
                {
                    result += GetCode(word);
                    word = "";
                }

                result += symbol;
            }
        }

        // убираем лишний пробел, который добавили в конце
        _output = result.Substring(0, result.Length - 1);
    }

    // ищет код для слова
    private string GetCode(string word)
    {
        for (int i = 0; i < _codes.GetLength(0); i++)
        {
            if (_codes[i, 0] == word)
                return _codes[i, 1];
        }

        return word;
    }

    // вывод результата
    public override string ToString()
    {
        return Output;
    }
}
