//Leetcode 1765. Map of Highest Peak med
//题意：给定一个isWater大小为整数的矩阵，表示陆地和水m x n单元格的地图。如果isWater[i][j] == 0，(i, j)是陆地。如果isWater[i][j] == 1，(i, j)是水。您必须按照以下规则为每个单元格分配高度：每个单元格的高度必须是非负数。如果是水，则其高度必须为0。任何两个相邻单元格的绝对高度差不得超过 1。如果一个单元格位于另一个单元格的北面、东面、南面或西面（即它们的侧面接触），则该单元格与另一个单元格相邻。找到一个高度分配，使得矩阵中的最大高度最大化。返回大小为整数的矩阵，其中是 cell的高度。如果有多个解决方案，则返回其中任何一个。heightm x nheight[i][j] (i, j)
//思路：使用BFS,根据给的先把水的坐标放入，然后根据要求依此上下左右根据当前位置的高度+1；
//时间复杂度: O(m * n)，其中 m 和 n 分别是矩阵的行数和列数
//空间复杂度：O(m * n)，其中 m 和 n 分别是矩阵的行数和列数
        public int[][] HighestPeak(int[][] isWater)
        {
            int m = isWater.Length;
            int n = isWater[0].Length;
            int[][] maxHeight = new int[m][];
            for (int i = 0; i < m; i++)
                maxHeight[i] = new int[n];
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isWater[i][j] == 1)
                        queue.Enqueue((i, j));
                    else
                        maxHeight[i][j] = -1;
                }
            }

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var currNode = queue.Dequeue();

                    for (int d = 0; d < 4; d++)
                    {
                        int x = currNode.x + dx[d];
                        int y = currNode.y + dy[d];

                        if (x < 0 || y < 0 || x >= m || y >= n || maxHeight[x][y] != -1)
                            continue;

                        maxHeight[x][y] = maxHeight[currNode.x][currNode.y] + 1;
                        queue.Enqueue((x, y));
                    }
                }
            }
            return maxHeight;
        }