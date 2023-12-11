//Leetcode 695. Max Area of Island med
//题意：给你一个m x n二进制矩阵grid。岛屿是一组4 个方向（水平或垂直）1连接的 '（代表陆地） 。您可以假设网格的所有四个边缘都被水包围。岛屿的面积是岛上具有值的像元的数量。1返回中岛屿的最大面积grid。如果没有岛屿，则返回0。
//思路：DFS）问题。我们需要遍历整个地图，对于每个陆地单元格，以该单元格为起点进行深度优先搜索，将属于同一个岛屿的陆地单元格标记，并计算岛屿的面积。在遍历的过程中，记录最大岛屿面积。
//时间复杂度: 每个陆地单元格最多访问一次，因此时间复杂度为 O(N)，其中 N 为地图中的陆地单元格个数。
//空间复杂度：在递归的过程中，由于是深度优先搜索，递归调用栈的最大深度为地图中的陆地单元格个数，因此空间复杂度为 O(N)。
        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxArea = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        maxArea = Math.Max(maxArea, DFS_MaxAreaOfIsland(grid, i, j));
                    }
                }
            }
            return maxArea;
        }

        private int DFS_MaxAreaOfIsland(int[][] grid, int row, int col)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0)
            {
                return 0;
            }

            grid[row][col] = 0; // 标记当前陆地单元格为已访问

            int area = 1;
            area += DFS_MaxAreaOfIsland(grid, row - 1, col); // 上
            area += DFS_MaxAreaOfIsland(grid, row + 1, col); // 下
            area += DFS_MaxAreaOfIsland(grid, row, col - 1); // 左
            area += DFS_MaxAreaOfIsland(grid, row, col + 1); // 右

            return area;
        }