//Leetcode 200. Number of Islands med 
//题意：给定一个由 '1'（陆地）和 '0'（水）组成的二维网格地图，计算岛屿的数量。岛屿被水包围，并且通过水平方向或垂直方向相邻时被认为是同一岛屿。可以假设网格的四个边均被水包围。
//思路：深度优先搜索（DFS）来解决。具体思路如下：遍历整个二维网格，对于每个 '1'（陆地），进行深度优先搜索，将与之相连的所有 '1' 标记为已访问过。在深度优先搜索中，递归地将当前位置的上、下、左、右四个相邻位置标记为已访问。统计深度优先搜索的次数，即为岛屿的数量。
//时间复杂度: 网格大小为 m×n,O(m*n)
//空间复杂度：递归调用的最大深度取决于岛屿的数量，因此空间复杂度为 O(min(m, n))
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            int rows = grid.Length;
            int cols = grid[0].Length;
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DFS(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS_NumIslands(char[][] grid, int row, int col)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == '0')
            {
                return;
            }

            grid[row][col] = '0'; // 标记为已访问

            // 递归访问上、下、左、右四个相邻位置
            DFS_NumIslands(grid, row - 1, col);
            DFS_NumIslands(grid, row + 1, col);
            DFS_NumIslands(grid, row, col - 1);
            DFS_NumIslands(grid, row, col + 1);
        }