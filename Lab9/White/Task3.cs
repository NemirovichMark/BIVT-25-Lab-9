using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.White
{
    public class Task3 : White
    {
        private string[,] _codes;
        private string _output;

        public string Output
        {
            get { return _output; }
        }

        public Task3(string text, string[,] codes) : base(text)
        {
            _codes = codes;
            _output = default(string);
        }

        public override void Review()
        {
            string text = Input;

            if (text == null)
            {
                _output = null;
                return;
            }

            string result = "";
            string currentWord = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (IsWordChar(c))
                {
                    currentWord += c;
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        result += ReplaceWord(currentWord);
                        currentWord = "";
                    }

                    result += c;
                }
            }

            if (currentWord.Length > 0)
            {
                result += ReplaceWord(currentWord);
            }

            _output = result;
        }

        private string ReplaceWord(string word)
        {
            if (_codes == null)
            {
                return word;
            }

            for (int i = 0; i < _codes.GetLength(0); i++)
            {
                if (_codes[i, 0] == word)
                {
                    return _codes[i, 1];
                }
            }

            return word;
        }

        public override string ToString()
        {
            return Output;
        }
    }
}
