//Leetcode 141. Linked List Cycle ez
//题意：要求判断给定的链表是否存在环
//思路：快慢指针：使用两个指针，一个慢指针（slow）和一个快指针（fast）。
//时间复杂度：O(n)，其中n是链表的长度。
//空间复杂度：O(1)，因为只使用了两个指针
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }