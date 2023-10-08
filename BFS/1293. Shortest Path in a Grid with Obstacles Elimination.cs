//Leetcode 1293. Shortest Path in a Grid with Obstacles Elimination hard
//题意：给定一个包含障碍物的网格地图，以及一个指定的障碍物消除数量 k，求从起始位置到目标位置的最短路径长度。可以移动的方向为上、下、左、右。
//思路：在搜索过程中，需要考虑障碍物的消除情况，并保持一个队列来存储待访问的节点。在搜索过程中，每次遇到障碍物时，需要判断是否还有剩余的障碍物消除次数，如果有，则可以继续前进；如果没有，则无法通过该路径。
//时间复杂度: V 表示节点数，E 表示边数 O(V + E)
//空间复杂度： O(V)
        public int ShortestPath(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int res = 0;

            int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0, k });
            HashSet<string> visited = new HashSet<string>();
            visited.Add("0,0," + k);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for(int i=0; i<size; i++)
                {
                    int[] cur = queue.Dequeue();
                    int x = cur[0];
                    int y = cur[1];
                    int remainingObstacles = cur[2];

                    if (x == m - 1 && y == n - 1)
                        return res;

                    foreach(var dir in dirs)
                    {
                        int newx = x + dir[0];
                        int newy = y + dir[1];
                        if (newx >= 0 && newx < m && newy >= 0 && newy < n)
                        {
                            int newRemainingObstacles = remainingObstacles - grid[newx][newy];
                            if (newRemainingObstacles >= 0 && !visited.Contains(newx + "," + newy + "," + newRemainingObstacles))
                            {
                                queue.Enqueue(new int[] { newx, newy, newRemainingObstacles });
                                visited.Add(newx + "," + newy + "," + newRemainingObstacles);
                            }
                        }
                    }
                }
                res++;
            }
            return -1;
        }