//Leetcode 934. Shortest Bridge med
//题意：在一个二维矩阵中，0表示海洋，1表示岛屿。两个岛屿被水隔开，求它们之间的最短桥的步数。
//思路：使用深度优先搜索（DFS）或广度优先搜索（BFS）找到第一个岛屿，标记出属于这个岛屿的所有位置。使用BFS将第一个岛屿与其他岛屿隔开的水域进行扩展，直到碰到第二个岛屿，此时的步数就是最短桥的步数。
//时间复杂度: O(N^2)，其中 N 是矩阵的边长。在最坏情况下，需要遍历整个矩阵
//空间复杂度：O(N^2)，用于存储标记岛屿的信息和BFS队列。在最坏情况下，队列的大小和矩阵大小相同。
        public int ShortestBridge(int[][] grid)
        {
            int n = grid.Length;

            // 使用队列记录第一个岛屿的位置，并将岛屿标记为2
            bool found = false;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            for (int i = 0; i < n; i++)
            {
                if (found) break;
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        //DFS(grid, i, j, queue);
                        Queue<(int, int)> temp = new Queue<(int, int)>();
                        grid[i][j] = 2;
                        temp.Enqueue((i, j));
                        queue.Enqueue((i, j));
                        while (temp.Count > 0)
                        {
                            (int row, int col) = temp.Dequeue();
                            for (int d = 0; d < 4; d++)
                            {
                                int newRow = row + dirs[d][0];
                                int newCol = col + dirs[d][1];
                                if (newRow < 0 || newRow >= n || newCol < 0 || newCol >= n || grid[newRow][newCol] != 1)
                                    continue;
                                grid[newRow][newCol] = 2;
                                queue.Enqueue((newRow, newCol));
                                temp.Enqueue((newRow, newCol));
                            }
                        }
                        found = true;
                        break;
                    }
                }
            }

            //  使用BFS扩展第一个岛屿，并在遇到1时返回步数
            
            int steps = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var cell = queue.Dequeue();
                    int row = cell.Item1;
                    int col = cell.Item2;

                    for (int d = 0; d < 4; d++)
                    {
                        int newRow = row + dirs[d][0];
                        int newCol = col + dirs[d][1];

                        if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n)
                        {
                            if (grid[newRow][newCol] == 2)
                            {
                                continue;
                            }
                            else if (grid[newRow][newCol] == 1)
                            {
                                return steps;
                            }
                            else
                            {
                                grid[newRow][newCol] = 2;
                                queue.Enqueue((newRow, newCol));
                            }
                        }
                    }
                }

                steps++;
            }

            return -1; // 如果没找到第二个岛屿
        }

        private void DFS(int[][] grid, int row, int col, Queue<(int, int)> queue)
        {
            int n = grid.Length;
            if (row < 0 || row >= n || col < 0 || col >= n || grid[row][col] != 1)
            {
                return;
            }

            grid[row][col] = 2;  // 标记为2表示已访问
            queue.Enqueue((row, col));

            DFS(grid, row - 1, col, queue);
            DFS(grid, row + 1, col, queue);
            DFS(grid, row, col - 1, queue);
            DFS(grid, row, col + 1, queue);
        }