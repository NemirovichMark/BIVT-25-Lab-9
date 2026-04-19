using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.White
{
    public class Task1 : White
    {
        private double _output;
        public double Output => _output;
        public Task1(string input) : base(input) // массив должен быть null
        {
            _output = 0;
        }
        public override void Review()
        {
            string[] sentenses = SplitToSentenses();
            if (sentenses == null || sentenses.Length == 0) return;
            double Complexity = 0;
            foreach (string sent in sentenses)
            {
                int punctCount = CountPunctuation(sent);// считаем знаки в конкретном предложении
                int wordsCount = SplitToWords(sent).Length; // считаем слова в конкретном предложении
                Complexity += (wordsCount + punctCount + 1);
            }
            _output = Complexity / sentenses.Length;
        }
        public override string ToString()
        {
            return _output.ToString(); // возвращаем только число,преобразованное в строку
        }
    }
}
