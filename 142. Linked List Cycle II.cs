142. Linked List Cycle II
//C#
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        ListNode slow = head, fast = head;
        while (true)
        {
            if (fast == null || fast.next == null || fast.next.next == null)
            {
                return null;
            }
            slow = slow.next;
            fast = fast.next.next;

            if (fast == slow)
            {
                break;
            }
        }

        slow = head;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }
        return slow;
    }
}
public ListNode DetectCycle(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();
            while (true)
            {
                if (head == null || head.next == null)
                    return null;
                if (list.Contains(head))
                    return head;
                list.Add(head);
                head = head.next;
            }
            return null;
		}
		
//Java
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode detectCycle(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;
        
        while(true){
            if(fast==null || fast.next==null||fast.next.next==null){
                return null;
            }
            slow = slow.next;
            fast = fast.next.next;
            
            if(fast == slow){
                break;
            }
        }

        slow = head;
        while(slow!=fast){
            slow = slow.next;
            fast = fast.next;
        }
        return slow;
    }
}