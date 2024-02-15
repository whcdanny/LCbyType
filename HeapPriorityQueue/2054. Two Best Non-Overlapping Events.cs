//Leetcode 2054. Two Best Non-Overlapping Events med
//题意：给定一个二维整数数组 events，其中 events[i] = [startTimei, endTimei, valuei] 表示第 i 个事件的开始时间、结束时间和价值。你可以选择至多两个不重叠的事件参加，使得它们的价值之和最大。
//返回这个最大的价值之和。
//注意：开始时间和结束时间是包含的，也就是说，你不能同时参加两个在同一时间开始和结束的事件。具体来说，如果你参加了一个结束时间为 t 的事件，下一个事件必须在 t + 1 或之后开始。
//思路：PriorityQueue 看code
//时间复杂度: O(n * log(n))
//空间复杂度：O(n)            
        public int MaxTwoEvents(int[][] events)
        {
            int result = 0, max = 0;
            events = events.OrderBy(p => p[0]).ThenBy(p => p[1]).ToArray();
            var queue = new PriorityQueue<int[], int>();
            queue.Enqueue(new[] { events[0][2], events[0][1] }, events[0][1]);
            result = events[0][2];
            for (int i = 1; i < events.Length; i++)
            {
                //当前queue的最小的endTimei 小于 当前时间的开始时间 没有重叠
                //算出加入这个even之前的最大值sum；因为最多选两个
                while (queue.Count > 0 && queue.Peek()[1] < events[i][0])
                {
                    max = Math.Max(max, queue.Dequeue()[0]);
                }
                //找到最大值；
                result = Math.Max(result, events[i][2] + max);
                //将当前even放入 为了之和计算；
                queue.Enqueue(new[] { events[i][2], events[i][1] }, events[i][1]);
            }
            return result;
        }