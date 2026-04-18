using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Purple
{
    public class Task4 : Purple
    {
        private (string, char)[] _codes;
        private string _output;

        private (string, char)[] Codes => _codes.ToArray();
        public string Output => _output;
        public Task4(string input, (string, char)[] codes) : base(input)
        {
            _codes = codes;
        }

        public override void Review()
        {
            string res = Input;
            for (int i = 0; i < Codes.Length; i++)
            {
                string code = Codes[i].Item1;
                string replace = "";
                replace += Codes[i].Item2;

                res = res.Replace(replace, code);
            }

            _output = res;
        }

        public override string ToString()
        {
            Review();
            return _output;

        }
    }
}
