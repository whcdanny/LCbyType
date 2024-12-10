//Leetcode 817. Linked List Components med
//题意：给定head一个包含唯一整数值​​的链表和一个nums作为链表值子集的整数数组。
//如果两个值在链接列表中连续出现，则返回它们连接的连通分量的数量。nums
//思路：先将int[]转换成list，便于后面查找
//如果当前val在nums中，那么就开始找到下一个不含的，
//如果当前不含，那么如果之前count>0，说明前面有发现，那么res++，count=0
//最后一轮，如果has=true，那么res再++；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int NumComponents(ListNode head, int[] nums)
        {
            int res = 0;
            int count = 0;            
            List<int> list = new List<int>(nums);
            bool has = false;
            ListNode next = head;
            while (next != null)
            {
                int val = next.val;
                if (list.Contains(val)){
                    count++;
                    has = true;
                }
                else
                {
                    if (count > 0)
                    {
                        res++;
                        count = 0;
                    }
                    has = false;
                }
                next = next.next;
            }
            if (has)
            {
                res++;
            }
            return res;
            /*int res = 0;
            var list = new HashSet<int>(nums);
            bool has = false;
            ListNode next = head;

            while (next != null)
            {
                if (has && !list.Contains(next.val))
                {
                    res++;
                    has = false;
                }
                else if (!has && list.Contains(next.val))
                {
                    has = true;
                }
                
                next = next.next;
            }
            if (has)
            {
                res++;
            }
            return res;*/
        }