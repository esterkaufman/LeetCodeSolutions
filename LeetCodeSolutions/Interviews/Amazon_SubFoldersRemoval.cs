using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.Interviews
{
    //https://leetcode.com/problems/remove-sub-folders-from-the-filesystem/discuss/1796787/faster-than-97-c-easy-well-designed-solution
    internal class Amazon_SubFoldersRemoval
    {
		public IList<string> RemoveSubfolders(string[] folder)
		{
			var vec = new HashSet<string>(folder);

			foreach (var f in folder)
			{
				var curr = GetCurrSubFolder(f, 0);

				while (curr != f)
				{
					if (vec.Contains(curr))
					{
						vec.Remove(f);
						break;
					}
					curr = GetCurrSubFolder(f, curr.Length);
				}
			}
			return vec.ToList();
		}

		public string GetCurrSubFolder(string src, int lastSlashIndex)
		{
			var nextSlash = src.IndexOf("/", lastSlashIndex + 1);
			return nextSlash != -1 ? src.Substring(0, nextSlash) : src;
		}
	}
}
