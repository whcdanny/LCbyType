//Leetcode 1905. Count Sub Islands med
//题意：这个问题给定两个 m x n 的二进制矩阵 grid1 和 grid2，其中只包含 0（代表水）和 1（代表陆地）。一个岛屿是由 1 组成的、在4个方向（水平或垂直）上相连的一组单元格。矩阵之外的任何单元格都被视为水单元格。
//在 grid2 中的岛屿被认为是 grid1 中包含了 grid2 中该岛屿的所有单元格的子岛屿。    
//返回 grid2 中被认为是子岛屿的岛屿数量。
//思路：DFS, 遍历 grid2 中的每个单元格，如果是陆地（值为1），则进行深度优先搜索（DFS）来检查是否构成了一个子岛屿。在DFS中，同时检查当前在 grid2 中的岛屿单元格是否对应 grid1 中的相应单元格也是陆地。统计满足条件的子岛屿数量。
//注：在历遍grid2的时候发现0，那么就停止DFS，因为我们只要找跟grid1的land，所以在grid1就看是不是land；
//时间复杂度: O(m * n)，其中 m 和 n 分别是矩阵的行数和列数。因为每个单元格只被访问一次。
//空间复杂度：O(m * n)，递归调用的深度最多为 m * n，因此空间复杂度是递归栈的最大深度。
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int m = grid1.Length;
            int n = grid1[0].Length;
            int result = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Check if the current cell in grid2 is part of an island
                    if (grid2[i][j] == 1)
                    {
                        bool isSubIsland = DFS_CountSubIslands(grid1, grid2, i, j, m, n);
                        if (isSubIsland)
                        {
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        private bool DFS_CountSubIslands(int[][] grid1, int[][] grid2, int row, int col, int m, int n)
        {            
            //如果超过边界，和 grid2当前为0就停止；
            if (row < 0 || row >= m || col < 0 || col >= n || grid2[row][col] == 0)
            {
                return true;
            }

            //如果访问过来改成0；
            grid2[row][col] = 0;
            
            bool isSubIsland = grid1[row][col] == 1;

            // Explore in all four directions
            isSubIsland &= DFS_CountSubIslands(grid1, grid2, row + 1, col, m, n);
            isSubIsland &= DFS_CountSubIslands(grid1, grid2, row - 1, col, m, n);
            isSubIsland &= DFS_CountSubIslands(grid1, grid2, row, col + 1, m, n);
            isSubIsland &= DFS_CountSubIslands(grid1, grid2, row, col - 1, m, n);

            return isSubIsland;
        }