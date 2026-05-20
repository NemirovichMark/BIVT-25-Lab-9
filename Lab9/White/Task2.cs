namespace Lab9.White;

public class Task2 : White
{
    // матрица результата
    private int[,] _output;
    // свойство результата
    public int[,] Output => _output;
    // конструктор
    public Task2(string text) : base(text)
    {
        Review();
    }
    // проверка на гласную
    private bool IsVowel(char symbol)
    {
        symbol = char.ToLower(symbol);

        return
            symbol == 'а' ||
            symbol == 'е' ||
            symbol == 'ё' ||
            symbol == 'и' ||
            symbol == 'о' ||
            symbol == 'у' ||
            symbol == 'ы' ||
            symbol == 'э' ||
            symbol == 'ю' ||
            symbol == 'я' ||
            symbol == 'a' ||
            symbol == 'e' ||
            symbol == 'i' ||
            symbol == 'o' ||
            symbol == 'u' ||
            symbol == 'y';
    }

    // анализ текста
    public override void Review()
    {
        int[] counts = new int[100];

        string word = "";

        // + " " чтобы последнее слово тоже обработалось
        foreach (char symbol in Input + " ")
        {
            // собираем слово
            if (char.IsLetter(symbol) ||
                symbol == '-' ||
                symbol == '`')
            {
                word += symbol;
            }
            else
            {
                // если слово закончилось
                if (word.Length > 0)
                {
                    int syllables = 0;

                    // считаем слоги
                    foreach (char letter in word)
                    {
                        if (IsVowel(letter))
                            syllables++;
                    }

                    // если нет гласных
                    if (syllables == 0)
                        syllables = 1;

                    counts[syllables]++;

                    word = "";
                }
            }
        }

        // сколько строк будет в матрице
        int rows = 0;

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] > 0)
                rows++;
        }

        // создаём матрицу
        _output = new int[rows, 2];

        int index = 0;

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] > 0)
            {
                // количество слогов
                _output[index, 0] = i;

                // количество слов
                _output[index, 1] = counts[i];

                index++;
            }
        }
    }

    // вывод матрицы
    public override string ToString()
    {
        if (_output == null)
            return "";

        string result = "";

        for (int i = 0; i < _output.GetLength(0); i++)
        {
            result +=
                _output[i, 0] +
                ":" +
                _output[i, 1];

            if (i != _output.GetLength(0) - 1)
                result += "\n";
        }

        return result;
    }
}
