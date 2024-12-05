//Leetcode 312. Burst Balloons hard
//题目：你有 n 个气球，编号从 0 到 n−1。每个气球上标注了一个数字，表示在数组 nums 中的值。
//如果你戳破第 i 个气球，你将获得硬币数量为：
//nums[i−1]×nums[i]×nums[i + 1] 
//如果i−1 或 i+1 越界，则将其视为值为 1 的虚拟气球。
//要求通过“合理”地戳破所有气球，获得最多的硬币数量。
//思路: 动态规划 dp[i][j] 表示[i,j]区间内最大的值
//先给nums前后赋值1
//然后确认len从1-n；然后left从1开始，right=left + len - 1;
//在确定完区间[i,j] k位置气球作为最后戳破的气球，[i,k-1][k+1,j]
//那么Max(dp[left, right], dp[left, k - 1] + extendedNums[left - 1] * extendedNums[k] * extendedNums[right + 1] + dp[k + 1, right]);
//时间复杂度：O(n^3)
//空间复杂度：O(n^2)
        public int MaxCoins(int[] nums)
        {
            int n = nums.Length;
            int[] extendedNums = new int[n + 2];
            extendedNums[0] = extendedNums[n + 1] = 1;
            for (int i = 0; i < n; i++)
            {
                extendedNums[i + 1] = nums[i];
            }

            // 动态规划数组
            int[,] dp = new int[n + 2, n + 2];

            // 遍历区间长度
            for (int len = 1; len <= n; len++)
            {
                for (int left = 1; left <= n - len + 1; left++)
                {
                    int right = left + len - 1;
                    for (int k = left; k <= right; k++)//
                    {
                        dp[left, right] = Math.Max(dp[left, right], dp[left, k - 1] + extendedNums[left - 1] * extendedNums[k] * extendedNums[right + 1] + dp[k + 1, right]);
                    }
                }
            }

            return dp[1, n];
        }