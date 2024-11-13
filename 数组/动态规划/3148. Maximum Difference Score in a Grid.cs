//Leetcode 3148. Maximum Difference Score in a Grid med
//题目：给定一个 m x n 的矩阵 grid，矩阵中的每个单元格包含一个正整数值。
//在矩阵中，你可以从当前单元格移动到向右或者向下的任意一个单元格（不一定是相邻的单元格）。
//一个移动的得分定义为从值为 c1 的单元格移动到值为 c2 的单元格的得分为 c2 - c1。
//要求：
//可以从矩阵中的任意单元格开始，并且必须至少进行一次移动。
//计算从某个单元格出发可以获得的最大得分。
//思路: 动态规划
//二维数组 dp 用于记录从当前位置 (i, j) 到矩阵右下角 (m-1, n-1) 的最大值
//dp 数组最后保存的是从每个位置向右或向下延伸到达的最大值。
//遍历每个单元格 (i, j)：
//如果能向下走，则计算从(i, j) 到(i+1, j) 的分值，并更新结果 ans。
//如果能向右走，则计算从(i, j) 到(i, j+1) 的分值，并更新结果 ans。
//相当于用dp找出每个位置向右或者下能达到的最大值，
//然后c2 - c1和ans做比较；
//时间复杂度：O(m * n)
//空间复杂度：O(m * n)
        public int MaxScore1(IList<IList<int>> grid)
        {
            int m = grid.Count;
            int n = grid[0].Count;
            //记录从当前位置 (i, j) 到矩阵右下角 (m-1, n-1) 的最大值
            int[][] dp = new int[m][];

            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = int.MinValue;
                }
            }

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i < m - 1)
                    {
                        //如果可以向下走，则 dp[i][j] 更新为 dp[i + 1][j] 和自身最大值。
                        dp[i][j] = Math.Max(dp[i][j], dp[i + 1][j]);
                    }

                    if (j < n - 1)
                    {
                        //如果可以向右走，则 dp[i][j] 更新为 dp[i][j +1] 和自身最大值。
                        dp[i][j] = Math.Max(dp[i][j], dp[i][j + 1]);
                    }
                    //最后将 dp[i][j] 与 grid[i][j] 的值进行比较，记录其中的较大值
                    dp[i][j] = Math.Max(dp[i][j], grid[i][j]);
                }
            }

            int ans = int.MinValue;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < m - 1)
                    {
                        //向下走
                        ans = Math.Max(ans, dp[i + 1][j] - grid[i][j]);
                    }

                    if (j < n - 1)
                    {
                        //向右走
                        ans = Math.Max(ans, dp[i][j + 1] - grid[i][j]);
                    }
                }
            }
            return ans;
        }