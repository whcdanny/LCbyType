//Leetcode 1162. As Far from Land as Possible med
//题意：给定一个大小为 N x N 的二进制矩阵 grid，其中 grid[i][j] 是 1 或 0。每一条从左上角到右下角的对角线上的所有元素都被认为是一条岛屿。请找出给定矩阵中最远的岛屿距离。如果没有岛屿，则返回 -1。
//思路：BFS（广度优先搜索）来查找每个岛屿到其他陆地的最短距离，并记录最远距离。，一次查一整个queue，确保所以1开始的一直保持同步，直到没有发现新的水；
//时间复杂度: O(N^2)，其中 N 是矩阵的边长。
//空间复杂度：O(N^2)，其中 N 是矩阵的边长。
        public int MaxDistance(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int maxDistance = 0;

            Queue<int[]> queue = new Queue<int[]>();

            // Add all land cells to the queue and mark them as visited
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue(new int[] { i, j });
                        grid[i][j] = -1; // Mark as visited
                    }
                }
            }

            // If there are no land cells or water cells, return -1
            if (queue.Count == 0 || queue.Count == rows * cols)
            {
                return -1;
            }

            int[][] directions = { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            // Perform BFS to find the maximum distance
            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int[] cell = queue.Dequeue();

                    foreach (var dir in directions)
                    {
                        int newRow = cell[0] + dir[0];
                        int newCol = cell[1] + dir[1];

                        if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 0)
                        {
                            queue.Enqueue(new int[] { newRow, newCol });
                            grid[newRow][newCol] = -1; // Mark as visited
                        }
                    }
                }

                if (queue.Count > 0)
                {
                    maxDistance++;
                }
            }

            return maxDistance;
        }