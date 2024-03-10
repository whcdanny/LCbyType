//Leetcode 1673. Find the Most Competitive Subsequence med
//题意：给定一个整数数组 nums 和一个正整数 k，返回 nums 的大小为 k 的最具竞争力的子序列。
//数组的子序列是通过从数组中删除一些（可能为零）元素而获得的结果序列。
//我们定义，如果在子序列 a 和 b（长度相同）的第一个位置不同的位置上，子序列 a 的数字小于子序列 b 中相应的数字，则子序列 a 比子序列 b 更具竞争力。
//思路：Stack + Monotonic Stack, 调递增栈来维护一个最具竞争力的子序列。
//遍历数组 nums，并在遍历过程中执行以下操作：
//如果当前元素比栈顶元素小且删除栈顶元素后剩余元素的数量足够使得子序列长度达到 k，则弹出栈顶元素，直到栈顶元素比当前元素小或者栈为空。
//将当前元素压入栈中。
//最后栈中剩余的元素即为最具竞争力的子序列。
//注：如果当前元素比栈顶元素小且删除栈顶元素后剩余元素的数量足够使得子序列长度达到 k
//时间复杂度：O(n)，其中 n 为数组 nums 的长度
//空间复杂度：O(k)
        public int[] MostCompetitive(int[] nums, int k)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && stack.Peek() > nums[i] && stack.Count + nums.Length - i > k)
                {
                    stack.Pop();
                }
                if (stack.Count < k)
                {
                    stack.Push(nums[i]);
                }
            }

            int[] result = new int[k];
            for (int i = k - 1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }

            return result;
        }