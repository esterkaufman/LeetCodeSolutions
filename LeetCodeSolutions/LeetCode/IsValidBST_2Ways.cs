using LeetCodeSolutions.Models;

namespace LeetCodeSolutions
{
    public class IsValidBST_2Ways
    {
        //https://leetcode.com/problems/validate-binary-search-tree/discuss/1731203/faster-than-96-c-solution-2-ways-one-line
        public bool IsValidBST_OneLine(TreeNode root, long max = long.MaxValue, long min = long.MinValue)
        {
            return root == null || ((root.val > min && root.val < max) &&
            IsValidBST_OneLine(root.left, root.val, min) &&
            IsValidBST_OneLine(root.right, max, root.val));
        }

        public bool IsValidBST_ComparePrev(TreeNode root)
        {
            return IsValidBST_ComparePrev(root, new PrevVal(long.MinValue));
        }

        private bool IsValidBST_ComparePrev(TreeNode root, PrevVal prev)
        {
            if (root == null) return true;
            if (!IsValidBST_ComparePrev(root.left, prev) || prev.val >= root.val) return false;
            prev.val = root.val;
            return IsValidBST_ComparePrev(root.right, prev);
        }

        public class PrevVal
        {
            public long val; public PrevVal(long val) { this.val = val; }
        }
        public bool IsValidBST_IsListSorted(TreeNode root)
        {
            var list = BST_InOrderAddToList(root, new List<int>());
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] <= list[i - 1]) return false;
            }
            return true;
        }

        private List<int> BST_InOrderAddToList(TreeNode root, List<int> list)
        {
            if (root != null)
            {
                BST_InOrderAddToList(root.left, list);
                list.Add(root.val);
                BST_InOrderAddToList(root.right, list);
            }
            return list;
        }
    }
}
