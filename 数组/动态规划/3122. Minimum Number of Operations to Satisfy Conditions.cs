//Leetcode 3122. Minimum Number of Operations to Satisfy Conditions med
//题目：要在二维矩阵 grid 中执行最少的操作，使得每个单元格满足以下条件：
//和下面的单元格相等：即如果单元格(i, j) 存在下方的单元格(i + 1, j)，则 grid[i][j] == grid[i + 1][j]。
//和右边的单元格不相等：即如果单元格(i, j) 存在右侧的单元格(i, j + 1)，则 grid[i][j] != grid[i][j + 1]。
//我们的目标是找到最小的操作次数，使得 grid 满足这些条件。
//思路: 动态规划
//用一个counts[][]counts[i][target] 表示将第 i 列变成值 target 时，第 i 列中等于 target 的元素数量
//dp表示每一列可以有前一个列值的不同情况，而每个可能的前一个列值可以是从 0 到 9 的整数（共 10 个值）以及一个特殊的初始值 -1，总共 11 种可能
//然后现根据原先的grid做出counts
//然后从第0列开始，给出target来找出最小的操作次数
//在查找的时候要用grid.Length - counts[col][target] 计算将当前列变为 target 所需的操作数
//时间复杂度：O(m * n * 10)
//空间复杂度：O(n * 11)
        public int MinimumOperations(int[][] grid)
        {
            //counts[i][target] 表示将第 i 列变成值 target 时，第 i 列中等于 target 的元素数量
            int[][] counts = new int[grid[0].Length][];
            int[][] dp = new int[grid[0].Length][];
            for (int i = 0; i < counts.Length; ++i)
            {
                counts[i] = new int[10];
                dp[i] = new int[11];
                Array.Fill(dp[i], -1);
            }
            //每一列中每个数字的数量
            for (int i = 0; i < grid[0].Length; ++i)
            {
                for (int j = 0; j < grid.Length; ++j)
                {
                    counts[i][grid[j][i]]++;
                }
            }
            return Solve_MinimumOperations(grid, counts, dp, 0, -1);
        }

        int Solve_MinimumOperations(int[][] grid, int[][] counts, int[][] dp, int col, int prev)
        {
            //将上一列的值设为 prev
            //当 col 等于列的总数时，说明已处理完所有列，返回操作数 0
            if (grid[0].Length == col) return 0;
            //如果 dp[col][prev +1] 中已经保存了结果，直接返回以减少计算
            if (dp[col][prev + 1] != -1)
            {
                return dp[col][prev + 1];
            }
            int res = int.MaxValue;
            //第 col 列可以取的值
            for (int target = 0; target <= 9; ++target)
            {
                //跳过与 prev 相同的 target 值，以满足列间不同的约束。
                if (target == prev) continue;
                //计算将当前列变为 target 所需的操作数
                res = Math.Min(res, Solve_MinimumOperations(grid, counts, dp, col + 1, target) + grid.Length - counts[col][target]);
            }
            return dp[col][prev + 1] = res;

        }