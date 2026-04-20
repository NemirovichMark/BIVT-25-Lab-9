using System;

namespace Lab9.Green
{
    public class Task4 : Green
    {
        private string[] _output;

        public string[] Output
        {
            get => _output ?? Array.Empty<string>();
            private set => _output = value;
        }

        public Task4(string text) : base(text) { }

        /// <summary>
        /// 手动比较两个字符串，按字符顺序比较
        /// </summary>
        private int CompareStrings(string s1, string s2)
        {
            if (s1 == null && s2 == null) return 0;
            if (s1 == null) return -1;
            if (s2 == null) return 1;

            int minLength = Math.Min(s1.Length, s2.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] < s2[i]) return -1;
                if (s1[i] > s2[i]) return 1;
            }

            // 如果前缀相同，较短的字符串排在前面
            if (s1.Length < s2.Length) return -1;
            if (s1.Length > s2.Length) return 1;
            return 0;
        }

        /// <summary>
        /// 冒泡排序（不使用库排序方法）
        /// </summary>
        private void BubbleSort(string[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (CompareStrings(array[j], array[j + 1]) > 0)
                    {
                        // 交换
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                Output = Array.Empty<string>();
                return;
            }

            // 按逗号分割，去除每个姓氏的前后空格，过滤空字符串
            string[] surnames = Input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < surnames.Length; i++)
            {
                surnames[i] = surnames[i].Trim();
            }

            // 过滤掉纯空格的字符串
            int count = 0;
            for (int i = 0; i < surnames.Length; i++)
            {
                if (!string.IsNullOrEmpty(surnames[i]))
                {
                    count++;
                }
            }

            string[] cleaned = new string[count];
            int index = 0;
            for (int i = 0; i < surnames.Length; i++)
            {
                if (!string.IsNullOrEmpty(surnames[i]))
                {
                    cleaned[index++] = surnames[i];
                }
            }

            // 使用手动实现的排序
            BubbleSort(cleaned);

            Output = cleaned;
        }

        public override string ToString()
        {
            if (Output == null || Output.Length == 0)
            {
                return string.Empty;
            }

            return string.Join(Environment.NewLine, Output);
        }
    }
}