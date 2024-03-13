//Leetcode 1019. Next Greater Node In Linked List med
//题意：给定一个链表，要求对于链表中的每个节点，找出其后面第一个比它大的节点的值，并返回一个整数数组。
//思路：stack, 遍历链表，将链表节点的值存储在一个数组中。
//创建一个栈，用于存储链表节点的索引。
//遍历数组中的每个节点值：
//如果栈为空，将当前节点索引入栈。
//如果当前节点值大于栈顶索引所对应的节点值，说明当前节点是栈顶索引所对应节点的下一个较大节点，将栈顶索引出栈，并更新对应的结果数组中的值。
//否则，将当前节点索引入栈。
//返回结果数组。
//时间复杂度: 遍历链表节点需要 O(n) 的时间，遍历结果数组也需要 O(n) 的时间
//空间复杂度：除了存储结果数组外，我们需要一个栈来辅助操作，最坏情况下栈的空间复杂度为 O(n)
        public int[] NextLargerNodes(ListNode head)
        {
            List<int> nums = new List<int>();
            Stack<int> stack = new Stack<int>();

            // 将链表节点的值存储在数组中
            while (head != null)
            {
                nums.Add(head.val);
                head = head.next;
            }

            int[] result = new int[nums.Count];

            // 遍历数组中的每个节点值
            for (int i = 0; i < nums.Count; i++)
            {
                while (stack.Count > 0 && nums[i] > nums[stack.Peek()])
                {
                    int index = stack.Pop();
                    result[index] = nums[i];
                }
                stack.Push(i);
            }

            return result;
        }