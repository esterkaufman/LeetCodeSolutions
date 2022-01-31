using LeetCodeSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.LeetCode
{
    internal class TreesManipulations
    {
        //Symmetric Tree
        //https://leetcode.com/problems/symmetric-tree/discuss/1735021/simplest-and-70-time-faster-one-line-solution
        public bool IsSymmetric(TreeNode root)
        {
            return root == null ? true : IsMirror(root, root);
        }

        public bool IsMirror(TreeNode left, TreeNode right)
        {
            return ((left == null && right == null) || (left?.val == right?.val &&
                     IsMirror(left.left, right.right) && IsMirror(left.right, right.left)));
        }
    }
}
