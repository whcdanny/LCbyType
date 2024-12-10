//Leetcode 840. Magic Squares In Grid med
//题意：一个 3×3 的魔方阵是一个 3×3 的网格，网格中填充了 1 到 9 的不重复整数，
//并且每行、每列和两条对角线的数字之和都相等。
//给定一个大小为row×col 的整数网格 grid，求其中有多少个 3×3 的子网格是魔方阵。
//注意：魔方阵只能包含 1 到 9 之间的数字。
//grid 中的数字可以是任意整数（可能超过 9 或小于 1）。
//思路：枚举所有 3×3 的子网格遍历 grid 中所有可能的 3×3 子网格，检查是否满足魔方阵的条件。
//检查是否为魔方阵的条件3×3 的网格需要满足以下几个条件：
//包含的所有数字在 1 到 9 之间。数字互不重复。
//每行、每列和两条对角线的数字和相等。
//优化检查逻辑
//使用一个数组记录数字出现次数，快速验证数字范围和唯一性。
//计算行、列和对角线和时，避免重复计算。
//时间复杂度:  O(row×col)
//空间复杂度： O(1)
        public int NumMagicSquaresInside(int[][] grid)
        {
            int row = grid.Length, col = grid[0].Length;
            int count = 0;

            // 遍历所有可能的 3x3 子网格
            for (int i = 0; i <= row - 3; i++)
            {
                for (int j = 0; j <= col - 3; j++)
                {
                    if (IsMagic(grid, i, j))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        private bool IsMagic(int[][] grid, int r, int c)
        {
            // 检查是否只包含 1 到 9 的数字，且不重复
            bool[] seen = new bool[10];
            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    int val = grid[i][j];
                    if (val < 1 || val > 9 || seen[val])
                    {
                        return false;
                    }
                    seen[val] = true;
                }
            }

            // 检查每行、每列、对角线是否相等
            int sum = grid[r][c] + grid[r][c + 1] + grid[r][c + 2]; // 第一行的和
            for (int i = 0; i < 3; i++)
            {
                // 检查每行
                if (grid[r + i][c] + grid[r + i][c + 1] + grid[r + i][c + 2] != sum)
                {
                    return false;
                }
                // 检查每列
                if (grid[r][c + i] + grid[r + 1][c + i] + grid[r + 2][c + i] != sum)
                {
                    return false;
                }
            }

            // 检查两条对角线
            if (grid[r][c] + grid[r + 1][c + 1] + grid[r + 2][c + 2] != sum ||
                grid[r][c + 2] + grid[r + 1][c + 1] + grid[r + 2][c] != sum)
            {
                return false;
            }

            return true;
        }