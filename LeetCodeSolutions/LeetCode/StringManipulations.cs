using System.Text;

namespace LeetCodeSolutions
{
    public class StringManipulations
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            foreach (var s in strs)
            {
                var sortedS = SortStr_O_NlogN(s);
                if (!dict.ContainsKey(sortedS))
                    dict.Add(sortedS, new List<string>());
                dict[sortedS].Add(s);
            }
            return dict.Values.ToList();
        }


        // simple string sorting O(nlogn)
        private string SortStr_O_NlogN(string s)
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }


        // efficiate string sorting - Counting Sort O(n)
        private string SortStr_O_N(string s)
        {
            if (s == null || s.Length <= 1) return s;
            var sb = new StringBuilder();
            var letters = new int[Consts.MAX_CHAR];

            foreach (var ch in s.ToCharArray()) letters[ch - 'a']++;
            for (int i = 0; i < Consts.MAX_CHAR; i++)//letters
            {
                while (letters[i] > 0)
                {
                    sb.Append((char)(i + 'a'));
                    letters[i]--;
                }
            }
            return sb.ToString();
        }

        internal void permutation_backtrack(string s, HashSet<char> charSet)
        {
            if (charSet.Count() == s.Length)//reach same count as s, need to print this permutation            
                Console.WriteLine(string.Concat(charSet));            
            else
            {
                foreach (var c in s)//each char in input s opens new function call
                {
                    if (charSet.Contains(c)) continue;//if not already in set
                    charSet.Add(c);//add char
                    permutation_backtrack(s, charSet);//start new functions tree with current chars in set, so far
                    charSet.Remove(c);//remove it, so in next iteration, will start options tree, from next char
                }
            }
        }

    }
}
