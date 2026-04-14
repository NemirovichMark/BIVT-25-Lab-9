using Lab9.Purple;

namespace Lab9.Purple
{
    public class Task2 : Purple
    {
        public string[] Output;
        public Task2(string text) : base(text)
        {
            Review();
        }
        public override void Review()
        {
            string[] result = new string[0];
            
        }
        public override string ToString()
        {
            return _text;
        }
    }
}
