//Leetcode 206. Reverse Linked List med
//题意：要求将一个单链表反转
//思路：迭代方式：初始化三个指针，分别指向当前节点（cur）、前一个节点（pre）、后一个节点（next）,遍历链表，将当前节点指向前一个节点，然后更新三个指针
//时间复杂度：O(n)
//空间复杂度：O(1)
        public ListNode ReverseList1(ListNode head)
        {
            ListNode cur = head, pre = null, next = null;
            while (cur != null)
            {
                next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }