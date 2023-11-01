//Leetcode 876. Middle of the Linked List ez
//题意：要求找到给定链表的中间节点。
//思路：快慢指针：使用两个指针，一个慢指针（slow）和一个快指针（fast）。
//时间复杂度：O(n)，其中n是链表的长度。
//空间复杂度：O(1)，因为只使用了两个指针
        public ListNode MiddleNode(ListNode head) {
        // 快慢指针初始化指向 head
            ListNode slow = head, fast = head;
            // 快指针走到末尾时停止
            while (fast != null && fast.next != null)
            {
                // 慢指针走一步，快指针走两步
                slow = slow.next;
                fast = fast.next.next;
            }
            // 慢指针指向中点
            return slow;
    }