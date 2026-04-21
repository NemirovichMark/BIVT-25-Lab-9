using Lab9.Blue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Blue
{
    public class Task2 : Blue
    {
        private string _sequence;
        private string _output = string.Empty;

        public string Output => _output;

        public Task2(string inputText, string sequence) : base(inputText)
        {
            _sequence = sequence;
            Review();
        }

        public override void Review()
        {

            string[] tokens = Input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] processedTokens = new string[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                int firstl = -1;
                int lastL =  -1;

                for (int j = 0; j < token.Length; j++)
                {
                    if (char.IsLetterOrDigit(token[j]))
                    {
                        if (firstl == -1) firstl = j;
                        lastL = j;
                    }
                }

                if (firstl == -1)
                {
                    processedTokens[i] = token;
                    continue;
                }

                string pre = token.Substring(0, firstl);
                string wordPart = token.Substring(firstl, lastL - firstl + 1);
                string suf = token.Substring(lastL + 1);

                if (wordPart.Contains(_sequence))
                {
                    processedTokens[i] = pre + suf;
                }
                else
                {
                    processedTokens[i] = token;
                }
            }

            string result = string.Join(" ", processedTokens);

            string[] marks = { ".", ",", "!", "?", ":", ";" };
            foreach (var mark in marks)
            {
                result = result.Replace(" " + mark, mark);
            }

            while (result.Contains("  "))
            {
                result = result.Replace("  ", " ");
            }

            _output = result.Trim();
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
