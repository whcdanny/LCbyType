//Leetcode 1210. Minimum Moves to Reach Target with Rotations med
//题意：在一个 n*n 的网格中，有一条蛇占据了两个相邻的单元格，起始位置在左上角 (0, 0) 和 (0, 1)。网格中有空单元格用零表示，有阻塞单元格用一表示。蛇希望到达右下角 (n-1, n-2) 和 (n-1, n-1)。蛇每次可以进行以下操作：
//如果右侧没有阻塞单元格，向右移动一格。此移动保持蛇的水平/垂直位置不变。
//如果下方没有阻塞单元格，向下移动一格。此移动保持蛇的水平/垂直位置不变。
//如果处于水平位置且其下方的两个单元格都为空，则顺时针旋转。在这种情况下，蛇从(r, c) 和(r, c+1) 移动到(r, c) 和(r+1, c)。
//如果处于垂直位置且其右侧的两个单元格都为空，则逆时针旋转。在这种情况下，蛇从(r, c) 和(r+1, c) 移动到(r, c) 和(r, c+1)。
//返回蛇到达目标的最小移动次数。
//如果没有办法到达目标，则返回 -1。
//思路：广度优先搜索（BFS）来解决这个问题。以下是使用 BFS 的 C# 代码：定义一个数据结构表示蛇的状态，包含位置和方向信息。创建一个 HashSet 用于记录已经遍历过的状态，避免重复遍历。使用 BFS 遍历状态空间，每次尝试蛇的四种移动方式。在遍历的过程中，记录蛇的当前位置和方向，并将新的状态加入队列中。当蛇到达目标位置时，返回移动的步数。
//时间复杂度: O(N^2)，其中 N 是网格的边长。
//空间复杂度：O(N^2)，其中 N 是网格的边长。
        public int MinimumMoves(int[][] grid)
        {            
            int n = grid.Length;
            Queue<(int r1, int c1, int r2, int c2, int move)> queue =
            new Queue<(int, int, int, int, int)>();
            queue.Enqueue((0, 0, 0, 1, 0));
            HashSet<string> map = new HashSet<string>();
            while (queue.Count > 0)
            {
                (int r1, int c1, int r2, int c2, int move) = queue.Dequeue();
                
                if (r1 == n - 1 && c1 == n - 2 && r2 == n - 1 && c2 == n - 1)
                {
                    return move;
                }                
                string key = r1 + "-" + c1 + "-" + r2 + "-" + c2;
                if (map.Contains(key)) 
                    continue;
                map.Add(key);
                //when snake is flat or in right position
                if (r1 == r2)
                {
                    if (c2 + 1 < n && c1 + 1 < n && grid[r1][c1 + 1] == 0 && grid[r2][c2 + 1] == 0)
                    {
                        queue.Enqueue((r1, c1 + 1, r2, c2 + 1, move + 1));
                    }
                    //check down position
                    if (r1 + 1 < n && r2 + 1 < n && grid[r1 + 1][c1] == 0 && grid[r2 + 1][c2] == 0)
                    {
                        queue.Enqueue((r1 + 1, c1, r2 + 1, c2, move + 1));
                        //we can also do rotate clockwise - intuition careful observation from example 1 test case
                        queue.Enqueue((r1, c1, r2 + 1, c1, move + 1));
                    }
                }
                //when snake is in vertical position
                if (c1 == c2)
                {
                    if (c2 + 1 < n && c1 + 1 < n && grid[r1][c1 + 1] == 0 && grid[r2][c2 + 1] == 0)
                    {
                        queue.Enqueue((r1, c1 + 1, r2, c2 + 1, move + 1));
                        //this is rotate counter clockwise
                        queue.Enqueue((r1, c1, r1, c2 + 1, move + 1));
                    }
                    //check down position
                    if (r1 + 1 < n && r2 + 1 < n && grid[r1 + 1][c1] == 0 && grid[r2 + 1][c2] == 0)
                    {
                        queue.Enqueue((r1 + 1, c1, r2 + 1, c2, move + 1));
                    }
                }
            }
            return -1;
        }