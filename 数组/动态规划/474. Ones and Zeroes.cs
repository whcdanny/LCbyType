//Leetcode 474. Ones and Zeroes med
//题意：给定一个由二进制字符串组成的数组 strs 和两个整数 m 和 n。
//返回可以满足以下条件的最大子集的大小：
//子集中最多包含 m 个 0 和 n 个 1。
//注意：一个集合 x 是集合 y 的子集，当且仅当 x 的所有元素都在 y 中。
//思路：动态规划（Dynamic Programming） 的经典背包问题变种。
//状态定义：使用一个三维数组 dp[i][j]表示：使用最多i个0和j个1时，可以形成的最大子集大小。
//转移方程：如果当前字符串的0和1数量分别为 zeros 和 ones：
//如果不选当前字符串，dp[i][j] = dp[i][j]。
//如果选当前字符串，dp[i][j] = max(dp[i][j], dp[i - zeros][j - ones] + 1)。
//时间复杂度:  O(l×k+l×m×n)
//空间复杂度： O(m×n)
        public int FindMaxForm(string[] strs, int m, int n)
        {
            // 定义二维数组用于动态规划
            int[,] dp = new int[m + 1, n + 1];

            foreach (var str in strs)
            {
                int zeros = str.Count(c => c == '0');
                int ones = str.Length - zeros;

                // 倒序更新以避免状态覆盖
                for (int i = m; i >= zeros; i--)
                {
                    for (int j = n; j >= ones; j--)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
                    }
                }
            }

            return dp[m, n];
        }