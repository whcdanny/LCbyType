//19. Remove Nth Node From End of List med
//思路：类似于单链表的倒数第 k 个节点，找到倒数第k的前一位，然后让这个位置的next为删除的next，
//所以就是x.next = x.next.next;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
     public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //虚拟头结点，避免处理空指针
            ListNode res = new ListNode(-1);
            res.next = head;
            //删除倒数第 n 个，要先找倒数第 n + 1 个节点，也就是被删除的前一个
            ListNode x = findFromEnd(res, n + 1);
            x.next = x.next.next;
            return res.next;
        }
        public ListNode findFromEnd(ListNode head, int k)
        {
            ListNode p1 = head;
            // p1 先走 k 步
            for (int i = 0; i < k; i++)
            {
                p1 = p1.next;
            }
            ListNode p2 = head;
            // p1 和 p2 同时走 n - k 步
            while (p1 != null)
            {
                p2 = p2.next;
                p1 = p1.next;
            }
            // p2 现在指向第 n - k + 1 个节点，即倒数第 k 个节点
            return p2;
        }
}