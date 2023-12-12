//Leetcode 463. Island Perimeter ez
//题意：给定一个由0和1组成的二维网格，1表示陆地，0表示水域。网格中的单元格是通过水平或垂直连接的，不会有对角线。整个网格被水完全包围，但其中可能有一些陆地。
//每一块陆地单元格都有四条边，即顶部、底部、左侧和右侧。周长是指陆地单元格与水域单元格（或网格边界）的边界长度之和。计算并返回网格中所有陆地单元格的周长。
//思路：深度优先搜索（DFS）深度优先搜索遍历整个网格，对于每个陆地单元格，递归地计算其四个方向上的周长贡献，并标记已访问的陆地单元格。最终，将所有陆地单元格的周长贡献相加即可得到总周长。
//注：只要有连着水的就+1；        
//时间复杂度: O(m * n)，其中m和n分别为网格的行数和列数
//空间复杂度：O(m * n)的空间
        public int IslandPerimeter(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int perimeter = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        perimeter += DFS_IslandPerimeter(grid, i, j);
                    }
                }
            }

            return perimeter;
        }

        private int DFS_IslandPerimeter(int[][] grid, int row, int col)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0)
            {
                return 1; // 边界或水域的贡献
            }

            if (grid[row][col] == -1)
            {
                return 0; // 已访问过的陆地单元格
            }

            grid[row][col] = -1; // 标记为已访问

            int perimeter = 0;
            perimeter += DFS_IslandPerimeter(grid, row + 1, col);
            perimeter += DFS_IslandPerimeter(grid, row - 1, col);
            perimeter += DFS_IslandPerimeter(grid, row, col + 1);
            perimeter += DFS_IslandPerimeter(grid, row, col - 1);

            return perimeter;
        }