//Leetcode 143. Reorder List med
//题意：您将获得一个单链表的头。该列表可以表示为：
//L 0 → L 1 → … → L n - 1 → L n
//将列表重新排序为以下形式：
//L 0 → L n → L 1 → L n - 1 → L 2 → L n - 2 → …
//您不能修改列表节点中的值。只有节点本身可以​​更改。     
//思路：先找到中点到结束的那个listNode，L2.
//然后把L2倒转，然后L1从head开始，
//然后把L1和L2每个选取一个合并一个
//时间复杂度：O(n)
//空间复杂度：O(1)
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            ListNode prev = null, slow = head, fast = head, l1 = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            ListNode l2 = reverse_ReorderList(slow);

            merge_ReorderList(l1, l2);
        }
        private void merge_ReorderList(ListNode l1, ListNode l2)
        {
            while (l1 != null)
            {
                ListNode n1 = l1.next, n2 = l2.next;
                l1.next = l2;

                if (n1 == null)
                    break;

                l2.next = n1;
                l1 = n1;
                l2 = n2;
            }
        }

        private ListNode reverse_ReorderList(ListNode head)
        {
            ListNode prev = null, curr = head, next = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }