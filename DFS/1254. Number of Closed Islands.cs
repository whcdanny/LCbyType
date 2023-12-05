//Leetcode 1254. Number of Closed Islands med
//题意：给定一个由 0 和 1 组成的矩阵 grid，其中 0 表示海洋，1 表示陆地。一个“封闭岛屿”是指这块陆地完全被水包围，并且没有连接到矩阵边界上的陆地。如果一个岛屿的边界上的格子在四个方向上都被水包围，则称这个岛屿是封闭岛屿。计算矩阵中封闭岛屿的数量。
//思路：DFS 函数用于深度优先搜索，并返回当前位置是否为封闭岛屿。在搜索过程中，将访问到的陆地标记为已访问。
//注：先把所有边界的相连的岛屿标记为不封闭，然后算内部，只要最后递归之和，四边延申到头都是水0，就是封闭岛
//时间复杂度: O(M*N)，其中 M 和 N 分别是矩阵的行数和列数。
//空间复杂度：O(M*N)
        public int ClosedIsland(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int closedIslands = 0;

            // 遍历四个边界，将与边界相连的岛屿标记为不封闭
            for (int i = 0; i < m; i++)
            {
                DFS_ClosedIsland(grid, i, 0);
                DFS_ClosedIsland(grid, i, n - 1);
            }

            for (int j = 0; j < n; j++)
            {
                DFS_ClosedIsland(grid, 0, j);
                DFS_ClosedIsland(grid, m - 1, j);
            }

            // 遍历内部，统计封闭岛屿数量
            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        closedIslands += DFS_ClosedIsland(grid, i, j) ? 1 : 0;
                    }
                }
            }

            return closedIslands;
        }

        private bool DFS_ClosedIsland(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
            {
                return false;
            }

            if (grid[i][j] == 1)
            {
                return true; // 遇到水域，不是封闭岛屿
            }

            grid[i][j] = 1; // 标记为已访问

            // 深度优先搜索四个方向
            bool top = DFS_ClosedIsland(grid, i - 1, j);
            bool bottom = DFS_ClosedIsland(grid, i + 1, j);
            bool left = DFS_ClosedIsland(grid, i, j - 1);
            bool right = DFS_ClosedIsland(grid, i, j + 1);

            // 返回当前位置是否为封闭岛屿
            return top && bottom && left && right;
        }