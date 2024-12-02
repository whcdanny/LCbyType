//Leetcode 382. Linked List Random Node med
//题意：给定一个单链表，从链表中返回一个随机节点的值。
//每个节点被选中的概率必须相同。
//实现Solution类：
//Solution(ListNode head)使用单链表的头初始化对象head。
//int getRandom()从列表中随机选择一个节点并返回其值。列表中所有节点被选中的概率应相等。   
//思路：用list来存每一个node
//然后用list[random.Next(list.Count)];
//时间复杂度：O(n)
//空间复杂度：O(1)
        public class Solution
        {
            public List<int> list = new List<int>();

            public Solution(ListNode head)
            {
                ListNode current = head;
                while (current != null)
                {
                    list.Add(current.val);
                    current = current.next;
                }
            }

            public int GetRandom()
            {
                Random random = new Random();
                // Get the random element from the list
                return list[random.Next(list.Count)];
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(head);
         * int param_1 = obj.GetRandom();
         */