//Leetcode 328. Odd Even Linked List med
//题意：要求将链表的奇数位置节点和偶数位置节点分别连接起来，使得奇数位置节点在前，偶数位置节点在后。
//思路：可以使用迭代的方法解决这个问题 使用两个指针，一个指向奇数位置节点的末尾（odd），一个指向偶数位置节点的末尾（even）。遍历链表，将奇数位置节点和偶数位置节点分别连接起来，同时更新odd和even的位置。最后，将奇数位置节点的末尾指向偶数位置节点的头部。
//时间复杂度：O(n)，其中n是链表的长度。
//空间复杂度：O(1)，因为只使用了两个指针
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode odd = head;
            ListNode even = new ListNode(-1);
            if (head.next != null)
                even = head.next;
            else
                even = null;
            ListNode res = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = res;
            return head;
        }