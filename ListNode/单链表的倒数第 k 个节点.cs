//单链表的倒数第 k 个节点
//思路：指针p1先走k步，然后p1只要走n-k步就到末尾，那么这个时候再加一个p2从头开始；
//然后p1和p2一起走，直到p1走完，这时候p2停留在n-k+1；
//无论遍历一次链表和遍历两次链表的时间复杂度都是 O(N)
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