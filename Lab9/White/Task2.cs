namespace Lab9.White
{
    public class Task2 : White
    {
        private int[,] _output;

        public int[,] Output => _output;

        public Task2(string input) : base(input)
        {
            _output = new int[0, 0];
        }

        public override void Review()
        {
            int[] counts = new int[100]; // índice = cantidad de sílabas

            string palabra = "";

            foreach (char c in Input)
            {
                // si es parte de una palabra
                if (char.IsLetter(c) || c == '-' || c == '\'' || c == '`')
                {
                    palabra += c;
                }
                else
                {
                    // terminó una palabra
                    if (palabra.Length > 0)
                    {
                        int silabas = ContarSilabas(palabra);
                        counts[silabas]++;
                        palabra = "";
                    }
                }
            }

            // por si el texto termina en palabra
            if (palabra.Length > 0)
            {
                int silabas = ContarSilabas(palabra);
                counts[silabas]++;
            }

            // contar filas necesarias
            int filas = 0;
            for (int i = 1; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    filas++;
                }
            }

            _output = new int[filas, 2];

            int index = 0;

            for (int i = 1; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    _output[index, 0] = i;          // número de sílabas
                    _output[index, 1] = counts[i];  // cantidad de palabras
                    index++;
                }
            }
        }

        private int ContarSilabas(string palabra)
        {
            int silabas = 0;
            bool inVowel = false;

            foreach (char c in palabra)
            {
                if (EsVocal(c))
                {
                    if (!inVowel)
                    {
                        silabas++;
                        inVowel = true;
                    }
                }
                else
                {
                    inVowel = false;
                }
            }

            // si no tiene vocales → 1 sílaba
            if (silabas == 0)
            {
                silabas = 1;
            }

            return silabas;
        }

        private bool EsVocal(char c)
        {
            c = char.ToLower(c);

            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y'
                || c == 'а' || c == 'е' || c == 'ё' || c == 'и' || c == 'о'
                || c == 'у' || c == 'ы' || c == 'э' || c == 'ю' || c == 'я';
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < _output.GetLength(0); i++)
            {
                if (i > 0)
                {
                    result += "\n";
                }

                result += _output[i, 0] + ":" + _output[i, 1];
            }

            return result;
        }
    }
}