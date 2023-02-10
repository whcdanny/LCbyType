//234. Palindrome Linked List med
//输入一个单链表的头结点，判断这个链表中的数字是不是回文
//思路：用快慢针先把一般的listnode存入slow，然后reverse slow，然后一个一个比较；
		public bool IsPalindrome(ListNode head)
        {
            ListNode slow, fast;
            slow = fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null)
                slow = slow.next;

            ListNode left = head;
            ListNode right = reverseIsPalindrome(slow);
            while (right != null)
            {
                if (left.val != right.val)
                    return false;
                left = left.next;
                right = right.next;
            }

            return true;
        }
        public ListNode reverseIsPalindrome(ListNode head)
        {
            ListNode pre = null, cur = head;
            while (cur != null)
            {
                ListNode next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
//思路：与上面一样，只不过不需要新的funciton		
		public bool IsPalindrome(ListNode head) {
        LinkedList<int> nodeVal = new LinkedList<int>();
        if (head == null || head.next == null)
        {
            return true;
        }
        ListNode slow = head;
        ListNode fast = head;
        nodeVal.AddFirst(slow.val);
        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            nodeVal.AddFirst(slow.val);
        }

        ListNode cur = slow;
        if (fast.next != null)
        {
            cur = slow.next;
        }
        int i = 0;
        while (cur != null)
        {
            if (nodeVal.ElementAt(i) != cur.val)
            {
                return false;
            }
            cur = cur.next;
            i++;
        }
        return true;
    }