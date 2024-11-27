//Leetcode 19. Remove Nth Node From End of List med
//题意：给定head一个链接列表，从列表末尾删除节点并返回其头。nth        
//思路：删除倒数第 n 个，要先找倒数第 n + 1 个节点，也就是被删除的前一个
// p1 先走 k 步
// p1 和 p2 同时走 n - k 步
// p2 现在指向第 n - k + 1 个节点，即倒数第 k 个节点
//时间复杂度：O(n)
//空间复杂度：O(1)
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //虚拟头结点，避免处理空指针
            ListNode res = new ListNode(-1);
            res.next = head;
            //删除倒数第 n 个，要先找倒数第 n + 1 个节点，也就是被删除的前一个
            ListNode x = findFromEnd(res, n + 1);
            x.next = x.next.next;
            return res.next;
        }
        public ListNode findFromEnd(ListNode head, int k)
        {
            ListNode p1 = head;
            // p1 先走 k 步
            for (int i = 0; i < k; i++)
            {
                p1 = p1.next;
            }
            ListNode p2 = head;
            // p1 和 p2 同时走 n - k 步
            while (p1 != null)
            {
                p2 = p2.next;
                p1 = p1.next;
            }
            // p2 现在指向第 n - k + 1 个节点，即倒数第 k 个节点
            return p2;
        }