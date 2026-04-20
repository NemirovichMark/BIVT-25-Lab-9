using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Text;

namespace Lab9.White
{
    public class Task2 : White
    {
        private int[,] _output;

        public int[,] Output
        {
            get
            {
                if (_output == null)
                {
                    return new int[0, 2];
                }

                return _output;
            }
        }

        public Task2(string text) : base(text)
        {
            _output = new int[0, 2];
        }

        public override void Review()
        {
            _output = MakeMatrix(Input);
        }

        private int[,] MakeMatrix(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new int[0, 2];
            }

            string[] words = GetWords(text);

            if (words.Length == 0)
            {
                return new int[0, 2];
            }

            int[] syllablesInWords = new int[words.Length];
            int maxSyllables = 0;

            for (int i = 0; i < words.Length; i++)
            {
                int syllableCount = CountSyllablesInWord(words[i]);
                syllablesInWords[i] = syllableCount;

                if (syllableCount > maxSyllables)
                {
                    maxSyllables = syllableCount;
                }
            }

            int[,] temp = new int[maxSyllables, 2];

            for (int i = 0; i < syllablesInWords.Length; i++)
            {
                int count = syllablesInWords[i];
                temp[count - 1, 0] = count;
                temp[count - 1, 1]++;
            }

            int rows = 0;

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                if (temp[i, 1] > 0)
                {
                    rows++;
                }
            }

            int[,] result = new int[rows, 2];
            int index = 0;

            for (int i = 0; i < temp.GetLength(0); i++)
            {
                if (temp[i, 1] > 0)
                {
                    result[index, 0] = temp[i, 0];
                    result[index, 1] = temp[i, 1];
                    index++;
                }
            }

            return result;
        }

        private string[] GetWords(string text)
        {
            StringBuilder currentWord = new StringBuilder();
            int count = 0;

            bool wordAfterNumber = false;
            bool previousWasDigit = false;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c) || c == '-' || c == '\'')
                {
                    if (currentWord.Length == 0)
                    {
                        wordAfterNumber = previousWasDigit;
                    }

                    currentWord.Append(c);
                    previousWasDigit = false;
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        if (!wordAfterNumber)
                        {
                            count++;
                        }

                        currentWord.Clear();
                    }

                    previousWasDigit = char.IsDigit(c);
                }
            }

            if (currentWord.Length > 0 && !wordAfterNumber)
            {
                count++;
            }

            string[] result = new string[count];
            currentWord.Clear();

            wordAfterNumber = false;
            previousWasDigit = false;
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c) || c == '-' || c == '\'')
                {
                    if (currentWord.Length == 0)
                    {
                        wordAfterNumber = previousWasDigit;
                    }

                    currentWord.Append(c);
                    previousWasDigit = false;
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        if (!wordAfterNumber)
                        {
                            result[index] = currentWord.ToString();
                            index++;
                        }

                        currentWord.Clear();
                    }

                    previousWasDigit = char.IsDigit(c);
                }
            }

            if (currentWord.Length > 0 && !wordAfterNumber)
            {
                result[index] = currentWord.ToString();
            }

            return result;
        }

        private int CountSyllablesInWord(string word)
        {
            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (IsVowel(word[i]))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                count = 1;
            }

            return count;
        }

        private bool IsVowel(char c)
        {
            char[] vowels =
            {
                'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я',
                'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я',
                'a', 'e', 'i', 'o', 'u', 'y',
                'A', 'E', 'I', 'O', 'U', 'Y'
            };

            for (int i = 0; i < vowels.Length; i++)
            {
                if (vowels[i] == c)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            if (Output.GetLength(0) == 0)
            {
                return "";
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < Output.GetLength(0); i++)
            {
                builder.Append(Output[i, 0]);
                builder.Append(':');
                builder.Append(Output[i, 1]);

                if (i < Output.GetLength(0) - 1)
                {
                    builder.AppendLine();
                }
            }

            return builder.ToString();
        }
    }
}