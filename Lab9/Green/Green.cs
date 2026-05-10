// namespace Lab9.Green
// {
//     public abstract class Green
//     {
//         private string _input;
//         public string Input => _input;
        
//         protected  Green(string text)
//         {
//             _input = text;
//         }

//         public abstract void Review();
//         public virtual void ChangeText(string text)
//         {
//             _input = text;
//             Review();
//         }
//     }
    
//     public class Task1 : Green
//     {
//         private (char, double)[] _output;
//         public (char, double)[] Output => _output;

//         public Task1(string text) : base(text) {}

//         public override void Review()
//         {
//             if (string.IsNullOrEmpty(Input)) return;
//             string text = Input.ToLower();
//             int totalLetters = 0;
//             Dictionary<char, int> counts = new Dictionary<char, int>();

//             foreach (char c in text)
//             {
//                 if (c >= 'а' && c <= 'я') //проверяем руссакя буква или нет
//                 {
//                     if (counts.ContainsKey(c))
//                     {
//                         counts[c]++;
//                     }
//                     else
//                     {
//                         counts[c] = 1;
//                     }
//                     totalLetters++;
//                 }
//             }
//             var result = new List<(char, double)>();
//             foreach (var kvp in counts)
//             {
//                 result.Add((kvp.Key, (double)kvp.Value / totalLetters));
//             }

//             _output = result.OrderBy(x => x.Item1).ToArray();
//         }

//         public override string ToString()
//         {
//             if (_output == null) return "";
//             List<string> lines = new List<string>();
//             foreach (var item in _output)
//             {
//                 lines.Add($"{item.Item1} {item.Item2:F4}");
//             }
//             return string.Join(Environment.NewLine, lines);
//         }
//     }

//     public class Task2 : Green
//     {
//         private char[] _output;
//         public char[] Output => _output;

//         public Task2(string text) : base(text)
//         {
//         }

//         public override void Review()
//         {
//             if (string.IsNullOrEmpty(Input)) return;
//             string[] words = Input.ToLower()
//                 .Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
//             Dictionary<char, int> counts = new Dictionary<char, int>();
//             foreach (string word in words)
//             {
//                 char first = word[0];
//                 if (first >= 'а' && first <= 'я')
//                 {
//                     if (!counts.ContainsKey(first)) counts[first]++;
//                 }
//                 else
//                 {
//                     counts[first] = 1;
//                 }
//             }

//             //по убыванию частоты => по алфавиту
//             _output = counts.OrderByDescending(x => x.Value)
//                 .ThenBy(x => x.Key)
//                 .Select(x => x.Key)
//                 .ToArray();
//         }

//         public override string ToString()
//         {
//             return _output != null ? string.Join(",", _output) : "";
//         }
//     }
//     public class Task3 : Green
//     {
//         private string _subString;
//         private string[] _output;
//         public string[] Output => _output;

//         public Task3(string text, string subString) : base(text)
//         {
//             _subString = subString.ToLower();
//         }

//         public override void Review()
//         {
//             if (string.IsNullOrEmpty(Input)) return;
//             string[] words = Input.Split(new char[] {' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
//             List<string> result = new List<string>();
//             HashSet<string> seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

//             foreach (string word in words)
//             {
//                 if (word.ToLower().Contains(_subString))
//                 {
//                     if (!seen.Contains(word))
//                     {
//                         result.Add(word);
//                         seen.Add(word);
//                     }
//                 }
//             }

//             _output = result.ToArray();
//         }

//         public override string ToString()
//         {
//             return _output != null ? string.Join(Environment.NewLine, _output) : "";
//         }
//     }
    
//     public class Task4 : Green
//     {
//         private string[] _output;
//         public string[] Output => _output;
        
//         public Task4(string text) : base(text) {}

//         public override void Review()
//         {
//             if (string.IsNullOrEmpty(Input)) return;
//             string[] names = Input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
//             for (int i = 0; i < names.Length; i++)
//             {
//                 names[i] = names[i].Trim();
//             }

//             for (int i = 0; i < names.Length - 1; i++)
//             {
//                 for (int j = 0; j < names.Length - 1; j++)
//                 {
//                     if (string.Compare(names[j], names[j + 1], StringComparison.Ordinal) > 0)
//                     {
//                         string temp = names[j];
//                         names[j] = names[j + 1];
//                         names[j + 1] = temp;
//                     }
//                 }
//             }
//             _output = names;
//         }

//         public override string ToString()
//         {
//             return _output != null ? string.Join(Environment.NewLine, _output) : "";
//         }
//     }
// }

