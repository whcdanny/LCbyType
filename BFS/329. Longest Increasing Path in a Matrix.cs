//Leetcode 329. Longest Increasing Path in a Matrix hard
//题意：给给定一个包含非负整数的 m x n 网格，其中每个整数表示该位置的海拔高度。规定水的高度必须由更高的地方流向较低的地方，并且可以沿着上、下、左、右四个方向流动。找到能够使水流向地势最低的地方的位置，并计算水的体积。
//思路：(BFS)从每个位置开始找最长增长路线；但是内存爆了
//时间复杂度: O(rows * cols * log(rows * cols))。。
//空间复杂度：O(rows * cols)
        public int LongestIncreasingPath(int[][] matrix)//内存爆了
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            
            int maxPath = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    maxPath = Math.Max(maxPath, BFS_LongestIncreasingPath(matrix, i, j));
                }
            }

            return maxPath;

        }

        private int BFS_LongestIncreasingPath(int[][] matrix, int row, int col)
        {
            int val = matrix[row][col];
            Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
            HashSet<(int, int, int)> visited = new HashSet<(int, int, int)>();
            int res = 0;
            queue.Enqueue((row, col, 0));
            visited.Add((row, col, 0));
            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };            
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for(int i = 0; i < count; i++)
                {
                    (int r, int c, int step) = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        int newR = r + dir[0];
                        int newC = c + dir[1];
                        if (newR >= 0 && newR < matrix.Length && newC >= 0 && newC < matrix[0].Length && matrix[newR][newC] > matrix[r][c] && !visited.Contains((newR, newC, step)))
                        {
                            queue.Enqueue((newR, newC, step+1));
                            visited.Add((newR, newC, step+1));
                        }
                    }                    
                }
                res++;
            }
            return res;
        }