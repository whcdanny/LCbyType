//Leetcode 279. Perfect Squares ez
//题意：给定一个正整数 n，找到最少的完全平方数（例如 1, 4, 9, 16, ...）使它们的和等于 n。可以假设给定的 n 不会超过 10000。
//思路：(BFS)从 n 减去所有小于等于 n 的完全平方数，将结果加入队列中，并逐层搜索，直到找到最小的完全平方数数量。
//时间复杂度: 最坏情况下，每个数字都要入队一次，出队一次。对于每个数字，都要尝试减去所有小于等于它的完全平方数。假设 n 的平方根为 m，那么尝试的次数最多为 O(m)。所以总的时间复杂度为 O(n * m)。
//空间复杂度：O(n)
        public int NumSquares(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            int level = 0;

            // 将 n 加入队列
            queue.Enqueue(n);
            visited.Add(n);

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int current = queue.Dequeue();

                    // 尝试减去所有小于等于 current 的完全平方数
                    for (int j = 1; j * j <= current; j++)
                    {
                        int next = current - j * j;

                        if (next == 0)
                        {
                            return level + 1;
                        }

                        if (!visited.Contains(next))
                        {
                            queue.Enqueue(next);
                            visited.Add(next);
                        }
                    }
                }

                level++;
            }

            return 0;
        }