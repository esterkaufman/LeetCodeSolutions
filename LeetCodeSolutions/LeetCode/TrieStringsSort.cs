using LeetCodeSolutions.Models;


namespace LeetCodeSolutions
{
    public class TrieStringsSort
    {
       
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			var res = new List<IList<string>>();
			var emptyStrs = new List<string>();
			Trie root = new Trie();

			if (strs == null) return res;
			if (strs.Length == 1)
			{
				res.Add(strs);
				return res;
			}
			for (int i = 0; i < strs.Length; ++i)
			{
				if (string.IsNullOrEmpty(strs[i])) emptyStrs.Add(strs[i]);
				else Insert(root, strs[i], i);
			}
			if (emptyStrs.Any()) res.Add(emptyStrs);
			return PreOrderGetGroups(root, strs, res);
		}

		public void Insert(Trie root, string s, int idx)
		{
			Trie node = root;
			var letters = new int[26];

			foreach (var ch in s.ToCharArray()) letters[ch - 'a']++;
			for (int i = 0; i < letters.Length; i++)
			{
				while (letters[i] > 0)
				{
					if (node.child[i] == null) node.child[i] = new Trie();
					node = node.child[i];
					letters[i]--;
				}
			}
			if (node.indices == null) node.indices = new List<int>();
			node.indices.Add(idx);// Mark leaf (end of word),store word original array index
		}
		public IList<IList<string>> PreOrderGetGroups(Trie node, string[] strs, IList<IList<string>> grps)
		{
			if (node != null)
			{
				for (int i = 0; i < Consts.MAX_CHAR; i++)
				{
					if (node.child[i] != null)
					{
						if (node.child[i].indices != null)//if leaf or end of word, take indices
						{
							var grp = new List<string>();
							foreach (var index in node.child[i].indices)
								grp.Add(strs[index]);
							grps.Add(grp);
						}
						PreOrderGetGroups(node.child[i], strs, grps);
					}
				}
			}
			return grps;
		}

		public void Run()
        {
            var res = GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            //var res = GroupAnagrams(new[] { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" });
            foreach (var group in res) Console.WriteLine("[" + string.Join(",", group) + "]");
        }
    }
}
