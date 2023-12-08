//Leetcode 1020. Number of Enclaves med = 1254
//题意：给定一个二维数组 A，其中 0 表示海洋， 1 表示陆地。陆地上的 1 形成一个或多个岛屿，通过水平或垂直连接。我们称一个岛屿为「离岸不远的陆地」，如果这个岛屿内部的所有格子都在其边界上的某个水平或垂直方向上相邻的另一个岛屿上。可以执行以下操作：任何小岛都可以通过填充水来连接到另一个小岛，而不远离陆地。返回可以填充水的小岛的数量。
//思路：DFS（深度优先搜索）将与边界相连的陆地标记为已访问。然后遍历整个矩阵，将未被标记为已访问的陆地翻转为海洋。最后，再次遍历边界上的陆地，标记与边界相连的陆地为已访问。最终，未被标记为已访问的陆地就是无法通过翻转到达边界的陆地，统计其数量即可。
//注：只要把四边的做查是否为陆地，然后DFS， 这样所有跟边界连接的陆地都改为了0，然后只要再查一边就知道有多少陆地了；
//时间复杂度:  O(m * n)，其中 m 和 n 分别为数组的行数和列数
//空间复杂度： O(m * n)，其中 m 和 n 分别为数组的行数和列数       
        public int NumEnclaves(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            // Mark connected land cells with boundary as visited
            for (int i = 0; i < m; i++)
            {
                DFS_NumEnclaves(grid, i, 0);
                DFS_NumEnclaves(grid, i, n - 1);
            }

            for (int j = 0; j < n; j++)
            {
                DFS_NumEnclaves(grid, 0, j);
                DFS_NumEnclaves(grid, m - 1, j);
            }

            // Count the remaining unvisited land cells
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS_NumEnclaves(int[][] grid, int row, int col)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == 0)
                return;

            grid[row][col] = 0; // Mark the land cell as visited

            // Explore adjacent land cells
            DFS_NumEnclaves(grid, row + 1, col);
            DFS_NumEnclaves(grid, row - 1, col);
            DFS_NumEnclaves(grid, row, col + 1);
            DFS_NumEnclaves(grid, row, col - 1);
        }