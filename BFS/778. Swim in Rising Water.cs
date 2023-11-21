//Leetcode 778. Swim in Rising Water hard
//题意：在一个N x N 的网格中，每个单元格有一个数字，表示在那个单元格中待的时间。我们每一分钟可以移动到相邻的四个单元格之一，网格外面的单元格是无法移动到的。水位每一分钟都会上升，如果一个单元格待的时间 <= 水位，那么它就是可以行走的，否则是无法行走的。我们的目标是找到一条从左上角走到右下角的路径，使得这条路径上的所有单元格待的时间都 <= 水位。
//思路：通过二分查找找到一个最小的时间值，使得从左上角到右下角存在一条路径，路径上每个单元格的值都小于等于这个最小时间值。在二分查找的过程中，我们可以通过 BFS 来检查是否存在一条可行路径。初始化二分查找的左边界 left 为网格的最小值，右边界 right 为网格的最大值。在二分查找的过程中，计算中间值 mid，表示当前尝试的时间值。使用 BFS 遍历网格，从左上角出发，看是否存在一条路径，使得路径上每个单元格的值都小于等于 mid。如果存在这样的路径，说明 mid 还可能大，将 right 更新为 mid；否则，说明 mid 太大，将 left 更新为 mid + 1。重复步骤2-4，直到 left 和 right 相等，返回 left。这样就找到了一个最小的时间值，使得存在一条可行路径。
//时间复杂度: O(N^2 * log(N^2))，其中 N 是网格的边长。因为队列中最多包含 N^2 个单元格，每次操作的时间复杂度为 log(N^2)。
 //空间复杂度：O(N^2)
        public int SwimInWater(int[][] grid)
        {
            int n = grid.Length;
            int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            int left = 0, right = n * n - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (!CanSwim(grid, mid))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private bool CanSwim(int[][] grid, int limit)
        {
            int n = grid.Length;
            bool[][] visited = new bool[n][];
            int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
            }

            Queue<int[]> queue = new Queue<int[]>();
            if (grid[0][0] <= limit)
            {
                queue.Enqueue(new int[] { 0, 0 });
                visited[0][0] = true;
            }

            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                int row = current[0], col = current[1];

                if (row == n - 1 && col == n - 1)
                {
                    return true;
                }

                foreach (int[] dir in directions)
                {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];

                    if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && !visited[newRow][newCol] && grid[newRow][newCol] <= limit)
                    {
                        queue.Enqueue(new int[] { newRow, newCol });
                        visited[newRow][newCol] = true;
                    }
                }
            }

            return false;
        }