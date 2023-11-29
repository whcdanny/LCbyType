//Leetcode 2658. Maximum Number of Fish in a Grid  mid
//题意：给定一个 m x n 的二维矩阵 grid，其中每个单元格 (r, c) 表示：如果 grid[r][c] = 0，表示这是一块陆地。如果 grid[r][c] > 0，表示这是一个水域，同时包含 grid[r][c] 条鱼。一个捕鱼者可以从任意一个水域单元格(r, c) 开始，并可以执行以下操作任意次数：捕获单元格(r, c) 中的所有鱼，或者移动到任意相邻的水域单元格。要求返回捕鱼者在选择起始单元格时能够捕获到的最大鱼数，如果没有水域单元格存在则返回 0。
//思路：深度优先搜索（DFS）来解决此问题。从每个水域开始，递归地搜索相邻的水域，记录捕捉到的鱼的数量，并在递归过程中更新最大值。
//时间复杂度: O(m * n)
//空间复杂度：O(m * n)
        public int FindMaxFish(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int maxFish = 0;
            bool[,] visited = new bool[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0 && !visited[i, j])
                    {                        
                        maxFish = Math.Max(maxFish, DFS_FindMaxFish(i, j, grid, visited));
                    }
                }
            }

            return maxFish;
        }

        private int DFS_FindMaxFish(int row, int col, int[][] grid, bool[,] visited)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0 || visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;
            int currentFish = grid[row][col];

            // Explore adjacent water cells
            currentFish += DFS_FindMaxFish(row, col + 1, grid, visited);  // Right
            currentFish += DFS_FindMaxFish(row, col - 1, grid, visited);  // Left
            currentFish += DFS_FindMaxFish(row + 1, col, grid, visited);  // Down
            currentFish += DFS_FindMaxFish(row - 1, col, grid, visited);  // Up            

            return currentFish;
        }