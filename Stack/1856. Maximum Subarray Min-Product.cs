//Leetcode 1856. Maximum Subarray Min-Product hard
//题意：给定一个整数数组 nums，求其中任意非空子数组的最大 min-product，其中 min-product 定义为数组中的最小值乘以数组的和。
//思路：Stack,Monotonic Stack 要使得 min-product 最大化，需要找到最小值尽可能大的子数组，同时保证数组的和尽可能大。
//使用单调栈来找到以每个元素为最小值的子数组的左右边界，然后计算该子数组的 min-product。
//遍历数组，对于每个元素，找到以该元素为最小值的子数组的左右边界，计算该子数组的 min-product，并更新最大值。
//最后返回最大 min-product 对 10^9 + 7 取模后的结果。
//时间复杂度：O(n)，其中 n 是数组 nums 的长度，遍历一次数组并使用单调栈计算左右边界
//空间复杂度：O(n)，需要额外的空间存储前缀和数组和单调栈
        public int MaxSumMinProduct(int[] nums)
        {
            long[] prefixSum = new long[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + nums[i];
            }

            long[] left = new long[nums.Length];
            long[] right = new long[nums.Length];

            Stack<int> stack = new Stack<int>(); 

            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                {
                    stack.Pop();
                }
                left[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            stack.Clear();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                {
                    stack.Pop();
                }
                right[i] = stack.Count == 0 ? nums.Length : stack.Peek();
                stack.Push(i);
            }

            long maxProduct = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                long minProduct = nums[i] * (prefixSum[(int)right[i]] - prefixSum[(int)left[i] + 1]);
                maxProduct = Math.Max(maxProduct, minProduct);
            }

            return (int)(maxProduct % 1000000007);
        }