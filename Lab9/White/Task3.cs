using System;
using System.Text;

namespace Lab9.White
{
    public class Task3 : White
    {
        private string[,] _codes;

        private string _output;

        public Task3(string text, string[,] codes) : base(text)
        {
            _codes = codes;
        }

        public string Output
        {
            get
            {
                if (string.IsNullOrEmpty(_output)) return Input;
                return _output;
            }
        }

        public override void Review()
        {
            _output = ReplaceWordsWithCodes(Input);
        }

        private string ReplaceWordsWithCodes(string text)
        {
            var result = new StringBuilder();   //для создания итоговой строки
            var sWord = new StringBuilder();    //место для накопления символов текущего слова

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (char.IsLetter(ch) || ch == '\'' || ch == '-')
                    sWord.Append(ch);
                else
                {
                    //символ не принадлежит слову значит слово закончилось
                    if (sWord.Length > 0)
                    {
                        string word = sWord.ToString();
                        string code = FindCode(word);   //ищем код для слова
                        result.Append(code);            //добавляем код в результат
                        sWord.Clear();
                    }
                    result.Append(ch);
                }
            }

            //если после окончания цикла в буфере осталось слово (текст закончился словом)
            if (sWord.Length > 0)
            {
                string word = sWord.ToString();
                string code = FindCode(word);
                result.Append(code);
            }
            return result.ToString();
        }

        private string FindCode(string word)
        {
            //перебираем все строки таблицы кодов
            for (int i = 0; i < _codes.GetLength(0); i++)
            {
                //сравниваем слово с элементом первого столбца
                if (string.Equals(_codes[i, 0], word, StringComparison.Ordinal))
                    return _codes[i, 1];   //возвращаем найденный код
            }
            return word;
        }

        public override string ToString()
        {
            return Output;
        }
    }
}