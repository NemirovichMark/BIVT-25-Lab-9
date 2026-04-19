using System;

namespace White
{
    public class Task4 : White
    {
        public Task4(string text) : base(text)
        {
        }

        protected override object GetDefaultOutput()
        {
            return 0;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                SetOutput(0);
                return;
            }

            int sum = 0;
            foreach (char c in Input)
            {
                if (c >= '0' && c <= '9')
                {
                    sum += c - '0';
                }
            }

            SetOutput(sum);
        }

        public override string ToString()
        {
            Review();
            return ((int)Output).ToString();
        }
    }
}
