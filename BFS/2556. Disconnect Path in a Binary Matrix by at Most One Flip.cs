//Leetcode 2556. Disconnect Path in a Binary Matrix by at Most One Flip med
//题意：给定一个 m x n 的二进制矩阵 grid，其中 1 表示可以通过，0 表示无法通过。从单元格 (row, col) 可以移动到相邻的单元格 (row+1, col) 或 (row, col+1)。如果从(0, 0) 无法到达(m-1, n-1)，则称矩阵为不连通的。你可以翻转最多一个单元格的值（也可能一个都不翻转）。但不能翻转单元格(0, 0) 和(m-1, n-1)。如果可以使矩阵变得不连通，返回 true，否则返回 false。注意，翻转一个单元格会改变它的值，从 0 变成 1，或者从 1 变成 0。
//思路：我们可以使用BFS（广度优先搜索）在搜索过程中，将可以到达的单元格标记为已访问，并将它们加入队列中。在搜索结束后，检查终点(m-1, n-1) 是否被访问过，如果被访问过则说明存在路径，否则说明矩阵不连通。如果矩阵不连通，尝试翻转一个单元格，然后重新进行一次广度优先搜索，看是否可以找到路径。
//时间复杂度: O(m*n)，其中 m 和 n 分别为矩阵的行数和列数
//空间复杂度：O(m*n)
        public bool CanDisconnect(int[][] grid)//超时
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visited = new bool[m, n];
            int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            visited[0, 0] = true;

            while (queue.Count > 0)
            {
                int[] cell = queue.Dequeue();
                int row = cell[0];
                int col = cell[1];

                foreach (int[] dir in directions)
                {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];
                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol] && grid[newRow][newCol] == 1)
                    {
                        queue.Enqueue(new int[] { newRow, newCol });
                        visited[newRow, newCol] = true;
                    }
                }
            }

            if (!visited[m - 1, n - 1])
            {
                return true;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 && j == 0) || i==m-1&&j==n-1)
                        continue;
                    if (grid[i][j] == 1)
                    {
                        grid[i][j] = 0;
                        visited = new bool[m, n];
                        queue.Clear();
                        queue.Enqueue(new int[] { 0, 0 });
                        visited[0, 0] = true;

                        while (queue.Count > 0)
                        {
                            int[] cell = queue.Dequeue();
                            int row = cell[0];
                            int col = cell[1];

                            foreach (int[] dir in directions)
                            {
                                int newRow = row + dir[0];
                                int newCol = col + dir[1];
                                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol] && grid[newRow][newCol] == 1)
                                {
                                    queue.Enqueue(new int[] { newRow, newCol });
                                    visited[newRow, newCol] = true;
                                }
                            }
                        }

                        if (!visited[m - 1, n - 1])
                        {
                            return true;
                        }

                        grid[i][j] = 1;
                    }
                }
            }

            return false;
        }