//Leetcode2059. Minimum Operations to Convert Number med
//题意：给定整数数组 nums，初始值 start 和目标值 goal。数组中的元素表示一系列操作，每个元素都是一个整数，表示在当前数字上要执行的操作。+,-,^;你的目标是将 start 转换为 goal，返回执行操作的最小次数。如果无法实现目标，返回 -1。
//思路：使用 BFS（广度优先搜索）来遍历所有可能的状态，找到最短路径。以下是详细解释：使用队列进行 BFS 遍历，每个节点表示当前状态。从 start 开始，进行所有可能的操作，并将得到的新状态加入队列。维护一个 visited 集合，记录已经访问过的状态，避免重复计算。在找到 goal 时，返回操作次数。如果队列为空而没有找到 goal，则说明无法到达，返回 -1。
//时间复杂度: 假设 nums 的长度为 m，最坏情况下，每个节点都可能生成 3 * m 个新节点，因此总时间复杂度为 O(3^m)。
//空间复杂度：维护一个队列和一个集合，最坏情况下可能存储所有状态，因此空间复杂度为 O(3^m)。
        public int MinimumOperations(int[] nums, int start, int goal)
        {
            if (nums.Length == 0) return -1;
            Queue<int> q = new Queue<int>();
            HashSet<int> set = new HashSet<int>();
            q.Enqueue(start);
            set.Add(start);
            int ops = 0;
            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    int cur = q.Dequeue();
                    for (int j = 0; j < nums.Length; j++)
                    {
                        int plus = cur + nums[j], minus = cur - nums[j], xor = cur ^ nums[j];
                        if (plus == goal || minus == goal || xor == goal) return ops + 1;
                        if (plus >= 0 && plus <= 1000 && !set.Contains(plus))
                        {
                            q.Enqueue(plus);
                            set.Add(plus);
                        }
                        if (minus >= 0 && minus <= 1000 && !set.Contains(minus))
                        {
                            q.Enqueue(minus);
                            set.Add(minus);
                        }
                        if (xor >= 0 && xor <= 1000 && !set.Contains(xor))
                        {
                            q.Enqueue(xor);
                            set.Add(xor);
                        }
                    }
                }
                ops++;
            }
            return -1;
        }
