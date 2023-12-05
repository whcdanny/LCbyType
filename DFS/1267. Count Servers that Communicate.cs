//Leetcode 1267. Count Servers that Communicate med
//题意：给定一个 m x n 的矩阵 grid 表示一个服务器的布局。如果 grid[i][j] == 1，表示第 i 行和第 j 列有一个服务器。通信是双向的，即如果两台服务器位于同一行或同一列，则它们之间可以进行通信。返回能够与至少一台其他服务器进行通信的服务器的数量。
//思路：DFS, 从发现第一个1开始，横竖查，算总共个数，然后并将访问过的grid[i][j] == 1 改成 -1 表示访问过；
//时间复杂度: O(m * n) 
//空间复杂度：O(m + n)。
        public int CountServers(int[][] grid)
        {
            var server_count = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        var count = DFS_CountServers(grid, row, col);
                        if (count > 1)
                            server_count += count;
                    }
                }
            }

            return server_count;
        }

        private int DFS_CountServers(int[][] grid, int row, int col)
        {
            if (grid[row][col] == 0)
                return 0;

            var count = 1;
            grid[row][col] = -1;

            for (int i = row + 1; i < grid.GetLength(0) && grid[i][col] != -1; i++)
                count += DFS_CountServers(grid, i, col);

            for (int i = row - 1; i >= 0 && grid[i][col] != -1; i--)
                count += DFS_CountServers(grid, i, col);

            for (int i = col + 1; i < grid[row].Length && grid[row][i] != -1; i++)
                count += DFS_CountServers(grid, row, i);

            for (int i = col - 1; i >= 0 && grid[row][i] != -1; i--)
                count += DFS_CountServers(grid, row, i);

            return count;
        }