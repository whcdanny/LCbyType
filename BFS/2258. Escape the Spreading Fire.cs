//Leetcode 2258. Escape the Spreading Fire hard
//题意：给定一个 m x n 的矩阵 grid，表示一个场地。每个单元格有以下三种值：0 表示草地1 表示火2 表示墙，你和火都不能通过你初始位置在左上角单元格(0, 0)，目标是到达右下角单元格(m - 1, n - 1) 的安全屋。每分钟，你可以移动到相邻的草地单元格。你的移动后，火会扩散到所有不是墙的相邻单元格。返回你可以在原地停留的最大分钟数，同时仍然安全地到达安全屋。如果这是不可能的，请返回 -1。如果无论停留多少分钟，你都可以安全到达安全屋，返回 10^9。
//思路：1-“使用BFS计算从人到安全屋的步数，以及从任何火灾到安全屋的最近距离。火灾距离和人步数-1之间的差异就是我们的答案。”2-“比较两个相邻（到安全屋）单元格的差异。如果任何相邻单元格的差异较大，那么我们不需要减一。”如果火灾的步数数组的第一个元素为零，则意味着火灾从未到达安全屋（因为火灾无法从安全屋开始）。如果该数字对于person的步数数组不为零，那么无论停留分钟数如何，我们总能到达安全屋
//时间复杂度: 假设地图的大小是 m x n，初始火源的数量是 k。在最坏的情况下，我们需要遍历整个地图，因此时间复杂度是 O(m * n)。
//空间复杂度：我们需要维护一个队列来存储火源的位置，队列的大小不会超过 m * n，因此空间复杂度是 O(m * n)。同时，我们还需要一个矩阵来记录单元格是否已经被访问过，其大小也是 m x n，因此空间复杂度也是 O(m * n)。总的空间复杂度是 O(m * n)。
        static int[][] DIRS = new int[][]{new int[]{0, 1},new int[]{1, 0}, new int[]{0, -1}, new int[]{-1, 0}};
        public int MaximumMinutes(int[][] grid)
        {
            Queue<(int, int)> fire = new Queue<(int, int)>();
            Queue<(int, int)> person = new Queue<(int, int)>();
            person.Enqueue((0, 0));            

            for (int i = 0; i < grid.Length; ++i)
                for (int j = 0; j < grid[0].Length; ++j)
                    if (grid[i][j] == 1)
                        fire.Enqueue((i,j));

            int[] stepsFire = BFS_MaximumMinutes(grid, fire), stepsPerson = BFS_MaximumMinutes(grid, person);
            if (stepsFire[0] == 0 && stepsPerson[0] != 0)
                return 1000000000;
            int diff = stepsFire[0] - stepsPerson[0];
            if (stepsPerson[0] != 0 && diff >= 0)
            {
                int sub = (stepsFire[1] - stepsPerson[1] <= diff && stepsFire[2] - stepsPerson[2] <= diff) ? 1 : 0;
                return diff - sub;
            }
            return -1;
        }

        private int[] BFS_MaximumMinutes(int[][] grid, Queue<(int, int)> pos)
        {
            int[] steps = new int[3];
            int m = grid.Length, n = grid[0].Length;
            int[,] st = new int[m, n];
            while (pos.Count > 0)
            {
                (int x, int y) = pos.Dequeue();
                foreach (int[] dir in DIRS)
                {
                    int nx = x + dir[0], ny = y + dir[1];
                    if (Math.Min(nx, ny) >= 0 && nx < m && ny < n && grid[nx][ny] == 0 && st[nx, ny] == 0)
                    {
                        st[nx, ny] = st[x, y] + 1;
                        pos.Enqueue((nx, ny));
                    }
                }
            }
            steps[0] = st[m - 1, n - 1];
            steps[1] = st[m - 2, n - 1];
            steps[2] = st[m - 1, n - 2];
            return steps;
        }