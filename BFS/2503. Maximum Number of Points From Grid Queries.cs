//Leetcode 2503. Maximum Number of Points From Grid Queries hard
//题意：给定一个 m x n 的整数矩阵 grid 和一个大小为 k 的数组 queries。对于每个查询 queries[i]，从矩阵的左上角单元格开始执行以下过程：如果 queries[i] 严格大于当前所在单元格的值，则第一次访问该单元格时得到一个积分，并可以在四个方向（上、下、左、右）中选择任何一个方向移动。否则，不得到任何积分，结束该过程。最终，返回结果数组 answer。
//思路：我们可以使用BFS（广度优先搜索）在搜索过程中，，我们记录已经访问过的单元格，以防止重复访问。当我们找到一个不小于查询值的单元格时，我们获得一个积分，并将它加入到BFS的队列中以继续探索。
//时间复杂度: 假设矩阵的大小为 m x n，查询的数量为 k。对于每个查询，我们最坏情况下需要遍历整个矩阵，因此总的时间复杂度为 O(k * m * n)。
//空间复杂度：O(m*n)
        public int[] MaxPoints(int[][] grid, int[] queries)//超时
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                long points = 0;
                bool[,] visited = new bool[m, n];
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { 0, 0 });
                visited[0, 0] = true;
                long maxPoint = long.MinValue;
                int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    for(int j = 0; j < count; j++)
                    {
                        int[] curr = queue.Dequeue();
                        int r = curr[0];
                        int c = curr[1];
                        if ((long)grid[r][c] < (long)queries[i])
                            points ++;
                        else
                            continue;


                        foreach (int[] dir in directions)
                        {
                            int newRow = r + dir[0];
                            int newCol = c + dir[1];

                            if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol])
                            {                               
                                if ((long)grid[newRow][newCol] < (long)queries[i])
                                {
                                    visited[newRow, newCol] = true;
                                    queue.Enqueue(new int[] { newRow, newCol });
                                }
                                else
                                {
                                    maxPoint = Math.Max(maxPoint, points);
                                }
                            }
                        }
                        maxPoint = Math.Max(maxPoint, points);
                    }
                    
                }
                result[i] = maxPoint == long.MinValue? 0:(int)maxPoint;               
            }

            return result;
        }
