using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9.Green
{
    public class Task2 : Green
    {
        private char[] _output;

        public char[] Output
        {
            get => _output ?? Array.Empty<char>();
            private set => _output = value;
        }

        public Task2(string text) : base(text) { }

        private static readonly string RussianLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private static readonly string EnglishLetters = "abcdefghijklmnopqrstuvwxyz";

        private bool IsLetter(char c)
        {
            char lower = char.ToLower(c);
            return RussianLetters.Contains(lower) || EnglishLetters.Contains(lower);
        }

        private bool IsWordCharacter(char c)
        {
            return IsLetter(c) || c == '-' || c == '—' || c == '\'' || c == '’';
        }

        private char? GetFirstLetter(string word)
        {
            foreach (char c in word)
                if (IsLetter(c))
                    return char.ToLower(c);
            return null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                Output = Array.Empty<char>();
                return;
            }

            var counts = new Dictionary<char, int>();
            var currentWord = new System.Text.StringBuilder();
            bool hasLetter = false;

            foreach (char c in Input)
            {
                if (IsWordCharacter(c))
                {
                    currentWord.Append(c);
                    if (IsLetter(c))
                        hasLetter = true;
                }
                else
                {
                    // 遇到分隔符，处理当前单词
                    if (currentWord.Length > 0 && hasLetter)
                    {
                        char? first = GetFirstLetter(currentWord.ToString());
                        if (first.HasValue)
                        {
                            char key = first.Value;
                            if (counts.ContainsKey(key))
                                counts[key]++;
                            else
                                counts[key] = 1;
                        }
                    }
                    currentWord.Clear();
                    hasLetter = false;
                }
            }

            // 处理末尾单词
            if (currentWord.Length > 0 && hasLetter)
            {
                char? first = GetFirstLetter(currentWord.ToString());
                if (first.HasValue)
                {
                    char key = first.Value;
                    if (counts.ContainsKey(key))
                        counts[key]++;
                    else
                        counts[key] = 1;
                }
            }

            var sorted = counts
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key, Comparer<char>.Default)
                .Select(kv => kv.Key)
                .ToArray();

            Output = sorted;
        }

        public override string ToString()
        {
            if (Output == null || Output.Length == 0)
                return string.Empty;
            return string.Join(", ", Output);
        }
    }
}