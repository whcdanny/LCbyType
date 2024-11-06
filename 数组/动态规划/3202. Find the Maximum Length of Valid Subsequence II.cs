//Leetcode 3202. Find the Maximum Length of Valid Subsequence II med
//题目：给定一个整数数组 nums 和一个正整数 k。我们需要找到 nums 的一个最长的子序列 sub，使得它满足以下条件：
//对于子序列的任意相邻两个元素 sub[i] 和 sub[i + 1]， (sub[i] + sub[i + 1]) % k 的结果都相等。
//思路: 动态规划
//dp[i][mod] 表示以 nums[i] 结尾，并且相邻和的余数为 mod 的最长有效子序列长度。
//初始化 dp 数组，设 dp[i][mod] 的初始值为 1，表示每个元素可以单独作为一个子序列，满足题意（即序列长度为 1）。
//给定一个数 nums[i]，如果我们能找到一个之前的数 nums[j]，并且 nums[j] 结尾的有效子序列满足相同的余数 mod，
//那么可以将 nums[i] 接到这个子序列之后，形成一个更长的有效子序列。
//这时就需要更新dp[i][mod]，因为j比i小，所以1 + dp[j][mod]表示如果时以j结尾并且商是mod，i比j大所以就是可以在j的后面再加上i，
//最后比较大小，并更新res
//时间复杂度：O(n^2 * k)
//空间复杂度：O(n * k)
        public int MaximumLength(int[] nums, int k)
        {
            int res = 0, n = nums.Length;
            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                var temp = new int[k];
                Array.Fill(temp, 1);
                dp[i] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var mod = (nums[i] + nums[j]) % k;
                    dp[i][mod] = Math.Max(dp[i][mod], 1 + dp[j][mod]);
                    res = Math.Max(res, dp[i][mod]);
                }
            }
            return res;
        }