using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab9.Green
{
    public class Task1 : Green
    {
        private (char letter, double frequency)[] _output;

        public (char letter, double frequency)[] Output
        {
            get => _output ?? Array.Empty<(char, double)>(); 
            private set => _output = value;
        }

        public Task1(string text) : base(text) { }

        private static readonly string RussianAlphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                Output = Array.Empty<(char, double)>();
                return;
            }

            var letterCounts = new Dictionary<char, int>();
            foreach (char c in RussianAlphabet)
                letterCounts[c] = 0;

            int totalLetters = 0;
            string lowerText = Input.ToLower();

            foreach (char c in lowerText)
            {
                if (letterCounts.ContainsKey(c))
                {
                    letterCounts[c]++;
                    totalLetters++;
                }
            }

            if (totalLetters == 0)
            {
                Output = Array.Empty<(char, double)>();
                return;
            }

            var result = new List<(char, double)>();
            foreach (char c in RussianAlphabet)
            {
                if (letterCounts[c] > 0)
                {
                    // 先计算原始频率，不做任何舍入
                    double frequency = (double)letterCounts[c] / totalLetters;
                    result.Add((c, frequency));
                }
            }

            Output = result.ToArray();
        }

        public override string ToString()
        {
            if (Output == null || Output.Length == 0)
                return string.Empty;

            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < Output.Length; i++)
            {
                if (i > 0)
                    sb.Append('\n');
                sb.Append(Output[i].letter);
                sb.Append(':');
                // 使用 InvariantCulture 确保点号小数点
                sb.Append(Output[i].frequency.ToString("F4", CultureInfo.InvariantCulture));
            }
            return sb.ToString();
        }
    }
}