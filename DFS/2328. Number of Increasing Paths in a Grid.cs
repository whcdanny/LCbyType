//Leetcode 2328. Number of Increasing Paths in a Grid hard
//题意：给定一个 m x n 的整数矩阵 grid，你可以在所有4个方向上从一个单元格移动到相邻的任何单元格。返回在矩阵中有多少条严格递增的路径，使得你可以从任何单元格开始并结束于任何单元格。由于答案可能非常大，返回对 10^9 + 7 取模的结果。两条路径被认为是不同的，如果它们的访问单元格序列不完全相同。 
//思路：深度优先搜索 (DFS) 的方式, 用memo存 避免重复操作；
//注：MOD_CountPaths = 1000000007；
//时间复杂度: O(m * n)，其中 m 和 n 分别是矩阵的行数和列数，因为我们需要遍历每个单元格一次
//空间复杂度：O(m * n)，用于存储递归调用的结果。
        private static readonly int MOD_CountPaths = 1000000007;

        public int CountPaths(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[,] memo = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    memo[i, j] = -1;
                }
            }

            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result = (result + DFS_CountPaths(grid, m, n, i, j, memo)) % MOD_CountPaths;
                }
            }

            return result;
        }

        private int DFS_CountPaths(int[][] grid, int m, int n, int i, int j, int[,] memo)
        {
            if (memo[i, j] != -1)
            {
                return memo[i, j];
            }

            int result = 1;
            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            foreach (var dir in directions)
            {
                int ni = i + dir[0];
                int nj = j + dir[1];

                if (ni >= 0 && ni < m && nj >= 0 && nj < n && grid[ni][nj] > grid[i][j])
                {
                    result = (result + DFS_CountPaths(grid, m, n, ni, nj, memo)) % MOD_CountPaths;
                }
            }

            memo[i, j] = result;
            return result;
        }