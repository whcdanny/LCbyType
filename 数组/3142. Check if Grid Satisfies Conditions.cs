//Leetcode 3142. Check if Grid Satisfies Conditions ez
//题目：给定一个大小为 
//m×n 的二维矩阵 grid，要求检查以下条件是否对矩阵中的每个单元格都成立：
//每个单元格 grid[i][j] 与其下方的单元格 grid[i + 1][j] 值相等（如果存在下方单元格）。
//每个单元格 grid[i][j] 与其右侧的单元格 grid[i][j + 1] 值不同（如果存在右侧单元格）。
//如果所有单元格都满足以上条件，返回 true；否则，返回 false。
//思路: 遍历整个矩阵，对每个单元格检查其与下方及右侧单元格的值是否满足题目条件：
//如果下方单元格存在，则检查 grid[i][j] == grid[i + 1][j]。
//如果右侧单元格存在，则检查 grid[i][j] != grid[i][j + 1]。
//如果找到不满足条件的单元格，立即返回 false。
//如果遍历结束后所有单元格都满足条件，则返回 true。
//时间复杂度：O(m×n)
//空间复杂度：O(1)
        public bool SatisfiesConditions(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // 检查与下方单元格是否相等
                    if (i + 1 < m && grid[i][j] != grid[i + 1][j])
                    {
                        return false;
                    }

                    // 检查与右侧单元格是否不同
                    if (j + 1 < n && grid[i][j] == grid[i][j + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }