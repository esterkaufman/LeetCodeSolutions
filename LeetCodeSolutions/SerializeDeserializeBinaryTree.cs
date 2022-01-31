using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    public class SerializeDeserializeBinaryTree
    {
        public TreeNode Run(TreeNode root)
        {
            return new Codec().deserialize(new Codec().serialize(root));
        }
        public TreeNode Run1(TreeNode root)
        {
            return new Codec1().deserialize(new Codec1().serialize(root));
        }
        public TreeNode Run2(TreeNode root)
        {
            return new Codec2().deserialize(new Codec2().serialize(root));
        }

    }
    public class Codec
    {
        public string serialize(TreeNode root)
        {
            return root == null ? "n" : $"{root.val},{serialize(root.left)},{serialize(root.right)}";
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            return string.IsNullOrEmpty(data) ? null : InOrderListBuildTree(Split(data, ','), new IndexHelper());
        }

        private TreeNode InOrderListBuildTree(string[] nums, IndexHelper index)
        {
            if (nums[index.i] == "n") return null;
            return new TreeNode(int.Parse(nums[index.i]))
            {
                left = InOrderListBuildTree(nums, index.Increase()),
                right = InOrderListBuildTree(nums, index.Increase())
            };
        }
        class IndexHelper { public int i = 0; public IndexHelper Increase() { i++; return this; } }

        private string[] Split(string s, char sep)
        {
            var items = new List<string>();

            for (int i = 0, end; i < s.Length && ((end = s.IndexOf(',', i)) != -1 || (end = s.Length) >= 0); i = end + 1)
            {
                items.Add(s.Substring(i, end - i));
            }
            return items.ToArray();
        }

    }
    public class Codec1
    {
        
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "";

            var sb = new StringBuilder();

            sb.Append($"{root.val},"); // add root val
            AppendNodeChildsVals(root, sb);// for each root, add left and right values
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;

            var list = new List<int?>();

            for (int i = 0; i < data.Length;)
            {
                var numStr = "";

                while (data[i] != ',') numStr += data[i++];
                i++;// Skip the comma ',' in next loop
                list.Add(numStr == "n" ? null : int.Parse(numStr));
            }
            return buildTreeByIncreasedIndex(list);
        }

        private void AppendNodeChildsVals(TreeNode root, StringBuilder sb)
        {
            sb.Append($"{(root.left == null ? "n" : root.left.val)},");
            sb.Append($"{(root.right == null ? "n" : root.right.val)},");
            if (root.left != null) AppendNodeChildsVals(root.left, sb);
            if (root.right != null) AppendNodeChildsVals(root.right, sb);

        }

        public TreeNode buildTreeByIncreasedIndex(List<int?> list)
        {
            TrimNullsFromEnd(list);
            if (list == null || list.Count == 0 || list[0] == null) return null;

            var listIndex = 1;
            var q = new Queue<(TreeNode node, int i)>();
            var root = new TreeNode(list[0].Value);

            q.Enqueue((root, 0));
            TrimNullsFromEnd(list);
            while (q.Any() && listIndex < list.Count)
            {
                var item = q.Dequeue();
                var leftI = item.i * 2 + 1;
                var rightI = item.i * 2 + 2;

                if (leftI >= list.Count)
                {
                    leftI = listIndex;
                    rightI = listIndex + 1;
                }
                listIndex += 2;
                item.node.left = list[leftI].HasValue ? new TreeNode(list[leftI].Value) : null;
                item.node.right = rightI < list.Count && list[rightI].HasValue ? new TreeNode(list[rightI].Value) : null;
                if (item.node.left != null) q.Enqueue((item.node.left, leftI));
                if (item.node.right != null) q.Enqueue((item.node.right, rightI));
            }

            return root;
        }
        private void TrimNullsFromEnd(List<int?> list)
        {
            while (list != null && !list[list.Count - 1].HasValue) list.RemoveAt(list.Count - 1);
        }
    }

    public class Codec2
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "";

            var sb = new StringBuilder();
            var q = new Queue<(TreeNode node, int expectedIdx)>();
            int i = 0;
            q.Enqueue((root, 0));

            while (q.Any())
            {
                var item = q.Dequeue();

                while (i < item.expectedIdx)
                {
                    sb.Append("n,");
                    i++;
                }
                sb.Append($"{item.node.val},");
                i++;
                if (item.node.left != null) q.Enqueue((item.node.left, item.expectedIdx * 2 + 1));
                if (item.node.right != null) q.Enqueue((item.node.right, item.expectedIdx * 2 + 2));
            }
            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == "[]" || data.Length <= 2) return null;

            var list = new List<int?>();

            for (int i = 1; i < data.Length - 1;)
            {
                var numStr = "";

                while (data[i] != ',') numStr += data[i++];
                i++;// Skip the comma ',' in next loop
                list.Add(numStr == "n" ? null : int.Parse(numStr));
            }
            return buildTree(list);
        }
        public TreeNode buildTree(List<int?> list, int i = 0)
        {
            TreeNode node = null;

            if (i < list.Count)
            {
                if (list.ElementAt(i).HasValue)
                {
                    node = new TreeNode(list[i].Value)
                    {
                        left = buildTree(list, i * 2 + 1),
                        right = buildTree(list, i * 2 + 2)
                    };
                }
            }
            return node;
        }

    }



    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
