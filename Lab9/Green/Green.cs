using System;

namespace Green
{
    public abstract class Green
    {
        protected string Input { get; private set; }

        protected Green(string input)
        {
            Input = input;
        }

        public abstract void Review();

        public virtual void ChangeText(string text)
        {
            Input = text;
            Review();
        }
    }
}
