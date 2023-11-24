//Leetcode 488. Zuma Game hard
//题意：Zuma 游戏是一种玩具，其中有一排彩色的球。玩家可以插入一些彩色的球，然后将它们射向一排其他球。如果有三个或更多相邻的同色球，它们会消失并得分。现在给定一串球，其中包含大写字母 'R'、'Y'、'B'、'G' 和 'W'（白色）。此外，有几个连续的球在开始时已经插入了。找到将给定的球插入到一串球中所需的最小操作数，以使最后得分最低。每次插入一个球，你可以选择使其出现在任何位置，然后立即执行得分可能的消除。如果没有可用的球，则插入停止。
//思路：(BFS)，我们可以遍历所有可能的状态，直到找到最优解
//时间复杂度: O(3^n * n)，其中 3^n 表示每一步都有三种可能性
//空间复杂度：O(3^n * n)，其中 3^n 表示每一步都有三种可能性，n 表示插入的最大次数
        public int FindMinStep(string board, string hand)
        {
            // Remove the consecutive same balls starting from index i
            string RemoveSame(string s, int i)
            {
                if (i < 0)
                    return s;

                int left = i, right = i;
                while (left > 0 && s[left - 1] == s[i])
                    left--;
                while (right + 1 < s.Length && s[right + 1] == s[i])
                    right++;

                int length = right - left + 1;
                if (length >= 3)
                {
                    // Remove consecutive same balls
                    string newS = s.Substring(0, left) + s.Substring(right + 1);
                    return RemoveSame(newS, left - 1);
                }
                else
                {
                    return s;
                }
            }

            // Sort hand so that we can easily iterate over it
            string sortedHand = new string(hand.OrderBy(c => c).ToArray());

            // Initialize queue and visited set
            Queue<(string, string, int)> queue = new Queue<(string, string, int)>();
            HashSet<(string, string)> visited = new HashSet<(string, string)>();

            queue.Enqueue((board, sortedHand, 0));
            visited.Add((board, sortedHand));

            while (queue.Count > 0)
            {
                (string currBoard, string currHand, int step) = queue.Dequeue();

                for (int i = 0; i <= currBoard.Length; i++)
                {
                    for (int j = 0; j < currHand.Length; j++)
                    {
                        // Skip balls in hand that are consecutive to the previous one
                        if (j > 0 && currHand[j] == currHand[j - 1])
                            continue;

                        // Only insert a ball in the board if it is the first ball in a sequence
                        if (i > 0 && currBoard[i - 1] == currHand[j])
                            continue;

                        // Check if the ball can be picked and inserted
                        bool pick = false;
                        // 1. Same color with right
                        // 2. Left and right are the same but pick is different
                        if (i < currBoard.Length && currBoard[i] == currHand[j])
                            pick = true;
                        if (i > 0 && i < currBoard.Length && currBoard[i - 1] == currBoard[i] && currBoard[i] != currHand[j])
                            pick = true;

                        // If the ball can be picked and inserted, add the new board, hand, and step to the queue
                        if (pick)
                        {
                            string newBoard = RemoveSame(currBoard.Substring(0, i) + currHand[j] + currBoard.Substring(i), i);
                            string newHand = currHand.Substring(0, j) + currHand.Substring(j + 1);
                            if (newBoard.Length == 0)
                            {
                                // If the board is empty, return the number of steps taken to reach it
                                return step + 1;
                            }
                            if (!visited.Contains((newBoard, newHand)))
                            {
                                queue.Enqueue((newBoard, newHand, step + 1));
                                visited.Add((newBoard, newHand));
                            }
                        }
                    }
                }
            }

            // If no solution is found, return -1
            return -1;
        }

