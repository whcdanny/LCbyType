//Leetcode 1851. Minimum Interval to Include Each Query hard
//题意：给定一个二维整数数组intervals，其中intervals[i] = [lefti, righti]描述第i个区间从lefti到righti（包含）。区间的大小定义为它包含的整数的数量，或者更正式地说为righti - lefti + 1。
//还给定一个整数数组queries。第j个查询的答案是最小的区间i的大小，使得left[i] <= queries[j] <= right[i]。如果不存在这样的区间，答案是-1。
//返回包含查询答案的数组。
//思路：PriorityQueue;
//建立queries和相对应位置,然后queries根据数值排序,根据interval的头排序；
//先找到左边界小于等于query值；弹出右边界也小于query值；剩下的就是当前满足条件的最小值，或者没有则为-1；
//时间复杂度：O(n * log(n) + m * log(m)) n为intervals的长度 m为queries的长度
//空间复杂度：O(n+m)
        public int[] MinInterval(int[][] intervals, int[] queries)
        {
            int intervalSize = 0, i = 0, j = 0;
            int[][] queryIndex = new int[queries.Length][];
            //建立queries和相对应位置
            for (i = 0; i < queries.Length; i++)
            {
                queryIndex[i] = new int[2] { queries[i], i };
            }
            //然后queries根据数值排序
            Array.Sort(queryIndex, (a, b) => a[0] - b[0]);
            //根据interval的头排序；
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            PriorityQueue<(int size, int right), int> pq = new PriorityQueue<(int size, int right), int>();
            int[] result = new int[queries.Length];
            foreach (var query in queryIndex)
            {
                //先找到左边界小于等于query值；
                while (j < intervals.Length && intervals[j][0] <= query[0])
                {
                    intervalSize = (intervals[j][1] - intervals[j][0] + 1);
                    pq.Enqueue((intervalSize, intervals[j][1]), intervalSize);
                    j++;
                }
                //弹出右边界也小于query值；
                while (pq.Count > 0 && pq.Peek().right < query[0])
                {
                    pq.Dequeue();
                }
                //剩下的就是当前满足条件的最小值，或者没有则为-1；
                result[query[1]] = pq.Count > 0 ? pq.Peek().size : -1;
            }
            return result;
        }