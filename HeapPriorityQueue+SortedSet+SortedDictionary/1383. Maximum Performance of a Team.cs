//Leetcode 1383. Maximum Performance of a Team hard
//题意：给定两个整数 n 和 k，以及两个长度为 n 的整数数组 speed 和 efficiency。其中，speed[i] 和 efficiency[i] 分别表示第 i 位工程师的速度和效率。
//要求从 n 位工程师中选择最多 k 位不同的工程师，组成一个性能最高的团队。团队的性能定义为团队中工程师速度的总和乘以团队中效率最低的工程师的效率。
//返回这个团队的最大性能。由于答案可能很大，因此需要对 10^9 + 7 取模。
//思路：PriorityQueue 工程师按照效率进行排序，然后依次选择效率最高的 k 位工程师，同时记录他们的速度和。
//维护一个最小堆（优先队列），用于记录当前已选择的 k 位工程师中的最慢的速度。
//在每次选择工程师时，将当前工程师的速度加入最小堆，并计算当前团队的总速度，并更新团队的最大性能。
//时间复杂度: O(nlogn)，其中 n 为工程师的数量
//空间复杂度：O(n)
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            int[][] records = new int[n][];
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                records[i] = new int[2];
            }
            for (int i = 0; i < n; i++)
            {
                records[i][0] = efficiency[i];
                records[i][1] = speed[i];
            }
            Array.Sort(records, (a, b) => { return b[0] - a[0]; });

            long speedSum = 0;
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (minHeap.Count == k)
                {
                    int minSpeed = minHeap.Dequeue();
                    speedSum -= minSpeed;
                }

                speedSum += records[i][1];
                minHeap.Enqueue(records[i][1], records[i][1]);
                result = Math.Max(result, speedSum * records[i][0]);

            }
            return (int)(result % 1000000007);
        }