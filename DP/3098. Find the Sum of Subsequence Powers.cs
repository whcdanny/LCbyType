//Leetcode 3098. Find the Sum of Subsequence Powers hard
//题意：题目要求计算数组 nums 中所有长度为 k 的子序列的 power 之和，其中 power 定义为子序列中任意两个元素的最小绝对差。
//思路：动态规划：表面上求的是“子序列”，其实求的是“子集”，对于顺序没有要求。所以我们会将nums先排序。此时任何“子序列”里的最小元素之差，必然出现在所按顺序选取的两个元素之间。
//可以枚举出所有的元素之差，比如元素a和元素b，约定它们是子序列里的“最小元素之差”（记做d），求这样的长度为k的子序列有多少个。
//在一个有序数组nums里，对于元素a和元素b，约定它们是子序列里的“最小元素之差”（记做d），求这样的长度为K的子序列有多少个。
//用DP求出在[1, a] 区间内有多少相邻元素之差大于d的子序列。我们令dp1[i][j] 表示以i结尾的、长度为j、且相邻元素跨度大于d的子序列个数。
//我们只需要找到前一个符合条件的位置k，满足nums[i]-nums[k]>d，就有dp1[i][j] += dp1[k][j - 1]，将所有符合条件的j遍历一遍，就可以求出dp[i][j].
//同理，我们从后往前进行DP，求出在[b, n] 区间里有多少相邻元素之差大于d的子序列。可以求解dp2[i][j] 表示以i开头的、长度为j、且相邻元素跨度大于等于d的子序列个数。
//只需要将期望长度K分配给[a, b] 的前后两段，假设分别是t和K-t，就可以得到组合数dp[a][t]*dp[b][K - t]，对应的就是包含a和b的、符合条件的子序列的个数。
//特别注意，dp1和dp2的定义略有不同，前者要求跨度大于d，后者要求跨度大于等于d。
//这是因为一个子序列里可能有多个最小跨度d，我们约定只认为第一个出现的最小跨度d是我们的枚举对象。所以在[1, a] 区间内，我们不接受相邻元素跨度恰好为d的情况。
//时间复杂度: n^5
//空间复杂度：n
        int n_SumOfPowers =0;
		int MOD = 1000000007;
        public int SumOfPowers(int[] nums, int k)
        {
            n_SumOfPowers = nums.Length;
            Array.Sort(nums);
            int[] newNums = new int[n_SumOfPowers + 1];
            newNums[0] = 0;
            int index = 1;
            long res = 0;
            foreach (int num in nums)
                newNums[index++] = num;
            
            for (int i = 1; i <= n_SumOfPowers; i++)
            {
                for(int j = i + 1; j <= n_SumOfPowers; j++)
                {
                    int d = newNums[j] - newNums[i];
                    res = (res+helperSumOfPowers(newNums, k, d, i, j))%MOD;                   
                }
            }
            return (int)res;
        }

        private long helperSumOfPowers(int[] nums, int k_length, int d, int a, int b)
        {
            long[,] dp1 = new long[n_SumOfPowers + 2, n_SumOfPowers + 2];
            long[,] dp2 = new long[n_SumOfPowers + 2, n_SumOfPowers + 2];
            for(int i = 1; i <= n_SumOfPowers; i++)
            {
                dp1[i, 1] = 1;
                dp2[i, 1] = 1;
            }
            for(int i = 1; i <= a; i++)
            {
                for(int j = 2; j <= k_length; j++)
                {
                    for(int k=1;nums[i]-nums[k]>d && k < i; k++)
                    {
                        dp1[i, j] = (dp1[i, j] + dp1[k, j - 1]) % MOD;                       
                    }
                }
            }
            for (int i = n_SumOfPowers; i >= b; i--)
            {
                for (int j = 2; j <= k_length; j++)
                {
                    for (int k = n_SumOfPowers; nums[k] - nums[i] >= d && k > i; k--)
                    {
                        dp2[i, j] = (dp2[i, j] + dp2[k, j - 1]) % MOD;
                    }
                }
            }

            long res = 0;
            for(int t = 1; t < k_length; t++)
            {
                res += dp1[a, t] * dp2[b, k_length - t] % MOD;
                res %= MOD;
            }
            return res * d;
        }