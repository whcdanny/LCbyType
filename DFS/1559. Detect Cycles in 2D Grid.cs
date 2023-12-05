//Leetcode 1559. Detect Cycles in 2D Grid med
//题意：一个大小为 m x n 的字符数组 grid，需要找出是否存在由相同值组成的循环。循环是指在 grid 中长度为 4 或更长的路径，其起始点和终点位于同一个单元格。从给定的单元格开始，可以朝四个方向之一移动到相邻的单元格（上、下、左、右），如果它的值与当前单元格相同。
//思路： DFS, 遍历每个单元格，对于每个未访问的单元格，调用 DFS 进行深度优先搜索。在 DFS 中，对于每个相邻的单元格，如果该单元格已经被访问过且不是上一步访问的单元格，说明存在循环，返回 true。如果遍历完整个网格都没有找到循环，返回 false。        
//时间复杂度: O(m * n)，其中 m 是行数，n 是列数，每个单元格最多被访问一次。
//空间复杂度：O(m * n)，用于存储 visited 数组。
        public bool ContainsCycle(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            bool[,] visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        if (DFS_ContainsCycle(grid, row, col, -1, -1, visited))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool DFS_ContainsCycle(char[][] grid, int row, int col, int parentRow, int parentCol, bool[,] visited)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return false;
            }

            if (visited[row, col])
            {
                return true; // 检测到循环
            }

            visited[row, col] = true;

            int[][] directions = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow == parentRow && newCol == parentCol)
                {
                    continue; // 不访问上一步访问过的单元格
                }

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == grid[row][col])
                {
                    if (DFS_ContainsCycle(grid, newRow, newCol, row, col, visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }