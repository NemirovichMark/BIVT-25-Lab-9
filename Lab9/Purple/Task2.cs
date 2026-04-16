using Lab9.Purple;
using System;


namespace Lab9.Purple
{
    public class Task2 : Purple
    {
        public string[] Output { get; private set; }
        public Task2(string text) : base(text)
        {
            
        }
        public override void Review()
        {
            string[] result = new string[0];
            string[] elements = new string[0];
            ElementsOfText(ref elements, _text);
            int i = 0, j = 0;
            string temp = "";
            string newTemp = "";
            while (i < elements.Length - 1)
            {
                newTemp = temp + elements[i + 1];
                if(newTemp.Length > 50)
                {
                    Array.Resize(ref result, result.Length + 1);
                    RemoveSpaces(ref temp);
                    result[j++] = temp;
                    temp = "";
                }
                temp += elements[i++];
            }
            temp += elements[i++];
            Array.Resize(ref result, result.Length + 1);
            RemoveSpaces(ref temp);
            result[j++] = temp;
            for (int x = 0; x < result.Length; x++)
                result[x] = ExpandSpaces(result[x], 50);
            Output = result;
        }
        private void RemoveSpaces(ref string temp)
        {
            for (int x = 0; x < temp.Length; x++)
                if (temp[x] == ' ')
                    temp = temp[(x + 1)..];
                else
                    break;
        }
        public string ExpandSpaces(string text, int targetLength)
        {
            int spacesToAdd = targetLength - text.Length;
            int spaceCount = 0;
            foreach (char c in text)
            {
                if (c == ' ')
                    spaceCount++;
            }

            if (spaceCount == 0)
                return text.PadRight(targetLength);

            int[] spaceIndexes = new int[spaceCount];
            int idx = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    spaceIndexes[idx++] = i;
            }

            char[] result = new char[targetLength];
            text.AsSpan().CopyTo(result);

            int currentLength = text.Length;
            int spaceIndex = 0;

            while (spacesToAdd > 0)
            {
                int insertPos = spaceIndexes[spaceIndex] + 1;

                result.AsSpan(insertPos, currentLength - insertPos)
                      .CopyTo(result.AsSpan(insertPos + 1));

                result[insertPos] = ' ';

                currentLength++;

                for (int i = spaceIndex; i < spaceIndexes.Length; i++)
                {
                    spaceIndexes[i]++;
                }

                spacesToAdd--;
                spaceIndex++;

                if (spaceIndex >= spaceIndexes.Length)
                    spaceIndex = 0;
            }

            return new string(result);
        }

        private void ElementsOfText(ref string[] elements, string text)
        {
            //Ну в тексте же могут быть подряд спайсы(Spaceы) и таблетосы(Tabы)
            int i = 0;
            string temp = "";
            bool isSpace = text[0] == ' ';

            foreach(char el in text)
            {
                bool currentIsSpace = el == ' ';
                if (currentIsSpace == isSpace)
                    temp += el;
                else
                {
                    Array.Resize(ref elements, elements.Length + 1);
                    elements[i++] = temp;
                    temp = el.ToString();
                }
                isSpace = currentIsSpace;
            }
            Array.Resize(ref elements, elements.Length + 1);
            elements[i++] = temp;
        }
        public override string ToString()
        {                
            return string.Join(Environment.NewLine, Output);
        }
    }
}
