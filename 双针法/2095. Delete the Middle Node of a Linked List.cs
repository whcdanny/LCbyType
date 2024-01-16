//Leetcode 2095. Delete the Middle Node of a Linked List med
//题意：给定一个链表的头结点，删除中间的节点，并返回修改后的链表的头结点。
//链表的中间节点是指链表的大小为 n 时，从头开始的第 ⌊n / 2⌋ 个节点，其中⌊x⌋表示小于等于 x 的最大整数。
//例如，对于 n = 1, 2, 3, 4 和 5，中间节点分别为 0, 1, 1, 2 和 2。
//思路：使用快慢指针，快指针每次移动两步，慢指针每次移动一步。当快指针到达链表尾部时，慢指针刚好到达中间节点的位置。然后将慢指针所在的节点从链表中删除。
//时间复杂度: O(n)
//空间复杂度：O(1)
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null; // 链表为空或只有一个节点时，无中间节点
            }

            ListNode slow = head;
            ListNode fast = head;
            ListNode prev = null;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = slow.next; // 删除中间节点

            return head;
        }