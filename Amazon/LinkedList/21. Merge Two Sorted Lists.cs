//Leetcode 21. Merge Two Sorted Lists ez
//题意：给出了两个已排序链表的头list1和list2。
//将两个列表合并为一个排序列表。该列表应通过将前两个列表的节点拼接在一起而制成。
//返回合并链表的头。
//思路：p1,p2 然后比较value，然后插入到res
//时间复杂度：O(n+m)
//空间复杂度：O(n+m)
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode temp = new ListNode(-1), p = temp;
            ListNode p1 = list1, p2 = list2;
            while (p1 != null && p2 != null)
            {
                if (p1.val > p2.val)
                {
                    p.next = p2;
                    p2 = p2.next;
                }
                else
                {
                    p.next = p1;
                    p1 = p1.next;
                }
                p = p.next;
            }
            if (p1 != null)
            {
                p.next = p1;
            }
            if (p2 != null)
            {
                p.next = p2;
            }
            return temp.next;
        }