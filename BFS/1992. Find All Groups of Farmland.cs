//Leetcode 1992. Find All Groups of Farmland med
//题意：给定一个m x n的地块矩阵land，其中land[i][j]是0表示水域，是1表示农田。农田是由相邻的1形成的一片连续区域。请找出所有的农田区域, 并给出起始点（左上角）和终点（右下角）。
//思路：使用 BFS（广度优先搜索），从（0，0）开始找值为1的，然后做BFS，直到这个农田结束，然后把起始点（左上角）和终点（右下角）存下来；
//时间复杂度: O(r*c)
//空间复杂度：O(r*c)
        public int[][] FindFarmland(int[][] land)
        {

            List<int[]> result = new List<int[]>();
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            List<int[]> directions = new List<int[]>{ new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

            for (int row = 0; row < land.Length; row++)
            {
                for (int col = 0; col < land[row].Length; col++)
                {
                    if (land[row][col] == 1 && !visited.Contains((row, col)))
                    {
                        queue.Enqueue((row, col));
                        List<int[]> farm = new List<int[]>();

                        while (queue.Any())
                        {
                            var item = queue.Dequeue();
                            visited.Add((row, col));
                            farm.Add(new int[] { item.row, item.col });

                            foreach (var direction in directions)
                            {
                                int newRow = direction[0] + item.row;
                                int newCol = direction[1] + item.col;

                                if (newRow >= 0 && newRow < land.Length && newCol >= 0 && newCol < land[0].Length
                                && !visited.Contains((newRow, newCol)) && land[newRow][newCol] == 1)
                                {
                                    visited.Add((newRow, newCol));
                                    queue.Enqueue((newRow, newCol));
                                }
                            }
                        }
                        if (farm.Count > 0)
                        {
                            int[] begin = farm.FirstOrDefault();
                            int[] end = farm.LastOrDefault();
                            result.Add(new int[] { begin[0], begin[1], end[0], end[1] });
                        }

                    }
                }
            }
            return result.ToArray();
        }