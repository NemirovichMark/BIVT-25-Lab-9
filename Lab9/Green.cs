using System;

namespace Lab9.Green
{
    public abstract class Green
    {
        private string _input;

        // 公共只读属性，返回传入的文本
        public string Input
        {
            get => _input;
            private set => _input = value ?? throw new ArgumentNullException(nameof(value));
        }

        // 受保护的构造函数，接收字符串并初始化，随后调用 Review
        protected Green(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            _input = text;
            Review();
        }

        // 抽象方法，处理文本逻辑，必须在派生类中实现
        public abstract void Review();

        // 虚方法，允许更改文本并自动重新处理
        public virtual void ChangeText(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            _input = text;
            Review();
        }

        // 抽象方法，返回格式化后的结果字符串，必须在派生类中实现
        public abstract override string ToString();
    }
}