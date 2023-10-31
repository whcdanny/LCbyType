//Leetcode 53 Maximum Subarray med
//题意：给定一个整数数组 nums，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
//思路：前缀和（Prefix Sum）, 更新当前的子数组和 currentSum，如果 currentSum 变得比当前元素 nums[i] 小，就从当前元素开始重新计算子数组和，否则继续累加。同时，我们也维护了最大子数组和 maxSum，在每次迭代中都进行比较更新
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxSubArray(int[] nums)
        {
            int n = nums.Length;
            int maxSum = nums[0];
            int currentSum = nums[0];

            for (int i = 1; i < n; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        public int MaxSubArray_超时(int[] nums)
        {
            int n = nums.Length;
            int[] prefixSum = new int[n + 1];

            int maxSum = int.MinValue;
            int currentSum = 0;

            for (int i = 0; i < n; i++)
            {
                currentSum += nums[i];
                prefixSum[i + 1] = currentSum;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    maxSum = Math.Max(maxSum, prefixSum[i] - prefixSum[j]);
                }
            }

            return maxSum;
        }