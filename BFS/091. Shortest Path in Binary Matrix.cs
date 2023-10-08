//Leetcode 091. Shortest Path in Binary Matrix med
//题意：给定一个二进制矩阵，0表示可以通过，1表示障碍物，求从左上角到右下角的最短路径长度。
//思路：广度优先搜索（BFS）序列化： 起点加入队列，然后进行广度优先搜索，每一步都尝试向上下左右四个方向扩展，直到到达终点或者无法继续扩展为止
//时间复杂度: 矩阵大小为N x N, O(N^2)
//空间复杂度：队列中最多会存储N^2个节点, O(N^2)
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int n = grid.Length;
            if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
                return -1;
            int[][] dirs = new int[][] { new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1}, new int[] {0, -1}, new int[] {0, 1}, new int[] {1, -1}, new int[] {1, 0}, new int[] {1, 1}};
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            grid[0][0] = 1;
            int level = 1;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for(int i = 0; i < size; i++)
                {
                    int[] pos = queue.Dequeue();
                    int x = pos[0], y = pos[1];
                    if (x == n - 1 && y == n - 1)
                        return level;
                    foreach(var dir in dirs)
                    {
                        int nx = x + dir[0];
                        int ny = y + dir[1];
                        if (nx >= 0 && nx < n && ny >= 0 && ny < n && grid[nx][ny] == 0)
                        {
                            queue.Enqueue(new int[] { nx, ny });
                            grid[nx][ny] = 1;
                        }
                    }
                }
                level++;
            }
            return -1;
        }