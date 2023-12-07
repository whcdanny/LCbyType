//Leetcode 1034. Coloring A Border med
//题意：给定一个m x n的整数矩阵grid，以及三个整数row、col和color。矩阵中每个位置的值表示该位置的方格的颜色。如果两个方格在4个方向上相邻，则它们被称为相邻方格。
//如果两个方格具有相同的颜色且它们相邻，则它们属于同一个连通组件。
//连通组件的边界是该组件中所有方格，这些方格要么与不在组件中的方格相邻，要么位于网格的边界（第一行、最后一行、第一列或最后一列）。
//你需要用颜色来填充包含方格grid[row][col] 的连通组件的边界。返回最终的矩阵。
//思路：DFS, DFS（深度优先搜索）来找到与给定位置（row，col）相同颜色的连通组件。在DFS的过程中，记录组件内的方格以及与组件相邻的方格。对于每个与组件相邻的方格，检查其是否属于不同的连通组件，或者是否在网格的边界上。如果是，将当前方格标记为组件的边界。
//时间复杂度: O(m * n)，其中m和n分别是矩阵的行数和列数
//空间复杂度：O(m * n)
        public int[][] ColorBorder(int[][] grid, int row, int col, int color)
        {

            int m = grid.Length;
            int n = grid[0].Length;
            int givenColor = grid[row][col];
            bool[,] visited = new bool[m, n];
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
                res[i] = new int[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    res[i][j] = grid[i][j];
            }
            DFS_ColorBorder(grid, row, col, givenColor, color, visited, res);
            return res;
        }
        
        public void DFS_ColorBorder(int[][] grid, int row, int col, int givenColor, int color, bool[,] visited, int[][] res)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (row < 0 || col < 0 || row >= m || col >= n) return;
            if (grid[row][col] == givenColor && !visited[row, col])
            {
                visited[row, col] = true;
                if ((row == 0 || col == 0 || row == m - 1 || col == n - 1))
                {
                    res[row][col] = color;
                }
                else if (row - 1 >= 0 && !(grid[row - 1][col] == givenColor))
                    res[row][col] = color;
                else if (row + 1 <= m - 1 && !(grid[row + 1][col] == givenColor))
                    res[row][col] = color;
                else if (col - 1 >= 0 && !(grid[row][col - 1] == givenColor))
                    res[row][col] = color;
                else if (col + 1 <= n - 1 && !(grid[row][col + 1] == givenColor))
                    res[row][col] = color;

                DFS_ColorBorder(grid, row - 1, col, givenColor, color, visited, res);
                DFS_ColorBorder(grid, row + 1, col, givenColor, color, visited, res);
                DFS_ColorBorder(grid, row, col - 1, givenColor, color, visited, res);
                DFS_ColorBorder(grid, row, col + 1, givenColor, color, visited, res);
            }
        }