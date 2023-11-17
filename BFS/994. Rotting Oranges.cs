//Leetcode 994. Rotting Oranges med
//题意：在一个二维网格上，每个单元格可以是空白（0）、新鲜橘子（1）或腐烂的橘子（2）。腐烂的橘子会以每分钟的速度传播，每个新鲜橘子会被腐烂橘子相邻的四个方向的腐烂橘子感染。要求计算腐烂橘子将全部橘子变腐烂的最短时间。
//思路：BFS（广度优先搜索）将所有腐烂的橘子加入队列，并用一个二维数组表示橘子状态。然后，从队列中取出腐烂的橘子，依次感染新鲜橘子，并将被感染的新鲜橘子加入队列。重复这个过程，直到队列为空。最后，检查是否还有新鲜橘子，如果有，说明有些橘子无法被感染，返回-1；否则，返回感染所有橘子所需的分钟数。
//时间复杂度:  行数为 m，列数为 n，最坏情况下，所有的橘子都需要遍历一次。因此，时间复杂度为 O(mn)。
//空间复杂度：取决于队列的大小，最坏情况下可能需要存储所有的橘子。因此，空间复杂度为 O(mn)。
        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            Queue<(int,int)> queue = new Queue<(int,int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            // 将所有腐烂的橘子入队
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i,j));
                        visited.Add((i, j));
                    }
                }
            }

            List<int[]> directions = new List<int[]> { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            int minutes = 0;

            // 使用广度优先搜索进行遍历
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for(int i = 0; i < count; i++)
                {
                    (int row, int col) = queue.Dequeue();

                    foreach (var dir in directions)
                    {
                        int newRow = row + dir[0];
                        int newCol = col + dir[1];

                        if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1 && !visited.Contains((newRow, newCol)))
                        {
                            grid[newRow][newCol] = 2; // 将新鲜橘子变为腐烂
                            queue.Enqueue((newRow, newCol));
                        }
                    }
                }
                if(queue.Count> 0)
                    minutes++;
            }

            // 检查是否还有新鲜橘子
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1; // 存在新鲜橘子，返回-1
                    }
                }
            }

            return minutes;
        }

        public int OrangesRotting1(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            Queue<int[]> queue = new Queue<int[]>();

            // 将所有腐烂的橘子入队
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue(new int[] { i, j, 0 }); // 第三个元素表示经过的时间
                    }
                }
            }

            int[][] directions = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

            int minutes = 0;

            // 使用广度优先搜索进行遍历
            while (queue.Count > 0)
            {
                int[] point = queue.Dequeue();
                int row = point[0];
                int col = point[1];
                minutes = point[2];

                foreach (int[] dir in directions)
                {
                    int newRow = row + dir[0];
                    int newCol = col + dir[1];

                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1)
                    {
                        grid[newRow][newCol] = 2; // 将新鲜橘子变为腐烂
                        queue.Enqueue(new int[] { newRow, newCol, minutes + 1 });
                    }
                }
            }

            // 检查是否还有新鲜橘子
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1; // 存在新鲜橘子，返回-1
                    }
                }
            }

            return minutes;
        }