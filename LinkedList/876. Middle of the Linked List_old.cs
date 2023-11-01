//876. Middle of the Linked List ez
//思路：用快慢针，slow走一步，fast走两步，说白了就是nx2=长度；		
		public ListNode MiddleNode(ListNode head)
        {
            //ListNode res = new ListNode(-1);
            //int count = 0;
            //while(head.next != null)
            //{
            //    count++;//count = count+1;
            //}
            //int middle = count / 2 + 1; ;
            //while (middle != 0)
            //{
            //    res.next = head;//1 2 3
            //    head = head.next;
            //    middle--;
            //}
            //return res;
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