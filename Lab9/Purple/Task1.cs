using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Purple
{
    public class Task1 : Purple
    {
        private string _output;

        public string Output => _output;

        public override string ToString() => _output;

        public Task1(string text) : base(text) { }


        public override void Review()
        {
            char[] chars = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', ' ' };
            int n = _input.Length;
            string word = "";
            string revWord;
            bool reverse = true;


            for (int i = 0; i < n; i++)
            {
                if (chars.Contains(_input[i]))
                {
                    if (char.IsDigit(_input[i - 1]) && i + 1 < n && char.IsDigit(_input[i + 1]) && _input[i] == ',')
                    {
                        word += _input[i];
                    }
                    else
                    {
                        if (reverse == false)
                        {
                            _output += word + _input[i];
                            word = "";
                            reverse = true;
                        }
                        else
                        {
                            revWord = "";
                            for (int j = 0; j < word.Length; j++)
                            {
                                revWord += word[word.Length - j - 1];
                            }
                            _output += revWord + _input[i];
                            word = "";
                        }
                    }

                }

                else if (char.IsDigit(_input[i]))
                {
                    reverse = false;
                    word += _input[i];
                }

                else
                {
                    word += _input[i];
                }
            }
        }


    }
}
