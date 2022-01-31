using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    public class StringManipulations
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            foreach(var s in strs){
                var sortedS = SortStr_O_NlogN(s);
                if (!dict.ContainsKey(sortedS))                
                    dict.Add(sortedS, new List<string>());                
                dict[sortedS].Add(s);
            }
            return dict.Values.ToList();
        }

        private string SortStr_O_NlogN(string s)
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        const int MAX_CHAR = 26;
        private string SortStr_O_N(string s)
        {
            if (s == null || s.Length <= 1) return s;
            var sb = new StringBuilder();
            var letters = new int[MAX_CHAR];

            foreach (var ch in s.ToCharArray()) letters[ch - 'a']++;
            for (int i = 0; i < MAX_CHAR; i++)//letters
            {
                while (letters[i] > 0)
                {
                    sb.Append((char)(i + 'a'));
                    letters[i]--;
                }
            }
            return sb.ToString();
        }
    }
}
