//92. Reverse Linked List II med
//反转指定两个位置之间的链表
//思路： 与206 一样 只不过这次给的left和right的位置的下一个要思考一下
//第二个的方法是第一个的优化 暂时没看懂
		public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null)
                return null;
            ListNode res = new ListNode(-1);
            res.next = head;
            ListNode preNode = res;
            int count = 1;
            while(res.next!=null && count < left)
            {
                preNode = preNode.next;
                count++;
            }
            if (count < left)
                return head;
            ListNode start = preNode.next;
            ListNode cur = preNode.next;
            ListNode next = cur.next;
            ListNode temp = new ListNode(-1);
            while (cur != null && count < right)
            {
                temp = next.next;
                next.next = cur;
                cur = next;
                next = temp;
                count++;
            }
            preNode.next = cur;
            start.next = next;            
            return res.next;
        }
		
		public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (head == null)
                return null;
            ListNode res = new ListNode(-1);
            res.next = head;
            ListNode preNode = res;
            int count = 1;
            while(res.next!=null && count < left)
            {
                preNode = preNode.next;
                count++;
            }
            if (count < left)
                return head;            
            ListNode mNode = preNode.next;
            ListNode cur = mNode.next;
            ListNode temp = new ListNode(-1);
            while (cur != null && count < right)
            {
                temp = cur.next;
                cur.next = preNode.next;
                preNode.next = cur;
                mNode.next = temp;
                cur = temp;
                count++;
            }
            return res.next;
        }