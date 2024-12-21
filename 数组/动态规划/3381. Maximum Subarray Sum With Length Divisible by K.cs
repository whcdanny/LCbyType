//Leetcode 3381. Maximum Subarray Sum With Length Divisible by K med
//题意：给定一个整数数组 nums 和一个整数 k，要求找到一个子数组，
//使得：子数组的长度是 k 的倍数。
//子数组的元素和最大。返回这个最大和。如果无法满足条件，则返回 0。
//定义子数组是一个连续的元素子序列。k 的倍数表示子数组长度 len 满足 len%k==0。
//思路：dp 用maxSum存入从后往前每个位置最大sum
//检查条件就是i+k
//1个是curSum要移除如果超出范围currSum -= i + k < n ? nums[i + k] : 0;
//1个是当还没满足k的时候，i + k > n：maxSum[i] = 0;
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public long MaxSubarraySum(int[] nums, int k)
        {
            int n = nums.Length;
            long ans = long.MinValue;
            long currSum = 0;
            long[] maxSum = new long[n + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                currSum += nums[i];
                currSum -= i + k < n ? nums[i + k] : 0;
                if (i + k > n)
                {
                    maxSum[i] = 0;
                    continue;
                }
                maxSum[i] = Math.Max(currSum, currSum + maxSum[i + k]);
                ans = Math.Max(ans, maxSum[i]);
            }

            return ans;
        }
        public long MaxSubarraySum_超时(int[] nums, int k)
        {
            int n = nums.Length;
            int div = n / k;
            long[] preSum = new long[n+1];
            preSum[0] = 0;
            for(int i = 1; i <= n; i++)
            {
                preSum[i] += preSum[i - 1] + nums[i-1];
            }
            long res = long.MinValue;
            for(int i = 1; i <= div; i++)
            {
                for(int j = 0; j <= n - i * k; j++)
                {
                    int len = j + i * k;                    
                    long cur = preSum[len] - preSum[j];
                    res = Math.Max(res, cur);
                }
            }

            return res;
        }