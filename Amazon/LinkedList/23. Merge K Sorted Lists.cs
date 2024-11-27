//Leetcode 23. Merge K Sorted Lists hard
//题意：给定 k 个已排序的链表，将它们合并成一个新的已排序链表
//思路：从中间开始往外扩散，两两合并；
//时间复杂度：假设每个链表的平均长度为 n，一共有 k 个链表。那么总共有 k*n 个节点。建堆的时间复杂度是 O(k* logk)，每次插入和删除元素的时间复杂度是 O(logk)，总共有 k*n 次操作，因此总时间复杂度是 O(k* n*logk)
//空间复杂度：O(k) 
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            return Merge_MergeKLists(lists, 0, lists.Length - 1);
        }

        private ListNode Merge_MergeKLists(ListNode[] lists, int left, int right)
        {
            if (left == right) return lists[left];

            int mid = left + (right - left) / 2;
            ListNode l1 = Merge_MergeKLists(lists, left, mid);
            ListNode l2 = Merge_MergeKLists(lists, mid + 1, right);

            return MergeTwoLists(l1, l2);
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            if (l1 != null) current.next = l1;
            if (l2 != null) current.next = l2;

            return dummy.next;
        }