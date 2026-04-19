using System;

namespace Lab9
{
    public abstract class White
    {
        private string _sourceText;
        private object? _computedResult;

        public string Input 
        { 
            get { return _sourceText; }
            private set { _sourceText = value; }
        }

        public object? Output 
        { 
            get { return _computedResult; }
            protected set { _computedResult = value; }
        }

        protected White(string text)
        {
            _sourceText = text;
            _computedResult = GetDefaultResult();
        }

        protected virtual object? GetDefaultResult()
        {
            return null;
        }

        public abstract void Review();

        public virtual void ChangeText(string newText)
        {
            _sourceText = newText;
            Review();
        }

        protected void SetResult(object value)
        {
            _computedResult = value;
        }

        public override abstract string ToString();
    }
}
