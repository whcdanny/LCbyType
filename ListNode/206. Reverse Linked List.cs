//206. Reverse Linked List ez
//反转一个linkedlist
//思路：相当于把箭头指向前一个，这样就先确定next，然后cur和nextswitch
		public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
			//当前的
            ListNode cur = head;
			//下一个
            ListNode next = head.next;
			//由于第一个的下一个为空所以要先定义
            cur.next = null;
			//一个临时的存储next
            ListNode temp = new ListNode(-1); 
            while (next != null)
            {
				//交换
                temp = next.next;
                next.next = cur;
                cur = next;
                next = temp;
            }
            return cur;
        }