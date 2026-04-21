using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9.Green
{
    public class Task3 : Green
    {
        private string _substring;
        private string[] _output;

        public string[] Output
        {
            get => _output ?? Array.Empty<string>();
            private set => _output = value;
        }

        public Task3(string text, string substring) : base(text)
        {
            _substring = substring ?? throw new ArgumentNullException(nameof(substring));
            Review();
        }

        private bool IsWordCharacter(char c)
        {
            // 检查是否为单词字符（字母、连字符、撇号）
            return char.IsLetter(c) || c == '-' || c == '—' || c == '\'' || c == '’';
        }

        private bool IsSeparator(char c)
        {
            // 检查是否为分隔符
            return char.IsWhiteSpace(c) ||
                   char.IsPunctuation(c) ||
                   char.IsSeparator(c) ||
                   c == '\n' ||
                   c == '\r' ||
                   c == '\t';
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_substring))
            {
                Output = Array.Empty<string>();
                return;
            }

            var words = new List<string>();
            var seenWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string currentWord = "";
            string lowerSubstring = _substring.ToLower();

            // 遍历文本中的每个字符
            for (int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];

                if (IsWordCharacter(c))
                {
                    // 如果是单词字符，添加到当前单词
                    currentWord += c;
                }
                else if (IsSeparator(c))
                {
                    // 如果是分隔符，处理当前单词
                    if (currentWord.Length > 0)
                    {
                        ProcessWord(currentWord, lowerSubstring, words, seenWords);
                        currentWord = "";
                    }
                }
                else
                {
                    // 其他字符（数字、符号等）
                    if (currentWord.Length > 0)
                    {
                        ProcessWord(currentWord, lowerSubstring, words, seenWords);
                        currentWord = "";
                    }
                }
            }

            // 处理最后一个单词
            if (currentWord.Length > 0)
            {
                ProcessWord(currentWord, lowerSubstring, words, seenWords);
            }

            Output = words.ToArray();
        }

        private void ProcessWord(string word, string lowerSubstring,
                                List<string> words, HashSet<string> seenWords)
        {
            // 检查单词是否包含指定的子字符串（忽略大小写）
            if (word.ToLower().Contains(lowerSubstring))
            {
                // 检查是否已经添加过（忽略大小写的去重）
                if (!seenWords.Contains(word))
                {
                    words.Add(word);
                    seenWords.Add(word);
                }
            }
        }

        public override string ToString()
        {
            if (Output == null || Output.Length == 0)
            {
                return string.Empty;
            }

            // 每行一个单词
            return string.Join(Environment.NewLine, Output);
        }
    }
}