//Leetcode 142. Linked List Cycle II med
//题意：要求找到链表中环的起始节点
//思路：可以使用快慢指针的方法解决这个问题。如果链表存在环，快指针最终会追上慢指针。重新将一个指针指向链表的头节点，然后两个指针以相同的速度前进，当它们相遇时，就是环的起始节点。
//时间复杂度：O(n)，其中n是链表的长度。
//空间复杂度：O(1)，因为只使用了两个指针
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            bool hasCycle = false;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (!hasCycle)
            {
                return null;
            }

            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;
        }