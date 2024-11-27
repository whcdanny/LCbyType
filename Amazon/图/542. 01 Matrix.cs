//Leetcode 542. 01 Matrix med
//题意：给定一个由 0 和 1 组成的矩阵 mat，其中 0 表示陆地，1 表示水域。
//矩阵中的每个单元格都与其相邻的上、下、左、右四个方向上的单元格相邻，且环绕陆地的水域。请找到每个单元格到离它最近的水域的距离。
//思路：广度优先搜索（BFS）问题。
//我们可以通过 BFS 从每个水域出发，向四个方向扩展，计算每个陆地单元格到最近的水域的距离。
//先把所有水域0的存入， result[i][j] = 0;，并将0的位置存入queue.Enqueue(new int[] { i, j });
//然后从每个0开始查找1的位置，并result[nx][ny] = result[x][y] + 1; queue.Enqueue(new int[] { nx, ny });
//时间复杂度: 由于每个单元格只会入队一次，出队一次，因此 BFS 过程的时间复杂度为 O(m * n)，其中 m 和 n 分别是矩阵的行数和列数。
//空间复杂度：O(m * n)
        public int[][] UpdateMatrix(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int[][] result = new int[m][];

            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = -1; // 初始化为 -1 表示未访问过
                }
            }

            Queue<int[]> queue = new Queue<int[]>();

            // 将水域的位置加入队列，并标记距离为 0
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j });
                        result[i][j] = 0;
                    }
                }
            }

            // 四个方向的偏移量，上、右、下、左
            int[] dirs = { -1, 0, 1, 0, -1 };

            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                int x = curr[0];
                int y = curr[1];

                // 向四个方向扩展
                for (int d = 0; d < 4; d++)
                {
                    int nx = x + dirs[d];
                    int ny = y + dirs[d + 1];

                    // 判断相邻的单元格是否在矩阵范围内且未被访问过
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && result[nx][ny] == -1)
                    {
                        result[nx][ny] = result[x][y] + 1;
                        queue.Enqueue(new int[] { nx, ny });
                    }
                }
            }

            return result;
        }