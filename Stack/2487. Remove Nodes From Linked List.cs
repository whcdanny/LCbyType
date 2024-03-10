//Leetcode 2487. Remove Nodes From Linked List med
//题意：给定一个链表的头节点。移除链表中所有节点，其后存在比它值更大的节点。
//返回修改后的链表的头节点。
//思路：Stack; 用stack来存在比它值更大的节点
//当存的比之前的大，那么就将小的全都弹出，这样留下的就是答案；
//时间复杂度：O(n)，其中n为链表的长度，因为需要遍历整个链表
//空间复杂度：O(n)，最坏情况下，栈的大小为链表的长度。
        public ListNode RemoveNodes(ListNode head)
        {
            var stack = new Stack<int>();
            var temp = head;

            while (temp != null)
            {
                while (stack.Count > 0 && stack.Peek() < temp.val)
                {
                    stack.Pop();
                }
                stack.Push(temp.val);
                temp = temp.next;
            }

            if (stack.Count == 0)
            {
                return null;
            }

            var result = new ListNode(stack.Pop());

            while (stack.Count > 0)
            {
                var prev = new ListNode(stack.Pop());
                prev.next = result;
                result = prev;
            }

            return result;
        }