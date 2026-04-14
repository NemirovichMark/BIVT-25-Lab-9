
namespace Lab9.Purple
{
    public class Task3 : Purple
    {
        public (string, char)[] Codes;
        public Task3(string text) : base(text)
        {
            FindRepeatable(_text, 5);
        }
        public override void Review()
        {
            
        }
        private string[] FindRepeatable(string text, int n)
        {
            string[] result = new string[n];
            //Знаками препинания считать: '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/'.
            char[] signs = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', ' ' };
            string format = text;
            foreach (char el in signs)
                format = format.Replace(el.ToString(), "");


            Dictionary<string, int> counts = new Dictionary<string, int>();

            for(int i = 0; i < format.Length - 1; i++)
            {
                string key = format[i..(i + 2)];
                if (counts.ContainsKey(key))
                    counts[key]++;
                else
                    counts[key] = 1;
            }
            string[] topN = counts.OrderBy(x => x.Value).Take(n).Select(x => x.Key).ToArray();

            return topN;
        }
    }
}
