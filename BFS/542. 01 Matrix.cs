//Leetcode 542. 01 Matrix med
//题意：给定一个由 0 和 1 组成的矩阵，其中 1 表示陆地，0 表示海洋。矩阵中的每个单元格都与其相邻的四个单元格上、下、左、右相连。要求计算每个单元格到最近的 0 的距离，并以矩阵的形式返回。
//思路：广度优先搜索（BFS）序列化： 所有的 0 加入队列中，然后从每个 0 开始向四周进行扩散，每次距离加一。这样，最先被访问到的 1，其距离就是最小的
//时间复杂度: 矩阵中共有 n 个元素, O(n)
//空间复杂度：O(n)
        public int[][] UpdateMatrix(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int[][] res = new int[m][];


            for(int i = 0; i < m; i++)
            {
                res[i] = new int[n];
                //无穷大或未知的值。将其减去 10000 是为了避免在计算过程中发生溢出
                Array.Fill(res[i], int.MaxValue - 10000);
            }

            Queue<int[]> queue = new Queue<int[]>();
            for(int i = 0; i < m; i++)
            {
                for(int j=0; j < n; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        //如果是0，则将这个原本无限大的数改成0；
                        res[i][j] = 0;
                        queue.Enqueue(new int[] { i, j });
                    }
                }
            }
            int[][] dirs = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            while (queue.Count > 0)
            {
                int[] point = queue.Dequeue();
                int x = point[0], y = point[1];
                foreach(var dir in dirs)
                {
                    int newx = x + dir[0];
                    int newy = y + dir[1];
                    if (newx >= 0 && newx < m && newy >= 0 && newy < n)
                    {
                        if (res[newx][newy] > res[x][y] + 1)
                        {
                            res[newx][newy] = res[x][y] + 1;
                            queue.Enqueue(new int[] { newx, newy });
                        }
                    }
                }
            }
            return res;
        }