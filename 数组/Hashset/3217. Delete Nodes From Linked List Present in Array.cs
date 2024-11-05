//Leetcode 3217. Delete Nodes From Linked List Present in Array med
//题目：给定一个整数数组 nums 和一个链表的头节点 head，
//需要删除链表中所有值在 nums 中出现过的节点，并返回修改后的链表头节点。
//思路: 使用哈希集合进行快速查找：
//将数组 nums 的所有元素存入一个哈希集合 set 中，以便能够在 O(1) 时间复杂度内判断某个节点值是否在 nums 中。
//遍历链表并删除匹配的节点：
//用一个指针 current 遍历链表，依次检查每个节点的值是否在 set 中。
//如果 current.next 节点的值存在于 set，则将该节点删除，即跳过这个节点。
//如果 current.next 的值不在 set 中，则正常移动到下一个节点。
//特殊情况处理：
//如果 head 本身的值就在 nums 中，我们需要跳过 head，直到找到第一个值不在 nums 中的节点作为新的头节点。
//时间复杂度：O(m+n) n是node节点个数，m是nums的长度
//空间复杂度：O(m)
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            // 将 nums 中的所有元素存入哈希集合，便于快速查找
            HashSet<int> set = new HashSet<int>(nums);

            // 跳过 head 中属于 nums 的节点，找到新的头节点
            while (head != null && set.Contains(head.val))
            {
                head = head.next;
            }

            ListNode current = head;

            // 遍历链表，删除属于 nums 的节点
            while (current != null && current.next != null)
            {
                if (set.Contains(current.next.val))
                {
                    current.next = current.next.next; // 删除节点
                }
                else
                {
                    current = current.next; // 移动到下一个节点
                }
            }

            return head;
        }