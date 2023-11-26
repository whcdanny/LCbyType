//Leetcode 463. Island Perimeter ez
//题意：给定一个二维网格，其中 1 表示陆地，0 表示水域。网格中的每个单元格与其相邻的四个方向上的单元格相邻。求岛屿的周长，假设所有边界外部均为水域。
//思路：(BFS)，我们可以遍历整个二维网格，对于每个陆地单元格，计算它的周长。岛屿的周长等于陆地单元格的数量乘以4，再减去相邻的陆地单元格的数量乘以2。这是因为相邻的两个陆地单元格会共享一条边。
//时间复杂度: O(m * n) 的时间，其中 m 和 n 分别是网格的行数和列数
//空间复杂度：O(1)
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
                        perimeter += 4;

                        if (i > 0 && grid[i - 1][j] == 1)
                        {
                            perimeter -= 2;
                        }

                        if (j > 0 && grid[i][j - 1] == 1)
                        {
                            perimeter -= 2;
                        }
                    }
                }
            }

            return perimeter;
        }