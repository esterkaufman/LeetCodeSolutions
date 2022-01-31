namespace LeetCodeSolutions.Models
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public TreeNode GetBinaryTreeFromList(int[] arr, int i = 0, TreeNode root = null)
        {
            if (i < arr.Length && arr[i] != -1)
            {
                root = new TreeNode(arr[i]);
                root.left = GetBinaryTreeFromList(arr, 2 * i + 1, root.left);
                root.right = GetBinaryTreeFromList(arr, 2 * i + 2, root.right);
            }

            return root;
        }
    }

    public class Trie
    {
        public List<int> indices; // index is set only when node is a leaf node;
        public Trie[] child = new Trie[Consts.MAX_CHAR];
    }

}
