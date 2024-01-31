//Leetcode 234. Palindrome Linked List ez
//题意：要求判断一个链表是否为回文链表
//思路：双指针，使用快慢指针找到链表的中点，慢指针在找到中点的同时，将前半部分链表反转。
//比较前半部分和反转后的后半部分是否相等，如果相等则是回文链表。
//时间复杂度：寻找中点：O(n) 反转后半部分：O(n/2) => O(n) 比较前后半部分：O(n) 总体时间复杂度为 O(n)。
//空间复杂度：O(1)
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true; // 空链表或只有一个节点的链表是回文链表
            }

            // 1. 使用快慢指针找到链表的中点
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // 2. 反转链表的后半部分
            ListNode reversedHalf = ReverseList(slow);

            // 3. 比较前半部分和反转后的后半部分
            while (reversedHalf != null)
            {
                if (head.val != reversedHalf.val)
                {
                    return false;
                }
                head = head.next;
                reversedHalf = reversedHalf.next;
            }

            return true;
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode nextNode = current.next;
                current.next = prev;
                prev = current;
                current = nextNode;
            }
            return prev;
        }