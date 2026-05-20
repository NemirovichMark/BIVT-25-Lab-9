namespace Lab9.White;

public class Task4 : White
{
    // сумма всех цифр
    private int _output;
    // свойство результата
    public int Output => _output;
    // конструктор
    public Task4(string text) : base(text)
    {
        Review();
    }

    // анализ текстa
    public override void Review()
    {
        _output = 0;

        if (Input == null)
            return;

        foreach (char symbol in Input)
        {
            // цифра от 0 до 9
            if (symbol >= '0' && symbol <= '9')
            {
                // получаем значение цифры без Convert/TryParse
                _output += symbol - '0';
            }
        }
    }

    // вывод результата
    public override string ToString()
    {
        return Output.ToString();
    }
}
