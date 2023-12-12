//Leetcode 417. Pacific Atlantic Water Flow med
//题意：给定一个二维矩阵，表示一个地形高度图。太平洋位于左上角和右下角，大西洋位于右上角和左下角。水可以从高度相同或更低的地方流动，但不能向高处流动。求出哪些位置的水可以同时流动到太平洋和大西洋。
//思路：从太平洋和大西洋的边界开始，分别进行两次DFS，分别标记能够到达的位置,遍历整个矩阵，找出同时能够到达两个洋的位置
//时间复杂度: V 表示节点数，E 表示边数 O(V + E)
//空间复杂度：V 表示节点数，E 表示边数 O(V + E)
        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return result;
            }

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            bool[,] canReachPacific = new bool[rows, cols];
            bool[,] canReachAtlantic = new bool[rows, cols];

            // 从太平洋边界出发进行DFS
            for (int i = 0; i < rows; i++)
            {
                DFS_PacificAtlantic(matrix, canReachPacific, i, 0);
            }
            for (int j = 0; j < cols; j++)
            {
                DFS_PacificAtlantic(matrix, canReachPacific, 0, j);
            }

            // 从大西洋边界出发进行DFS
            for (int i = 0; i < rows; i++)
            {
                DFS_PacificAtlantic(matrix, canReachAtlantic, i, cols - 1);
            }
            for (int j = 0; j < cols; j++)
            {
                DFS_PacificAtlantic(matrix, canReachAtlantic, rows - 1, j);
            }

            // 找出同时能够到达太平洋和大西洋的位置
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (canReachPacific[i, j] && canReachAtlantic[i, j])
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }

            return result;
        }

        private void DFS_PacificAtlantic(int[][] matrix, bool[,] canReach, int row, int col)
        {
            if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[0].Length || canReach[row, col])
            {
                return;
            }

            canReach[row, col] = true;

            int[] dirs = { -1, 0, 1, 0, -1 };
            for (int d = 0; d < 4; d++)
            {
                int newRow = row + dirs[d];
                int newCol = col + dirs[d + 1];

                if (newRow >= 0 && newRow < matrix.Length && newCol >= 0 && newCol < matrix[0].Length&& matrix[newRow][newCol] >= matrix[row][col])
                {
                    DFS_PacificAtlantic(matrix, canReach, newRow, newCol);
                }
            }
        }