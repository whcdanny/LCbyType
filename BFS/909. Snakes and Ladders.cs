//Leetcode 909. Snakes and Ladders med
//题意：从棋盘的起点（square 1）移动到终点（square n^2），并且在移动过程中遵循蛇和梯子的规则。每一步都模拟投掷一个六面骰子，选择移动到下一个目标方格，目标方格的范围是 [curr + 1, min(curr + 6, n^2)]。如果目标方格上有蛇或梯子，玩家必须移动到蛇或梯子的目的地。        
//思路：将棋盘扁平化，使得每个方格的标号从1到n^2。使用广度优先搜索（BFS）来遍历可能的移动路径，同时记录已访问的方格。在搜索过程中，对于每一步，计算可能的下一步的位置，包括蛇或梯子的目的地。如果搜索到达终点，返回移动的步数；否则，返回 -1。        
//时间复杂度: O(N^2)，其中 N 是棋盘的边长。在最坏情况下，我们需要遍历整个棋盘
//空间复杂度：O(N^2)，用于存储扁平化的棋盘和记录已访问的方格。在最坏情况下，我们可能需要存储整个棋盘的信息。
        public int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;
            int[] flattenedBoard = new int[n * n + 1];

            // Flatten the board
            int index = 1;
            bool leftToRight = true;
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    flattenedBoard[index++] = board[i][leftToRight ? j : n - 1 - j];
                }
                leftToRight = !leftToRight;
            }

            // BFS
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue(1);
            visited.Add(1);

            int steps = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int current = queue.Dequeue();

                    if (current == n * n)
                    {
                        return steps;
                    }

                    for (int next = current + 1; next <= Math.Min(current + 6, n * n); next++)
                    {
                        int nextPos = flattenedBoard[next] == -1 ? next : flattenedBoard[next];
                        if (!visited.Contains(nextPos))
                        {
                            queue.Enqueue(nextPos);
                            visited.Add(nextPos);
                        }
                    }
                }

                steps++;
            }

            return -1; // If there is no solution
        }