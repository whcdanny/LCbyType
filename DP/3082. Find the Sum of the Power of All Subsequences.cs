//Leetcode 3082. Find the Sum of the Power of All Subsequences hard
//题意：给定一个整数数组 nums，定义一个子序列的 power 为该子序列的所有元素的和的平方。请计算 nums 的所有子序列的 power 之和，并返回该和对 10^9 + 7 取模的结果。
//思路：动态规划：“子序列的子序列”思考起来比较费劲，但是如果只是求“和为k的子序列的个数”，这个看上去就是典型的DP。
//然后我们再思考一下，本题其实就是求每个“和为k的子序列”有多少个超序列（super sequence）。
//所以我们只需要求出所有不同长度的、和为k的子序列个数。这个只不过在前述DP的基础上，再增加一个变量/下标记录已经选取元素的个数。
//即令dp[i][s][j]表示在前i个元素里、选取j个元素、和为s的子序列有多少个。显然它的转移方程就取决于第i个元素是否选取：
//dp[i][s][j] += dp[i - 1][s][j];  // no select nums[i]
//dp[i][s][j] += dp[i - 1][s - nums[i]][j - 1], if (s>=nums[i] && j>=1);  // select nums[i]
//最终考察完整个nums之后，我们遍历子序列的长度j，就可以知道存在有dp[n][k][j] 个符合要求的子序列，并且其长度是j。那么它的超序列就有2^(n-j)个。
//时间复杂度: n 是树中节点的数量, O(n)
//空间复杂度： w 是树的最大宽度, O(w);
        long[,,] dp_SumOfPower = new long[105,105,105];
        int MOD = 1000000007;
        public int SumOfPower(int[] nums, int k)
        {
            int n = nums.Length;
            int[] newNums = new int[n+1];
            newNums[0] = 0;
            int index = 1;
            foreach (int num in nums)
            {
                newNums[index] = num;
                index++;
            }
                
            dp_SumOfPower[0, 0, 0] = 1;
            for(int i = 1; i <= n; i++)
            {
                for(int s = 0; s <= k; s++)
                {
                    for(int j = 0; j <= i; j++)
                    {
                        dp_SumOfPower[i, s, j] = dp_SumOfPower[i - 1, s, j];
                        if (s >= newNums[i] && j > 0)
                            dp_SumOfPower[i, s, j] += dp_SumOfPower[i - 1, s - newNums[i], j - 1];
                        dp_SumOfPower[i, s, j] %= MOD;
                    }
                }
            }
            long[] power = new long[105];            
            power[0] = 1;
            for(int i = 1; i <= n; i++)
            {
                power[i] = power[i - 1] * 2 % MOD;
            }
            int res = 0;
            for(int j = 1; j <= n; j++)
            {
                long t = dp_SumOfPower[n, k, j];
                res = (int)(res + t * power[n - j] % MOD) % MOD;
            }
            return res;
        }