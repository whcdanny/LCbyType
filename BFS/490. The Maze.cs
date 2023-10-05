//Leetcode 490. The Maze med
//题意：给定一个迷宫，迷宫中有空格和墙壁，球可以向上、下、左、右四个方向滚动。迷宫中还有两个特殊位置：起始位置和目标位置。球可以从起始位置开始滚动，一直滚到它无法再滚动为止。求球是否可以到达目标位置。迷宫用一个二维数组表示，0 表示空格，1 表示墙壁。球可以滚动到相邻的空格，但无法穿越墙壁。当球滚到某个位置时，它会停留在那里，除非它选择再次滚动。
//思路：广度优先搜索（BFS）序列化： 在每一步中，我们将球从当前位置向四个方向滚动，直到它无法再滚动为止。我们将这些新的位置添加到队列中，并将它们标记为已访问。
//时间复杂度:  n 是行数，m 是列数 O(nm)
//空间复杂度：O(nm)
		public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            int m = maze.Length;
            int n = maze[0].Length;
            int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            bool[][] visited = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(start);
            visited[start[0]][start[1]] = true;
            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                if (current[0] == destination[0] && current[1] == destination[1])
                {
                    return true;
                }
                foreach (int[] dir in directions)
                {
                    int newRow = current[0] + dir[0];
                    int newCol = current[1] + dir[1];
                    while (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && maze[newRow][newCol] == 0)
                    {
                        newRow += dir[0];
                        newCol += dir[1];
                    }
                    newRow -= dir[0];
                    newCol -= dir[1];
                    if (!visited[newRow][newCol])
                    {
                        queue.Enqueue(new int[] { newRow, newCol });
                        visited[newRow][newCol] = true;
                    }
                }
            }
            return false;
        }