//Leetcode 2596. Check Knight Tour Configuration med
//题意：题目描述了一个国际象棋棋盘上的骑士游走问题。给定一个 n x n 的整数矩阵 grid，其中每个元素表示骑士访问的顺序编号，要求判断该访问顺序是否符合骑士的规则。
//骑士每次移动的规则是：要么向上或向下移动两格，再向左或向右移动一格；要么向左或向右移动两格，再向上或向下移动一格。
//思路：DBS，从0，0开始按照骑士可以走的每个方向走，如果步数和当前grid的格子value相对应，就往下走，直到走完。
//时间复杂度: O(8^(n^2))
//空间复杂度：O(n^2)
        public bool CheckValidGrid(int[][] grid)
        {
            int n = grid.Length;
            int[] dr = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dc = { 1, 2, 2, 1, -1, -2, -2, -1 };
            bool[,] visited = new bool[n, n];            
            return DFS_CheckValidGrid(0, 0, 0, n, dr, dc, visited, grid);
        }
        bool DFS_CheckValidGrid(int row, int col, int count, int n, int[] dr, int[] dc, bool[,] visited, int[][] grid)
        {
            if (row < 0 || row >= n || col < 0 || col >= n || visited[row, col] || grid[row][col]!=count)
            {
                return false;
            }

            visited[row, col] = true;

            if (count == n * n - 1)
            {
                return true;
            }

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if (DFS_CheckValidGrid(newRow, newCol, count + 1, n, dr, dc, visited, grid))
                {
                    return true;
                }
            }
            
            return false;
        }