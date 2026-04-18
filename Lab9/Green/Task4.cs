using System;


namespace Lab9.Green
{
    public class Task4 : Green
    {
        private string[] _output = new string[100];
        public string[] Output => _output; 
        public Task4(string text) : base(text)
        {
            
        }

        protected string[] Resenie()
        {
            char[] simbols = new char[]
            {
        ' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '\t',
        '-', '—', '(', ')', '[', ']', '{', '}', '"', '\''
            };

            string[] Familii = Input.Split(simbols, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < Familii.Length; i++)
            {
                for (int j = 0; j < Familii.Length - i-1; j++)
                {
                    string schas = Familii[j];
                    string potom = Familii[j + 1];

                    bool swap = false;
                    bool equal = true;

                    int Len_Min = Math.Min(schas.Length, potom.Length);

                    for (int k = 0; k < Len_Min; k++)
                    {
                        char schas_1 = char.ToLower(schas[k]);
                        char potom_1 = char.ToLower(potom[k]);

                        if (schas_1 > potom_1)
                        {
                            swap = true;
                            equal = false;
                            break;
                        }
                        else if (schas_1 < potom_1)
                        {
                            equal = false;
                            break;
                        }
                    }

                    // только если полностью совпали
                    if (equal && schas.Length > potom.Length)
                    {
                        swap = true;
                    }

                    if (swap)
                    {
                        string temp = Familii[j];
                        Familii[j] = Familii[j + 1];
                        Familii[j + 1] = temp;
                    }

                }
            }


            return Familii;
        }

        public override void Review()
        {
            _output = Resenie();
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return "";

            string result = _output[0];

            for (int i = 1; i < _output.Length; i++)
            {
                result += "\r\n" + _output[i];
            }

            return result;
        }
    }
}


//namespace Lab9.Green
//{
//    public class Task4 : Green
//    {
//        private string[] _output = Array.Empty<string>();

//        public string[] Output => _output;

//        public Task4(string text) : base(text)
//        {
//            Review();
//        }

//        public override void Review()
//        {
//            _output = SortSurnames();
//        }

//        private string[] SortSurnames()
//        {
//            if (string.IsNullOrEmpty(Input))
//            {
//                return Array.Empty<string>();
//            }

//            // Разделение на фамилии
//            string[] surnames = SplitIntoSurnames();

//            // Ручная сортировка пузырьком
//            BubbleSort(surnames);

//            return surnames;
//        }

//        private string[] SplitIntoSurnames()
//        {
//            string[] surnames = Input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

//            // Удаление лишних пробелов
//            for (int i = 0; i < surnames.Length; i++)
//            {
//                surnames[i] = surnames[i].Trim();
//            }

//            return surnames;
//        }

//        private void BubbleSort(string[] array)
//        {
//            for (int i = 0; i < array.Length - 1; i++)
//            {
//                for (int j = 0; j < array.Length - i - 1; j++)
//                {
//                    if (CompareStrings(array[j], array[j + 1]) > 0)
//                    {
//                        // Обмен элементов
//                        string temp = array[j];
//                        array[j] = array[j + 1];
//                        array[j + 1] = temp;
//                    }
//                }
//            }
//        }

//        // Ручное сравнение строк по алфавиту без использования библиотечных методов
//        private int CompareStrings(string str1, string str2)
//        {
//            if (str1 == null && str2 == null) return 0;
//            if (str1 == null) return -1;
//            if (str2 == null) return 1;

//            int minLength = Math.Min(str1.Length, str2.Length);

//            for (int i = 0; i < minLength; i++)
//            {
//                if (str1[i] != str2[i])
//                {
//                    return str1[i] - str2[i];
//                }
//            }

//            return str1.Length - str2.Length;
//        }

//        public override string ToString()
//        {
//            return string.Join(Environment.NewLine, _output);
//        }
//    }
//}