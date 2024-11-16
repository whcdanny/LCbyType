//Leetcode 2290. Minimum Obstacle Removal to Reach Corner hard
//题意：给定一个大小为 m x n 的二维整数数组 grid，数组中的每个单元格都有以下两个值：
//0 表示一个空单元格，
//1 表示一个障碍物，可以被移除。
//你可以从一个空单元格向上、向下、向左或向右移动。
//返回移除的障碍物的最小数量，以便你可以从左上角(0, 0) 移动到右下角(m - 1, n - 1)。
//思路：PriorityQueue + BFS 从左上角的单元格 (0, 0) 开始，向四个方向进行搜索，每次搜索时记录所经过的空单元格和障碍物数量。
//我们使用一个优先队列（Priority Queue）来记录每次搜索的状态，其中优先级是当前经过的障碍物数量。这样可以保证我们先搜索移除障碍物最少的路径。
//时间复杂度: O(m * n)
//空间复杂度：O(m * n)
        public int MinimumObstacles(int[][] grid)
        {
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            PriorityQueue<(int row, int col, int obs), int> q = new PriorityQueue<(int, int, int), int>();
            q.Enqueue((0, 0, 0), grid[0][0]);
            while (q.Count > 0)
            {
                int r = q.Peek().row;
                int c = q.Peek().col;
                int obs = q.Peek().obs;
                q.Dequeue();

                if (r == grid.Length - 1 && c == grid[0].Length - 1)
                {
                    return obs;
                }
                if (!visited[r, c])
                {
                    visited[r, c] = true;
                    if (grid[r][c] == 1)
                    {
                        obs = obs + 1;
                    }
                    if (r - 1 >= 0)
                    {
                        q.Enqueue((r - 1, c, obs), obs);
                    }
                    if (r + 1 <= grid.Length - 1)
                    {
                        q.Enqueue((r + 1, c, obs), obs);
                    }
                    if (c - 1 >= 0)
                    {
                        q.Enqueue((r, c - 1, obs), obs);
                    }
                    if (c + 1 <= grid[0].Length - 1)
                    {
                        q.Enqueue((r, c + 1, obs), obs);
                    }
                }
            }
            return 0;
        }