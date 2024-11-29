//Leetcode 62. Unique Paths med
//题意：网格上有一个机器人m x n。机器人最初位于左上角（即grid[0][0]）。
//机器人尝试移动到右下角（即grid[m - 1][n - 1]）。机器人在任何时间点只能向下或向右移动。
//给定两个整数m和n，返回机器人到达右下角可以采取的可能唯一路径的数量。
//生成测试用例的目的是使得答案小于或等于。2 * 109
//思路：动态规划，dp从[0,0]到[i,j]的可能路径
//然后从[1,1]开始，每个位置向下或向右移动，所以可以是 memo[i][j] = memo[i - 1][j] + memo[i][j - 1];
//时间复杂度：O(n*m)
//空间复杂度：O(n*m) 
        public int UniquePaths(int m, int n)
        {
            int[][] memo = new int[m + 1][];
            for (int i = 0; i <= m; i++)
            {
                memo[i] = new int[n + 1];
                Array.Fill(memo[i], 1);
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    memo[i][j] = memo[i - 1][j] + memo[i][j - 1];
                }
            }

            return memo[m - 1][n - 1];
        }
        public int UniquePaths1(int m, int n)
        {
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {
                dp[0, j] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }