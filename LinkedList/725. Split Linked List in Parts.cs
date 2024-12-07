//Leetcode 725. Split Linked List in Parts med
//题意：给定一个单链表的头节点 head 和一个整数 k，将该链表拆分成 k 个连续的部分，使每部分的长度尽可能相等。
//规则 每部分的长度相差不超过 1。
//如果链表节点数量少于 k，部分结果将是 null。
//拆分顺序与链表的原始顺序一致。
//返回一个包含 k 部分的数组，每部分是一个链表的头节点。
//思路：先获得长度，
//然后subNums = count / k 每个part最少得size
//extra = count % k; 最多前几个part size+1；以保证前一个size至少等于后一个size；
//然后依此当入k个，然后在每一个part结束， 
//ListNode nextStart = head.next;head.next = null;head = nextStart;
//时间复杂度：O(n)
//空间复杂度：O(k)
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            int count = getListNodeLength(head);
            int subNums = count / k;
            int extra = count % k;
            ListNode[] res = new ListNode[k];
            for(int i = 0; i < k; i++)
            {
                res[i] = head;
                int size = subNums + (i < extra ? 1 : 0);
                for(int j = 0; j < size - 1; j++)
                {
                    if (head != null)
                        head = head.next;
                }
                if (head != null)
                {
                    ListNode nextStart = head.next;
                    head.next = null;
                    head = nextStart;
                }
            }
            return res;
        }

        private int getListNodeLength(ListNode head)
        {
            int res = 0;
            while (head != null)
            {
                res++;
                head = head.next;
            }
            return res;
                
        }