//Leetcode 695. Max Area of Island med
//题意：给你一个m x n二进制矩阵grid。岛屿是一组4 个方向（水平或垂直）1连接的 '（代表陆地） 。您可以假设网格的所有四个边缘都被水包围。岛屿的面积是岛上具有值的像元的数量。1返回中岛屿的最大面积grid。如果没有岛屿，则返回0。
//思路：广度优先搜索 (BFS) 来遍历每个岛屿，并计算其面积。对于每个遍历到的岛屿，我们使用 BFS 进行探索，同时标记已访问过的单元格，以避免重复计算。
//时间复杂度: O(m * n)，其中 m 是网格的行数，n 是网格的列数
//空间复杂度：最坏情况下队列的空间复杂度是 O(min(m, n))，因为队列的大小不会超过较小的行数或列数。此外，我们也修改了输入的网格，将已访问的岛屿单元格的值标记为 0，这不需要额外的空间。
        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxArea = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        maxArea = Math.Max(maxArea, BFS_MaxAreaOfIsland(grid, i, j));
                    }
                }
            }

            return maxArea;
        }

        private int BFS_MaxAreaOfIsland(int[][] grid, int startX, int startY)
        {
            int area = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { startX, startY });
            grid[startX][startY] = 0;

            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                int x = current[0];
                int y = current[1];
                area++;

                // Explore neighboring cells in four directions
                Explore(grid, queue, x + 1, y);
                Explore(grid, queue, x - 1, y);
                Explore(grid, queue, x, y + 1);
                Explore(grid, queue, x, y - 1);
            }

            return area;
        }

        private void Explore(int[][] grid, Queue<int[]> queue, int x, int y)
        {
            if (x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length && grid[x][y] == 1)
            {
                queue.Enqueue(new int[] { x, y });
                grid[x][y] = 0;  // Mark the current cell as visited
            }
        }