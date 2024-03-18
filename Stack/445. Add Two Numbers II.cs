//Leetcode 445. Add Two Numbers II med
//题意：给定两个非空链表，表示两个非负整数。链表中的数字按照从高位到低位的顺序存储，每个节点包含一个数字。将这两个数相加，并将结果以链表形式返回。
//假设两个数不包含任何前导零，除非这个数字本身是 0。
//思路：Stack两个链表中的数字逐个入栈，使得栈顶存放的是链表中的最低位数字。
//依次出栈两个栈，同时计算它们的和以及进位，并构建新的链表。
//注意处理进位的情况，如果最后一位相加后有进位，需要额外创建一个节点来存放进位。
//时间复杂度：O(max(m, n))，其中 m 和 n 分别是两个链表的长度。
//空间复杂度：O(max(m, n))
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            // 将两个链表中的数字入栈
            while (l1 != null)
            {
                stack1.Push(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                stack2.Push(l2.val);
                l2 = l2.next;
            }

            int carry = 0;
            ListNode dummy = new ListNode(0);

            // 逐个出栈相加
            while (stack1.Count > 0 || stack2.Count > 0 || carry > 0)
            {
                int sum = carry;
                if (stack1.Count > 0) sum += stack1.Pop();
                if (stack2.Count > 0) sum += stack2.Pop();

                carry = sum / 10;
                ListNode newNode = new ListNode(sum % 10);

                // 将新节点插入到链表头部
                newNode.next = dummy.next;
                dummy.next = newNode;
            }

            return dummy.next;
        }