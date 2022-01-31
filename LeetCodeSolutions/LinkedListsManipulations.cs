using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    internal class LinkedListsManipulations
    {
        //https://leetcode.com/problems/rotate-list/discuss/1732571/very-simple-with-comments-93-faster-roll-down-to-last-and-start-rotate
        int total = 0;
        public ListNode RotateRight(ListNode head, int k)
        {
            return head?.next == null || k == 0 ? head : Rotate(head, head, k, 0);
        }
        public ListNode Rotate(ListNode head, ListNode current, int k, int i)
        {
            if (current.next != null) head = Rotate(head, current.next, k, i + 1);
            else
            {
                total = i+1;//reach last element, save the count
                if (k % total > 0) current.next = head;//last point at head now
            }            
            if (k % total > 0)
            {
                if (total - k % total == i) head = current;// this find the new root
                if (total - k % total - 1 == i) current.next = null;//this find prev of new root, mark end of nodes
            }
            return head;
        }
    }
}
