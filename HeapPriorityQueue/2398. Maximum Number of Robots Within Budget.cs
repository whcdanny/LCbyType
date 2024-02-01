//Leetcode 2398. Maximum Number of Robots Within Budget hard
//题意：你有n个机器人。给定两个长度为n的0索引整数数组chargeTimes和runningCosts。第i个机器人的充电费用为chargeTimes[i]，运行费用为runningCosts[i]。还给定一个整数budget。
//选择运行k个机器人的总费用等于max(chargeTimes) + k* sum(runningCosts)，其中max(chargeTimes)是k个机器人中的最大充电费用，sum(runningCosts)是k个机器人的运行费用之和。
//返回最大连续机器人数，使得总费用不超过budget。
//思路：PriorityQueue;
//每一次添加i，sum算上当前的runingcost，然后跟budget做比较，这里i相当于滑块的右边界，j相当于左边界；
//如果小于budget那么找出当前最大长度，如果大于，那么如果第一个位置已经超出滑块范围，那么将第一个弹出，并且sum要减去j的runningcost；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            long sum = 0;
            int max = 0, n = chargeTimes.Length;
            for (int i = 0, j = 0; i < n; i++)
            {
                pq.Enqueue(i, chargeTimes[i] * -1);//乘以-1是因为，leetcode中的PriorityQueue key的顺序时从小到大，如果我们想让最大chargeTimes在PriorityQueue第一位，那么就要让他的key最小，所以*-1；
                sum += runningCosts[i];
                while (j <= i && (chargeTimes[pq.Peek()] + (i - j + 1) * sum) > budget)
                {
                    while (pq.Count > 0 && pq.Peek() <= j) pq.Dequeue();
                    sum -= runningCosts[j++];
                }
                max = Math.Max(max, (i - j + 1));
            }
            return max;
        }