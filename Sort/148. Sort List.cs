//148. Sort List med
//在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序
//并归排序：通过快慢针将链表一分为二，再进行合并；
        public ListNode SortList(ListNode head)
        {
            //空或者当只有1个；
            if (head == null || head.next == null)
                return head;
            ListNode slow = head;
            ListNode fast = head.next;
            //通过这个位置将链表一分为二
            while (fast!=null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            ListNode left = head;
            ListNode right = slow.next;
            slow.next = null;

            left = SortList(left);
            right = SortList(right);

            return Merge(left, right);
        }
        public ListNode Merge(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            if (l1.val < l2.val)
            {
                l1.next = Merge(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = Merge(l1, l2.next);
                return l2;
            }
                
        }