//Leetcode 3165. Maximum Sum of Subsequence With Non-adjacent Elements hard
//题目：给定一个整数数组 nums，和一个查询数组 queries，其中 queries[i] = [posi, xi] 表示在第 i 个查询中，将 nums[posi] 的值更新为 xi。
//每次查询后，需要计算 nums 的一个子序列的最大和，要求该子序列中相邻元素不能被同时选中。
//最终返回所有查询结果的和。因为结果可能很大，所以要对 取模。
//思路:动态规划，dp[i] 表示在位置 i 处的最大不相邻子序列和
//然后0，和1取决于dp[0] = Math.Max(0, nums[0]);dp[1] = Math.Max(dp[0], nums[1]);
//然后剩下的从2开始，然后每个位置选或者不选dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
//最后把queries 一个一个放入，然后看根据之前0，1和剩下的，思路一样
//时间复杂度：O(Q*N), where N is the length of the input array and Q is the number of queries
//空间复杂度：O(N)
        public int MaximumSumSubsequence_超时(int[] nums, int[][] queries)
        {
            const int MOD = 1000000007;
            int n = nums.Length;
            long sum = 0;
            //其中 dp[i] 表示在位置 i 处的最大不相邻子序列和
            long[] dp = new long[n];

            dp[0] = Math.Max(0, nums[0]);

            //dp[1] 为 Math.Max(dp[0], nums[1])，因为我们要么选 nums[1]，要么不选
            if (n > 1)
            {
                dp[1] = Math.Max(dp[0], nums[1]);
            }

            // 初始化dp数组
            //选或者不选
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }

            // 处理每个查询
            foreach (int[] q in queries)
            {
                int pos = q[0];
                int value = q[1];
                nums[pos] = value;

                if (pos == 0)
                {
                    dp[0] = Math.Max(0, nums[0]);
                    if (n > 1)
                    {
                        dp[1] = Math.Max(dp[0], nums[1]);
                    }
                }
                else if (pos == 1)
                {
                    dp[1] = Math.Max(dp[0], nums[1]);
                }

                // 更新从pos位置开始的dp数组
                for (int i = Math.Max(2, pos); i < n; i++)
                {
                    dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
                }

                // 计算当前查询的结果并累加到sum
                sum = (sum + dp[n - 1]) % MOD;
            }

            return (int)sum;
        }