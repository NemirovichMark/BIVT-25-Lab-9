using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Purple
{
    public class Task2 : Purple
    {
        private string[] _output;
        public string[] Output => _output;

        public Task2(string text) : base(text) { }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _output);
        }

        private static string Space(string line)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int gapsCount = words.Length - 1;

            if (gapsCount <= 0)
                return line;

            int totalChars = words.Sum(word => word.Length);
            int spacesToDistribute = 50 - totalChars;

            for (int i = 0; i < gapsCount; i++)
            {
                words[i] += ' ';
                spacesToDistribute--;
            }

            for (int i = 0; i < spacesToDistribute; i++)
            {
                words[i % gapsCount] += ' ';
            }

            return string.Concat(words);
        }

        public override void Review()
        {
            string[] allWords = Input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] resultLines = new string[0];
            var currentLine = new StringBuilder();
            int currentLength = 0;

            currentLine.Append(allWords[0]);
            currentLength = allWords[0].Length;

            for (int i = 1; i < allWords.Length; i++)
            {
                string nextWord = allWords[i];

                if (currentLength + 1 + nextWord.Length <= 50)
                {
                    currentLine.Append(' ');
                    currentLine.Append(nextWord);
                    currentLength += nextWord.Length + 1;
                }
                else
                {
                    Array.Resize(ref resultLines, resultLines.Length + 1);
                    resultLines[resultLines.Length - 1] = Space(currentLine.ToString());

                    currentLine.Clear();
                    currentLine.Append(nextWord);
                    currentLength = nextWord.Length;
                }
            }

            if (currentLine.Length > 0)
            {
                Array.Resize(ref resultLines, resultLines.Length + 1);
                resultLines[resultLines.Length - 1] = Space(currentLine.ToString());
            }

            _output = resultLines;
        }
    }
}
