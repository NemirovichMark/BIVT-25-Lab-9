using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab9.Green
{
    public class Task3 : Green
    {
        private string pattern;

        public string[] Output { get; private set; }

        public Task3(string input, string pattern) : base(input)
        {
            this.pattern = pattern.ToLower();
            Output = Array.Empty<string>();
        }

        public override void Review()
        {
            var words = Input
                .Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            var seen = new HashSet<string>();
            var result = new List<string>();

            foreach (var w in words)
            {
                var lower = w.ToLower();
                if (lower.Contains(pattern) && !seen.Contains(lower))
                {
                    seen.Add(lower);
                    result.Add(w);
                }
            }

            Output = result.ToArray();
        }

        public override string ToString()
        {
            return string.Join("\n", Output);
        }
    }
}
