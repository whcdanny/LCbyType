//Leetcode 3196. Maximize Total Cost of Alternating Subarrays med
//题目：给定一个整数数组 nums，数组的长度为 n。定义一个子数组 nums[l..r] 的代价 cost(l, r) 为：
//cost(l, r) = nums[l] - nums[l + 1] + ... + nums[r] * (−1)r − l
//也就是说，子数组的代价是从左到右对元素进行交替相减相加的结果。
//思路: 动态规划，dp 数组用于存储在 nums 的前 i 个元素中，能够得到的最大代价
//对于每个位置，要不就是+nums[i], 要不就是前一项dp[i-1]+nums[i-1]-nums[i]
//然后找出每个位置最大，最后就是最大的可能性
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MaximumTotalCost(int[] nums)
        {
            int n = nums.Length;
            long[] dp = new long[n + 1];
            dp[0] = 0;
            dp[1] = nums[0];
            for (int i = 1; i < n; ++i)
            {
                dp[i + 1] = Math.Max(dp[i] + nums[i], dp[i - 1] + nums[i - 1] - nums[i]);
            }
            return dp[n];
        }