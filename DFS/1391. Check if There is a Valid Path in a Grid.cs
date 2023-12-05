//Leetcode 1391. Check if There is a Valid Path in a Grid  med
//题意：您将获得一个m x n grid. 的每个单元格grid代表一条街道。的街道grid[i][j]可以是：1这意味着连接左侧单元格和右侧单元格的街道。2这意味着连接上层单元和下层单元的街道。3这意味着连接左侧单元格和下方单元格的街道。4这意味着连接右侧单元格和下方单元格的街道。5这意味着连接左侧单元格和上部单元格的街道。6这意味着连接右侧单元格和上部单元格的街道。true如果网格中存在有效路径则返回，false否则返回。
//思路： （DFS）遍历网格。对于每个单元格，判断当前街道的类型，然后判断下一个单元格是否可以访问。递归遍历下一个单元格，并标记当前单元格为已访问。
//注：根据不同情况路线，分别考虑两个口的方向；
//时间复杂度: O(m * n)，其中 m 和 n 分别是网格的行数和列数，每个单元格只遍历一次。
//空间复杂度：O(m * n)
        public bool HasValidPath(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visited = new bool[m, n];
            return DFS_HasValidPath(grid, 0, 0, m, n, visited);
        }

        private bool DFS_HasValidPath(int[][] grid, int i, int j, int m, int n, bool[,] visited)
        {
            if (i == m - 1 && j == n - 1)
            {
                return true; // 到达右下角单元格，找到有效路径
            }

            if (i < 0 || i >= m || j < 0 || j >= n || visited[i, j])
            {
                return false; // 越界或已访问过，返回 false
            }

            visited[i, j] = true; // 标记当前单元格为已访问

            int street = grid[i][j];
            
            bool nextCellValid = false;
            if (street == 1)
            {
                if (j + 1 < n && (grid[i][j + 1] == 1 || grid[i][j + 1] == 3 || grid[i][j + 1] == 5) && !visited[i, j + 1])
                {                   
                    nextCellValid |= DFS_HasValidPath(grid, i, j + 1, m, n, visited);                    
                }
                if (j - 1 >= 0 && (grid[i][j - 1] == 1 || grid[i][j - 1] == 4 || grid[i][j - 1] == 6) && !visited[i, j - 1])
                {                   
                    nextCellValid |= DFS_HasValidPath(grid, i, j - 1, m, n, visited);                    
                }                
            }
            if (street == 2)
            {
                if (i + 1 < m && (grid[i + 1][j] == 2 || grid[i + 1][j] == 5 || grid[i + 1][j] == 6) && !visited[i + 1, j])
                {                   
                    nextCellValid |= DFS_HasValidPath(grid, i + 1, j, m, n, visited);
                }
                if (i - 1 >= 0 && (grid[i - 1][j] == 2 || grid[i - 1][j] == 3 || grid[i - 1][j] == 4) && !visited[i - 1, j])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i - 1, j, m, n, visited);
                }
            }
            if (street == 3)
            {
                if (i + 1 < m && (grid[i + 1][j] == 2 || grid[i + 1][j] == 5 || grid[i + 1][j] == 6) && !visited[i + 1, j])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i + 1, j, m, n, visited);
                }
                if (j - 1 >= 0 && (grid[i][j - 1] == 1 || grid[i][j - 1] == 4 || grid[i][j - 1] == 6) && !visited[i, j - 1])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i, j - 1, m, n, visited);
                }
            }
            if (street == 4)
            {
                if (i + 1 < m && (grid[i + 1][j] == 2 || grid[i + 1][j] == 5 || grid[i + 1][j] == 6) && !visited[i + 1, j])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i + 1, j, m, n, visited);
                }
                if (j + 1 < n && (grid[i][j + 1] == 1 || grid[i][j + 1] == 3 || grid[i][j + 1] == 5) && !visited[i, j + 1])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i, j + 1, m, n, visited);
                }
            }
            if (street == 5)
            {
                if (i - 1 >= 0 && (grid[i - 1][j] == 2 || grid[i - 1][j] == 3 || grid[i - 1][j] == 4) && !visited[i - 1, j])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i - 1, j, m, n, visited);
                }
                if (j - 1 >= 0 && (grid[i][j - 1] == 1 || grid[i][j - 1] == 4 || grid[i][j - 1] == 6) && !visited[i, j - 1])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i, j - 1, m, n, visited);
                }
            }
            if (street == 6)
            {
                if (i - 1 >= 0 && (grid[i - 1][j] == 2 || grid[i - 1][j] == 3 || grid[i - 1][j] == 4) && !visited[i - 1, j])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i - 1, j, m, n, visited);
                }
                if (j + 1 < n && (grid[i][j + 1] == 1 || grid[i][j + 1] == 3 || grid[i][j + 1] == 5) && !visited[i, j + 1])
                {
                    nextCellValid |= DFS_HasValidPath(grid, i, j + 1,m, n, visited);
                }
            }            
            return nextCellValid; // 不能前往下一个单元格，返回 false
        }