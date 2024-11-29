//Leetcode 1143. Longest Common Subsequence med
//题意：给定两个字符串 text1 和 text2，返回它们最长公共子序列的长度。如果没有公共子序列，返回 0。
//子序列：从一个字符串中选出若干字符（可以是 0 个）并保持其顺序形成的新字符串。
//公共子序列：两个字符串都包含的子序列。
//思路：动态规划，dp存text2到位置含相同的字母
//从text1开始一个一个算，然后跟每个text2一个一个比，
//然后如果一样，就更新dp，
//如果不一样，newDp[j] = Math.Max(dp[j], newDp[j - 1]);
//时间复杂度：O(n×m)
//空间复杂度：O(n)      
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length, n = text2.Length;
            // 滚动数组优化
            int[] dp = new int[n + 1];

            for (int i = 1; i <= m; i++)
            {
                int[] newDp = new int[n + 1];
                for (int j = 1; j <= n; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        newDp[j] = dp[j - 1] + 1;
                    }
                    else
                    {
                        newDp[j] = Math.Max(dp[j], newDp[j - 1]);
                    }
                }
                dp = newDp;
            }

            return dp[n];
        }