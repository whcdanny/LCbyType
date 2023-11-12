//Leetcode 1926. Nearest Exit from Entrance in Maze med
//题意：你有一个 m x n 的迷宫，你需要找到迷宫入口 (entrance) 到达任意位置的最近出口。迷宫的出口 由一个字符表示。迷宫每次只能向上、下、左、右四个方向移动，且不能穿过墙壁。当你移动到一个位置后，迷宫中所有的墙壁和你当前的位置会同时改变。请注意，你只能在迷宫出口出去，无法在迷宫入口处离开。如果入口无法到达任何出口，请返回 -1。
//思路：使用BFS（方法isPathExists）找到离入口最近的出口。首先，从入口开始进行 BFS 遍历，将每个节点与它的距离存储在 distances 数组中。在遍历的过程中，判断是否到达了迷宫的出口，如果是则更新最终结果。
//时间复杂度: O(m * n)，其中 m 和 n 分别为迷宫的行数和列数。
//空间复杂度：O(m * n)，用于存储距离信息。
        public int NearestExit(char[][] maze, int[] entrance)
        {
            int m = maze.Length;
            int n = maze[0].Length;
            int[] directions = { -1, 0, 1, 0, -1 };
            int[,] distances = new int[m, n];

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { entrance[0], entrance[1] });

            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                int x = current[0], y = current[1];

                for (int k = 0; k < 4; k++)
                {
                    int nx = x + directions[k];
                    int ny = y + directions[k + 1];

                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && maze[nx][ny] == '.' && distances[nx, ny] == 0)
                    {
                        distances[nx, ny] = distances[x, y] + 1;
                        queue.Enqueue(new int[] { nx, ny });

                        if ((nx == 0 || nx == m - 1 || ny == 0 || ny == n - 1) && !(nx == entrance[0] && ny == entrance[1]))
                        {
                            return distances[nx, ny];
                        }
                    }
                }
            }

            return -1;
        }