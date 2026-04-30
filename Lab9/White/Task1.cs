namespace Lab9.White
{
    public class Task1 : White
    {
        private double _output;

        public double Output => _output;

        public Task1(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            int palabras = 0;
            int puntuacion = 0;
            int oraciones = 0;
            double total = 0;

            bool inWord = false;

            foreach (char c in Input)
            {
                if (char.IsLetter(c) || c == '-' || c == '\'')
                {
                    if (!inWord)
                    {
                        palabras++;
                        inWord = true;
                    }
                }
                else
                {
                    inWord = false;
                }

                if (char.IsPunctuation(c))
                {
                puntuacion++;
                }

                if (c == '.' || c == '!' || c == '?')
                {
                    total += palabras + puntuacion;
                    oraciones++;
                    palabras = 0;
                    puntuacion = 0;
                    inWord = false;
                }
            }

            
            if (oraciones > 0)
            {
                _output = total / oraciones;
            }
            else
            {
                _output = 0;
            }
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}