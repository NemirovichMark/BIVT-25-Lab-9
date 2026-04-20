using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using System;

using System;
using System.Text;

namespace Lab9.White
{
    public class Task1 : White
    {
        private readonly char[] _punctuation =
        {
            '.', '!', '?', ',', ':', '"', ';', '–', '\'', '(', ')', '[', ']', '{', '}', '/'
        };

        private readonly char[] _sentenceEnds = { '.', '!', '?' };

        private double _output;

        public double Output
        {
            get { return _output; }
        }

        public Task1(string text) : base(text)
        {
            _output = 0;
        }

        public override void Review()
        {
            _output = GetAverageSentenceComplexity();
        }

        private double GetAverageSentenceComplexity()
        {
            if (string.IsNullOrEmpty(Input))
            {
                return 0;
            }

            string[] sentences = SplitTextIntoSentences(Input);

            if (sentences.Length == 0)
            {
                return 0;
            }

            double sum = 0;
            int count = 0;

            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i].Trim();

                if (string.IsNullOrWhiteSpace(sentence))
                {
                    continue;
                }

                int words = CountWords(sentence);
                int punctuationMarks = CountPunctuation(sentence);

                sum += words + punctuationMarks;
                count++;
            }

            if (count == 0)
            {
                return 0;
            }

            return sum / count;
        }

        private string[] SplitTextIntoSentences(string text)
        {
            StringBuilder builder = new StringBuilder();
            int sentenceCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                builder.Append(text[i]);

                if (IsSentenceEnd(text[i]))
                {
                    bool lastChar = i == text.Length - 1;
                    bool nextIsSpace = !lastChar && char.IsWhiteSpace(text[i + 1]);

                    if (lastChar || nextIsSpace)
                    {
                        sentenceCount++;
                        builder.Clear();
                    }
                }
            }

            if (builder.Length > 0)
            {
                sentenceCount++;
            }

            string[] result = new string[sentenceCount];
            builder.Clear();

            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                builder.Append(text[i]);

                if (IsSentenceEnd(text[i]))
                {
                    bool lastChar = i == text.Length - 1;
                    bool nextIsSpace = !lastChar && char.IsWhiteSpace(text[i + 1]);

                    if (lastChar || nextIsSpace)
                    {
                        result[index] = builder.ToString();
                        index++;
                        builder.Clear();
                    }
                }
            }

            if (builder.Length > 0)
            {
                result[index] = builder.ToString();
            }

            return result;
        }

        private int CountWords(string sentence)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < sentence.Length; i++)
            {
                char c = sentence[i];

                if (!IsPunctuation(c))
                {
                    builder.Append(c);
                }
            }

            string cleared = builder.ToString().Replace('-', ' ');
            string[] parts = cleared.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            return parts.Length;
        }

        private int CountPunctuation(string sentence)
        {
            int count = 0;

            for (int i = 0; i < sentence.Length; i++)
            {
                if (IsPunctuation(sentence[i]))
                {
                    count++;
                }
            }

            return count;
        }

        private bool IsSentenceEnd(char c)
        {
            for (int i = 0; i < _sentenceEnds.Length; i++)
            {
                if (_sentenceEnds[i] == c)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsPunctuation(char c)
        {
            for (int i = 0; i < _punctuation.Length; i++)
            {
                if (_punctuation[i] == c)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}