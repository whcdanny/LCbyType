//Leetcode 1568. Minimum Number of Days to Disconnect Island hard
//题意：给你一个m x n二进制网格grid，其中1代表土地，0代表水。岛是最大4 个方向（水平或垂直）连接的组。如果我们只有一个岛屿，则称电网已连接，否则称电网已断开。有一天，我们可以将任何一个陆地单元(1)变成水单元(0)。返回断开电网的最小天数。
//思路： DFS, 使用 CountIslands 函数检查当前网格中是否只有一个岛屿。如果是，则网格是“连接的”，直接返回0天。然后，尝试断开每一个陆地单元格，再次检查是否仍然存在一个岛屿。如果断开任何一个单元格后不再存在一个岛屿，返回1天。如果尝试断开任何一个单元格都无法断开，返回2天。
//注：因为想要让一个岛被分为两个，最多两天，因为要让岛单独分开就只需要把最边缘的1，左和上或下，右和上或下。所以最多就是2天；
//时间复杂度: O(rows * cols * (rows * cols)), 每个单元格尝试断开的过程中都需要进行一次 DFS 检查是否存在岛屿，DFS 的时间复杂度为 O(rows * cols)。
//空间复杂度：O(rows * cols)，用于存储 visited 数组。
        public int MinDays(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int islandsCount = CountIslands(grid);
            if (islandsCount != 1)
            {
                return 0; // 如果已经是断开的，返回0天
            }

            // 尝试断开每个陆地单元格，并检查是否仍然存在一个岛屿
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        grid[row][col] = 0;
                        int newIslandsCount = CountIslands(grid);
                        if (newIslandsCount != 1)
                        {
                            return 1; // 如果断开后不再存在一个岛屿，返回1天
                        }
                        grid[row][col] = 1; // 恢复原状，尝试下一个单元格
                    }
                }
            }

            return 2; // 如果尝试断开任何一个单元格都无法断开，返回2天
        }

        private int CountIslands(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int count = 0;

            bool[,] visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    //如果还有1没有被访问就证明这里有一个岛；
                    if (grid[row][col] == 1 && !visited[row, col])
                    {
                        DFS_MinDays(grid, row, col, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS_MinDays(int[][] grid, int row, int col, bool[,] visited)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == 0 || visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            int[][] directions = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                DFS_MinDays(grid, newRow, newCol, visited);
            }
        }