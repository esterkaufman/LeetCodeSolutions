using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    internal class MergeKSortedLinkedLists
    {
        //https://leetcode.com/problems/merge-k-sorted-lists/discuss/1732210/simple-while-merging-better-then-60-in-time-and-space
        public ListNode MergeKLists(ListNode[] lists)
        {
            return lists == null ? null : MergeSort(lists, 0, lists.Length - 1);
        }

        public ListNode MergeSort(ListNode[] lists, int left, int right)
        {
            if (left == right) return lists[left];
            if (left > right) return null;

            var mid = left + (right - left) / 2;
            var leftList = MergeSort(lists, left, mid);
            var rightList = MergeSort(lists, mid + 1, right);

            return Merge(leftList, rightList);
        }

        public ListNode Merge(ListNode leftList, ListNode rightList)
        {
            ListNode prev = null;
            var start = rightList == null || (leftList != null && leftList.val < rightList.val) ? leftList : rightList;

            while (leftList != null && rightList != null)
            {
                if (leftList.val < rightList.val)
                {
                    if (prev != null) prev.next = leftList;
                    prev = leftList;
                    leftList = leftList.next;
                }
                else
                {
                    if (prev != null) prev.next = rightList;
                    prev = rightList;
                    rightList = rightList.next;
                }
            }
            if (prev != null) prev.next = leftList != null ? leftList : rightList;
            return start;
        }

        public ListNode Merge_Recur(ListNode left, ListNode right)
        {
            if (left == null) return right;
            if (right == null) return left;

            if (left.val < right.val)
            {
                left.next = Merge_Recur(left.next, right);
                return left;
            }
            else
            {
                right.next = Merge_Recur(left, right.next);
                return right;
            }
        }


    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
