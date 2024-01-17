//Leetcode 1721. Swapping Nodes in a Linked List med
//题意：给定一个链表的头结点 head 和一个整数 k，交换链表中从开头数第 k 个结点和从末尾数第 k 个结点的值（链表的索引从1开始）。
//思路：双指针使用一个指针 fast 向前移动 k 步，然后使用两个指针 slow 和 fast 同时向前移动，直到 fast 指针到达链表的末尾
//注：开头是k距离，从尾倒数的是总长度-k，那么先走k步之和 第一个得到，然后slow从头开始fast从k开始 fast走了总长度-k步，此时slow停在了倒数第k个
//时间复杂度：O(n)
//空间复杂度：O(1)
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode slow = head, fast = head;

            // Move fast pointer to the kth node
            for (int i = 1; i < k; i++)
            {
                fast = fast.next;
            }

            ListNode first = fast;  // Save the kth node from the beginning

            // Move slow and fast pointers together until fast reaches the end
            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            ListNode second = slow;  // Save the kth node from the end

            // Swap the values of the kth nodes
            int temp = first.val;
            first.val = second.val;
            second.val = temp;

            return head;
        }