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
		
	//206. Reverse Linked List
        //反转一个单链表
        //迭代方式：初始化三个指针，分别指向当前节点（cur）、前一个节点（pre）、后一个节点（next）,遍历链表，将当前节点指向前一个节点，然后更新三个指针
        public ListNode ReverseList1(ListNode head)
        {
            ListNode cur = head, pre = null, next = null;
            while (cur != null)
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
        //递归方式：先找到最后一个节点，作为新链表的头结点,从链表尾部开始逐个反转节点，将当前节点的 next 指针指向前一个节点
        public ListNode ReverseList2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode newHead = ReverseList2(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }