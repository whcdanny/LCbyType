//86：给一个list，然后给x节点，将比这个x节点小的数放在新的ListNode并把剩下的接在后面 med
//思路：做两个ListNode，然后合并；
		public ListNode Partition(ListNode head, int x)
        {
            ListNode newListNode = head;
            //虚拟头结点，避免处理空指针
            ListNode lowX = new ListNode(-1);
            ListNode highX = new ListNode(-1);
            ListNode low = lowX;
            ListNode high = highX;

            while (newListNode != null)
            {
                if (newListNode.val < x)
                {
                    low.next = newListNode;
                    low = low.next;
                }
                else
                {
                    high.next = newListNode;
                    high = high.next;
                }
                //断开原链表中的每个节点的 next 指针
                ListNode temp = newListNode.next;
                newListNode.next = null;
                newListNode = temp;
            }
            low.next = highX.next;
            return lowX.next;
        }