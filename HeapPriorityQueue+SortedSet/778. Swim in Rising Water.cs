//Leetcode 778. Swim in Rising Water hard
//题意：在一个N x N 的网格中，每个单元格有一个数字，表示在那个单元格中待的时间。
//我们每一分钟可以移动到相邻的四个单元格之一，网格外面的单元格是无法移动到的。
//水位每一分钟都会上升，如果一个单元格待的时间 <= 水位，那么它就是可以行走的，否则是无法行走的。
//我们的目标是找到一条从左上角走到右下角的路径，使得这条路径上的所有单元格待的时间都 <= 水位。
//思路：PriorityQueue
//时间复杂度: O(N^2 * log(N^2))，其中 N 是网格的边长。因为队列中最多包含 N^2 个单元格，每次操作的时间复杂度为 log(N^2)。
//空间复杂度：O(N^2)       
        public int SwimInWater(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            int result = grid[0][0];
            pq.Enqueue((0, 0), result);
            bool[,] visited = new bool[m, n];
            int[][] directions = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            while (pq.Count != 0)
            {
                if (pq.TryDequeue(out var item, out result))
                {
                    if (visited[item.Item1, item.Item2]) 
                        continue;
                    visited[item.Item1, item.Item2] = true;
                    if (item == (m - 1, n - 1)) 
                        return result;
                    foreach (var direction in directions)
                    {
                        int x = direction[0] + item.Item1;
                        int y = direction[1] + item.Item2;
                        int newDiff = 0;
                        if (x >= 0 && y >= 0 && x < m && y < n && visited[x, y] == false)
                        {
                            newDiff = Math.Max(result, grid[x][y]);
                            pq.Enqueue((x, y), newDiff);
                        }
                    }
                }
            }
            return result;
        }