//Leetcode 2596. Check Knight Tour Configuration med
//题意：题目描述了一个国际象棋棋盘上的骑士游走问题。给定一个 n x n 的整数矩阵 grid，其中每个元素表示骑士访问的顺序编号，要求判断该访问顺序是否符合骑士的规则。骑士每次移动的规则是：要么向上或向下移动两格，再向左或向右移动一格；要么向左或向右移动两格，再向上或向下移动一格。
//思路：广度优先搜索（BFS）遍历树，我们需要检查每个相邻的位置是否符合骑士的移动规则。如果不符合，就返回 false。
//时间复杂度: O(n^2)
//空间复杂度：O(1)
        public bool CheckValidGrid(int[][] grid)
        {
            int n = grid.Length;
            int[] dr = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] dc = { 1, 2, 2, 1, -1, -2, -2, -1 };

            bool[,] visited = new bool[n, n];
            int visitedCount = 0;
            
            // Find the starting position
            if (grid[0][0] != 0)
                return false;            

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 });
            visited[0, 0] = true;            

            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                int r = curr[0], c = curr[1];
                visitedCount = grid[r][c];
                for (int i = 0; i < 8; i++)
                {
                    int nr = r + dr[i];
                    int nc = c + dc[i];

                    if (nr >= 0 && nr < n && nc >= 0 && nc < n && !visited[nr, nc])
                    {
                        if (grid[nr][nc] == visitedCount + 1)
                        {
                            visited[nr, nc] = true;
                            queue.Enqueue(new int[] { nr, nc });
                        }
                    }
                }
            }

            return visitedCount == n * n - 1;
        }