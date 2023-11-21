//Leetcode 773. Sliding Puzzle hard
//题意：给定一个 2x3 的棋盘，棋盘上有 5 块砖瓦，用数字 1 到 5 表示，还有一个空格用 0 表示。目标是通过交换棋盘上的砖瓦，将棋盘还原成目标状态：[[1, 2, 3],[4,5,0]]给定一个起始状态，判断是否能通过一系列的交换操作将其还原为目标状态。每一步可以交换空格和相邻的数字，交换次数即为最小步数。 
//思路：BFS（广度优先搜索）来解决。每个节点表示一个棋盘的状态，初始节点是给定的起始状态，目标节点是还原成的目标状态。在搜索过程中，每一步都是通过交换空格和相邻数字得到的新状态。找到0的位置，上下左右平移然后跟新的位置互换值，直到满足条件。
//时间复杂度: O(N^2 * log(N^2))，其中 N 是网格的边长。因为队列中最多包含 N^2 个单元格，每次操作的时间复杂度为 log(N^2)。
//空间复杂度：O(N^2)
        public int SlidingPuzzle(int[][] board)
        {
            int[] startState = new int[] { board[0][0], board[0][1], board[0][2], board[1][0], board[1][1], board[1][2] };
            int[] targetState = new int[] { 1, 2, 3, 4, 5, 0 };

            Queue<int[]> queue = new Queue<int[]>();
            HashSet<string> visited = new HashSet<string>();
            queue.Enqueue(startState);
            visited.Add(string.Join("", startState));

            int steps = 0;
            int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int[] currentState = queue.Dequeue();
                    //比较两个可枚举对象是否相等。
                    if (Enumerable.SequenceEqual(currentState, targetState))
                    {
                        return steps;
                    }

                    int zeroIndex = Array.IndexOf(currentState, 0);
                    int row = zeroIndex / 3;
                    int col = zeroIndex % 3;

                    foreach (int[] dir in directions)
                    {
                        int newRow = row + dir[0];
                        int newCol = col + dir[1];

                        if (newRow >= 0 && newRow < 2 && newCol >= 0 && newCol < 3)
                        {
                            int newIndex = newRow * 3 + newCol;

                            int[] newState = (int[])currentState.Clone();
                            newState[zeroIndex] = currentState[newIndex];
                            newState[newIndex] = 0;

                            string key = string.Join("", newState);
                            if (!visited.Contains(key))
                            {
                                queue.Enqueue(newState);
                                visited.Add(key);
                            }
                        }
                    }
                }

                steps++;
            }

            return -1; // 无法还原到目标状态
        }