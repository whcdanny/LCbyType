//Leetcode 2334. Subarray With Elements Greater Than Varying Threshold hard
//题意：给定一个整数数组nums和一个整数threshold。
//找到nums的任意子数组，其长度为k，并且子数组中的每个元素都大于threshold / k。
//返回任何满足条件的子数组的大小。如果没有这样的子数组，则返回-1。
//子数组是数组中连续的非空元素序列。
//思路：Stack, Monotonic Stack; 单调stack，找到每个位置的prevSmall和nextSmall
//在每个nus[i],找到preSmall位置和nextSmall位置，然后判断threshold / (double)len < nums[i]；得出答案；
//时间复杂度：O(n)，其中n为数组nums的长度，因为需要遍历整个数组。
//空间复杂度：O(1)，除了常数级别的额外空间，不需要额外的数据结构。
        public int validSubarraySize(int[] nums, int threshold)
        {
            int n = nums.Length;
            int[] next_small = new int[n];
            int[] prev_small = new int[n];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            Array.Fill(next_small, n);
            Array.Fill(prev_small, -1);
            for (int i = 1; i < n; i++)
            {
                while (stack.Count!=0 && nums[stack.Peek()] >= nums[i])
                {
                    stack.Pop();
                }
                if (stack.Count != 0)
                {
                    prev_small[i] = stack.Peek();
                }
                stack.Push(i);
            }
            stack = new Stack<int>();
            stack.Push(n - 1);
            for (int i = n - 2; i >= 0; i--)
            {
                while (stack.Count != 0 && nums[stack.Peek()] >= nums[i])
                {
                    stack.Pop();
                }
                if (stack.Count != 0)
                {
                    next_small[i] = stack.Peek();
                }
                stack.Push(i);
            }
            for (int i = 0; i < n; i++)
            {
                int len = next_small[i] - prev_small[i] - 1;
                if (threshold / (double)len < nums[i])
                {
                    return len;
                }
            }
            return -1;
        }