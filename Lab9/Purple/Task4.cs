using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Purple
{
    public class Task4 : Purple
    {
        private (string, char)[] Codes {  get; set; }
        public string Output { get; private set; }
        public Task4(string input, (string, char)[] codes) : base(input)
        {
            Codes = codes;
        }

        public override void Review()
        {
            Output = Input;
            foreach (var pair in Codes)
            {
                Output = Output.Replace((pair.Item2).ToString(), pair.Item1);
            }
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
