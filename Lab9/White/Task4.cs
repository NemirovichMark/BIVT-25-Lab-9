using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.White
{
    public class Task4 : White
    {
        private int _output;

        public int Output
        {
            get { return _output; }
        }

        public Task4(string text) : base(text)
        {
            _output = default(int);
        }

        public override void Review()
        {
            string text = Input;

            if (text == null)
            {
                _output = 0;
                return;
            }

            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    sum += text[i] - '0';
                }
            }

            _output = sum;
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}