//Leetcode 417. Pacific Atlantic Water Flow med
//题意：给定一个二维矩阵，表示一个地形高度图。太平洋位于左上角和右下角，大西洋位于右上角和左下角。水可以从高度相同或更低的地方流动，但不能向高处流动。求出哪些位置的水可以同时流动到太平洋和大西洋。
//思路：从太平洋和大西洋的边界开始，分别进行两次BFS，分别标记能够到达的位置,遍历整个矩阵，找出同时能够到达两个洋的位置
//时间复杂度: V 表示节点数，E 表示边数 O(V + E)
//空间复杂度： O(V)
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            if (heights == null || heights.Length == 0 || heights[0].Length == 0) return new List<IList<int>>();

            int m = heights.Length;
            int n = heights[0].Length;

            bool[,] canReachPacific = new bool[m, n];
            bool[,] canReachAtlantic = new bool[m, n];
            Queue<(int, int)> pacificQueue = new Queue<(int, int)>();
            Queue<(int, int)> atlanticQueue = new Queue<(int, int)>();

            for(int i=0; i < m; i++)
            {
                pacificQueue.Enqueue((i, 0));
                atlanticQueue.Enqueue((i, n-1));               
                canReachPacific[i, 0] = true;
                canReachAtlantic[i, n-1] = true;
            }
            for(int i = 0; i < n; i++)
            {
                pacificQueue.Enqueue((0, i));
                atlanticQueue.Enqueue((m-1, i));
                canReachPacific[0, i] = true;
                canReachAtlantic[m-1, i] = true;
            }

            BFS_PacificAtlantic(heights, canReachPacific, pacificQueue);
            BFS_PacificAtlantic(heights, canReachAtlantic, atlanticQueue);

            IList<IList<int>> res = new List<IList<int>>();
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (canReachAtlantic[i, j] && canReachPacific[i, j])
                        res.Add(new List<int> { i,j});
                }
            }
            return res;
        }

        private void BFS_PacificAtlantic(int[][] matrix, bool[,] canReach, Queue<(int, int)> queue)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newx = x + dx[i];
                    int newy = y + dy[i];
                    if (newx >= 0 && newx < m  && newy >= 0 && newy < n && !canReach[newx, newy] && matrix[newx][newy] >= matrix[x][y])
                    {
                        canReach[newx,newy] = true;
                        queue.Enqueue((newx, newy));
                    }
                }
            }
        }