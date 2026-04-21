using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab9.Green
{
    public class Task2 : Green
    {
        public char[] Output { get; private set; }

        public Task2(string input) : base(input)
        {
            Output = Array.Empty<char>();
        }

        public override void Review()
        {
            var words = Input
                .ToLower()
                .Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            var result = words
                .Where(w => w.Length > 0 && w[0] >= 'а' && w[0] <= 'я')
                .GroupBy(w => w[0])
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Select(g => g.Key)
                .ToArray();

            Output = result;
        }

        public override string ToString()
        {
            return string.Join(", ", Output);
        }
    }
}
