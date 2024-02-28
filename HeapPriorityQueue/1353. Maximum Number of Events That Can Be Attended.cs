//Leetcode 1353. Maximum Number of Events That Can Be Attended med
//题意：给定一个事件数组 events，其中 events[i] = [startDayi, endDayi] 表示第 i 个事件的开始时间和结束时间。每个事件都从 startDayi 开始，到 endDayi 结束。
//你可以在任何满足 startTimei <= d <= endTimei 的日期 d 参加第 i 个事件。但你每次只能在某一天 d 参加一个事件。
//要求返回你能参加的最大事件数量。
//注：这里你可以在在开始和结束直接任何时间进入，当然也可以在这个时间离开；
//思路：PriorityQueue, 按开始日期对数组进行排序 看code        
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public int MaxEvents(int[][] events)
        {
            Array.Sort(events, (a, b) => a[0] - b[0]);
            int n = events.Length;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            int i = 0;
            int count = 0;
            int day = 1;

            while (pq.Count > 0 || i < n)
            {
                //添加直到今天的活动，或者如果没有添加活动，则加速到下一个活动
                while (i < n && events[i][0] <= day)
                {
                    pq.Enqueue(events[i][1], events[i][1]);
                    i++;
                }
                if (pq.Count == 0)
                {
                    day = events[i][0];
                    continue;
                }

                //参加活动提前结束
                if (pq.Count > 0 && day <= pq.Peek())
                {
                    pq.Dequeue();
                    count++;
                }
                day++;

                //删除队列中过期的事件
                while (pq.Count > 0 && pq.Peek() < day)
                {
                    pq.Dequeue();
                }
            }

            return count;            
        }