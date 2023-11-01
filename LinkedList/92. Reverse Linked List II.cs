//Leetcode 92. Reverse Linked List II med
//题意：要求将链表中从位置 m 到 n 的节点反转
//思路：迭代的方法解决, 逻辑是反转前的node为pre这个是不变的，变的是pre.next；然后反转一开始的位置相对应的cur也不变，因为我们要一直把他挪到n位置，这里唯一一直在变的就是next，因为我们需要把m到n之间的数倒转，这样他们的next.next就一直在一个位置一个位置的根据迭代在改变；
//时间复杂度：O(n)，其中n是链表的长度。
//空间复杂度：O(1)，因为只使用了两个指针
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null || left >= right)
            {
                return head;
            }

            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode prev = dummy;

            for (int i = 1; i < left; i++)
            {
                prev = prev.next;
            }

            ListNode current = prev.next;
            ListNode next = current.next;

            for (int i = 0; i < right - left; i++)
            {
                current.next = next.next;
                next.next = prev.next;
                prev.next = next;
                next = current.next;
            }

            return dummy.next;

        }