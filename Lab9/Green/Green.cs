namespace Lab9.Green
{
namespace Lab9.Green
{
    public abstract class Green
    {
        private string _imput;
        public string Input => _imput;
        protected Green(string input)
        {
            _imput = input;
        }
        public abstract void Review();
        public virtual void ChangeText(string text)
        {
            _imput = text;
            Review();
        }
    }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Green
{
    public class Task1 : Green
    {
        private (char Char, double Count)[] _output;
        public (char, double)[] Output => _output.ToArray();

        public Task1(string input) : base(input)
        {
            _output = new (char, double)[33];
        }

        public (char, double)[] Alp(string input)
        {
            input = Input;
            string alfavit = "йцукенгшщзхъфывапролджэячсмитьбюё";
            for (int i = 0; i < alfavit.Length; i++)
            {
                char chacha = alfavit[i];
                _output[i].Char = chacha;
                int count = input.Where(c => char.ToLower(c) == chacha).Count();
                _output[i].Count = (count/Input.Length);
            }
            return _output;
        }

        public override void Review()
        {
            //обработать тест в инпут но инпут сам не менять!!!
            //отпут долженр возвращать правильный ответ для инпут
            
        }

        public override string ToString()
        {
            return "jk";
        }

    }
}
