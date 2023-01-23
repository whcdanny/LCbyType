//21: 给两个sorted linked， 合并成一个sorted linked； ez
//思路：分别比较两个ListNode的val 然后将小的存入直到结束；				
		public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            //虚拟头结点，避免处理空指针
            ListNode temp = new ListNode(-1), p = temp;
            ListNode p1 = list1, p2 = list2;
            while(p1 !=null && p2 != null)
            {
                if(p1.val > p2.val)
                {
                    p.next = p2;
                    p2 = p2.next;
                }
                else
                {
                    p.next = p1;
                    p1 = p1.next;
                }
                p = p.next;
            }
            if (p1 != null)
            {
                p.next = p1;
            }
            if (p2 != null)
            {
                p.next = p2;
            }
            return temp.next;
        }