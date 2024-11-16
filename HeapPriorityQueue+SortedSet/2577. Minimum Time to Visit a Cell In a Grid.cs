//Leetcode 2577. Minimum Time to Visit a Cell In a Grid  med
//题意：给定一个 m x n 的矩阵 grid，矩阵中的每个元素 grid[row][col] 表示访问单元格(row, col) 所需的最小时间。
//这意味着只有当您访问它的时间大于或等于 grid[row][col] 时，才能访问单元格(row, col)。
//您从矩阵的左上角开始，初始时间为 0 秒，必须向四个方向之一移动：上、下、左、右。您每进行一次移动，花费 1 秒的时间。
//返回访问矩阵右下角单元格所需的最小时间。如果无法访问右下角单元格，则返回 -1。        
//思路：PriorityQueue+BFS 
//建立一个priorityQueue存入(到达时间，row，colum)，然后用BFS，然后往上下左右动，
//注：不能原地等待，所以要做一个判断，来发现拖延的话，所以要用到%2 偶数就是返回走一次，奇数就是原地踏步
//时间复杂度: BFS遍历整棵树需要O(n)的时间，其中n是树中节点的数量。计算层次和并存储在字典中需要O(n)的空间。查找第k大的层次和需要O(nlogn)的时间（在字典中找到最大的k个层次和）。
//空间复杂度：O(n)        
        private readonly List<(int, int)> dir_MinimumTime = new List<(int, int)> { (0, 1), (0, -1), (1, 0), (-1, 0) };

        public int MinimumTime(int[][] grid)
        {
            if (grid[0][1] > 1 && grid[1][0] > 1) return -1;

            int m = grid.Length, n = grid[0].Length;
            int[,] arrival = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arrival[i, j] = -1;
                }
            }

            PriorityQueue<(int, int, int), int> pq = new PriorityQueue<(int, int, int), int>();
            if (grid[0][1] <= 1) pq.Enqueue((1, 0, 1), 1);
            if (grid[1][0] <= 1) pq.Enqueue((1, 1, 0), 1);

            while (pq.Count > 0)
            {
                var current = pq.Dequeue();
                int t = current.Item1;
                int x = current.Item2;
                int y = current.Item3;

                if (arrival[x, y] != -1) continue;

                arrival[x, y] = t;

                if (x == m - 1 && y == n - 1) break;

                foreach (var d in dir_MinimumTime)
                {
                    int i = x + d.Item1;
                    int j = y + d.Item2;
                    if (i < 0 || i >= m || j < 0 || j >= n) continue;
                    if (arrival[i, j] != -1) continue;
                    //走一步就到下一个位置；
                    if (grid[i][j] <= t + 1)
                    {
                        pq.Enqueue((t + 1, i, j), t + 1);
                    }
                    //就是要等的，那么拖延时间是偶数倍数，所以用%2，相当于原地回到上一个格子，所以要+1步，
                    else if ((grid[i][j] - t) % 2 == 0)
                    {
                        pq.Enqueue((grid[i][j] + 1, i, j), grid[i][j] + 1);
                    }
                    //就是要等的，那么拖延时间是奇数倍数，所以相当于原地踏步 所以可以继续走，
                    else
                    {
                        pq.Enqueue((grid[i][j], i, j), grid[i][j]);
                    }
                }
            }

            return arrival[m - 1, n - 1];
        }