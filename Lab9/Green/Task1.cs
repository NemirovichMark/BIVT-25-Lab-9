using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab9.Green
{
    public class Task1 : Green
    {
        public (char, double)[] Output { get; private set; }

        public Task1(string input) : base(input)
        {
            Output = Array.Empty<(char, double)>();
        }

        public override void Review()
        {
            var letters = Input
                .ToLower()
                .Where(c => c >= 'а' && c <= 'я')
                .ToArray();

            int total = letters.Length;

            Output = letters
                .GroupBy(c => c)
                .Select(g => (g.Key, (double)g.Count() / total))
                .OrderBy(t => t.Key)
                .ToArray();
        }

        public override string ToString()
        {
            return string.Join("\n", Output
                .Select(t => $"{t.Item1}:{t.Item2:F4}"));
        }
    }
}
