//Leetcode 934. Shortest Bridge med
//题意：在一个二维矩阵中，0表示海洋，1表示岛屿。两个岛屿被水隔开，求它们之间的最短桥的步数。
//思路：使用深度优先搜索（DFS）或广度优先搜索（BFS）找到第一个岛屿，标记出属于这个岛屿的所有位置。使用BFS将第一个岛屿与其他岛屿隔开的水域进行扩展，直到碰到第二个岛屿，此时的步数就是最短桥的步数。
//时间复杂度: O(N^2)，其中 N 是矩阵的边长。在最坏情况下，需要遍历整个矩阵
//空间复杂度：O(N^2)，用于存储标记岛屿的信息和BFS队列。在最坏情况下，队列的大小和矩阵大小相同。
        public int ShortestBridge(int[][] grid)
        {
            int n = grid.Length;
            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
            }

            int[][] dirs = new int[][] {
            new int[] {0, 1},
            new int[] {0, -1},
            new int[] {1, 0},
            new int[] {-1, 0}
        };

            Queue<int[]> queue = new Queue<int[]>();
            bool found = false;
            // 使用 DFS 找到第一个岛屿，并将其所有的陆地标记为访问
            for (int i = 0; i < n; i++)
            {
                if (found) break;
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        DFS_ShortestBridge(grid, visited, queue, dirs, i, j);
                        found = true;
                        break;
                    }
                }
            }
            // 使用 BFS 扩展第一个岛屿，直到找到第一个为 1 的点为止
            int steps = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] curr = queue.Dequeue();
                    int row = curr[0];
                    int col = curr[1];

                    for (int k = 0; k < 4; k++)
                    {
                        int newRow = row + dirs[k][0];
                        int newCol = col + dirs[k][1];

                        if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && !visited[newRow][newCol])
                        {
                            if (grid[newRow][newCol] == 1)
                            {
                                return steps;
                            }
                            visited[newRow][newCol] = true;
                            queue.Enqueue(new int[] { newRow, newCol });
                        }
                    }
                }
                steps++;
            }

            return -1;
        }

        private void DFS_ShortestBridge(int[][] grid, bool[][] visited, Queue<int[]> queue, int[][] dirs, int row, int col)
        {
            int n = grid.Length;
            if (row < 0 || row >= n || col < 0 || col >= n || visited[row][col] || grid[row][col] != 1)
            {
                return;
            }

            visited[row][col] = true;
            queue.Enqueue(new int[] { row, col });

            foreach (int[] dir in dirs)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                DFS_ShortestBridge(grid, visited, queue, dirs, newRow, newCol);
            }
        }