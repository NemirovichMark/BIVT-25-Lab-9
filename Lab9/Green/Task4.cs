using System;

namespace Lab9.Green
{
    public class Task4 : Green
    {
        public string[] Output { get; private set; }

        public Task4(string input) : base(input)
        {
            Output = Array.Empty<string>();
        }

        public override void Review()
        {
            var arr = Input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
                arr[i] = arr[i].Trim();

            // Bubble sort (vì cấm dùng sort có sẵn)
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (string.Compare(arr[j], arr[j + 1], StringComparison.Ordinal) > 0)
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Output = arr;
        }

        public override string ToString()
        {
            return string.Join("\n", Output);
        }
    }
}
