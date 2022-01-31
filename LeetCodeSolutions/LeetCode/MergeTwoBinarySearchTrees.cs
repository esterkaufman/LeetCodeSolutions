using LeetCodeSolutions.Models;

namespace LeetCodeSolutions
{
    internal class MergeTwoBinarySearchTrees
    {
        //https://leetcode.com/problems/all-elements-in-two-binary-search-trees/
        public readonly List<int> list = new();

        public IList<int> GetAllElements2(TreeNode root1, TreeNode root2)
        {
            if (root1 != null || root2 != null)
            {
                if (root1?.left != null || root2?.left != null)
                    GetAllElements2(root1?.left ?? root1, root2?.left ?? root2);

                if (root1?.val > root2?.val)
                {
                    list.Add(root2.val);
                    list.Add(root1.val);
                }
                else
                {
                    if (root1 != null) list.Add(root1.val);
                    if (root2 != null) list.Add(root2.val);
                }

                GetAllElements2(root1?.right, root2?.right);
            }

            return list;
        }

        //TC O(n) + O(m) + O(n) + O(m) = O(n+m) 
        //SC O(n) + O(m) + O(n+m) = O(n+m)
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            return Merge(AddTreeToList(root1, new List<int>()), AddTreeToList(root2, new List<int>()));
        }

        public IList<int> AddTreeToList(TreeNode root, List<int> list)
        {
            if (root != null)
            {
                AddTreeToList(root.left, list);
                list.Add(root.val);
                AddTreeToList(root.right, list);
            }

            return list;
        }

        public IList<int> Merge(IList<int> a, IList<int> b)
        {
            var res = new List<int>();
            int ai = 0, bi = 0;

            while (ai < a.Count && bi < b.Count) res.Add(a[ai] < b[bi] ? a[ai++] : b[bi++]);
            while (ai < a.Count) res.Add(a[ai++]);
            while (bi < b.Count) res.Add(b[bi++]);
            return res;
        }
    }
}
