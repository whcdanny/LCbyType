//Leetcode 2398. Maximum Number of Robots Within Budget hard
//题意：你有n个机器人。给定两个长度为n的0索引整数数组chargeTimes和runningCosts。第i个机器人的充电费用为chargeTimes[i]，运行费用为runningCosts[i]。还给定一个整数budget。
//选择运行k个机器人的总费用等于max(chargeTimes) + k* sum(runningCosts)，其中max(chargeTimes)是k个机器人中的最大充电费用，sum(runningCosts)是k个机器人的运行费用之和。
//返回最大连续机器人数，使得总费用不超过budget。
//思路：二分搜索法+滑窗: 猜测k；
//滑窗新元素i，sum加上这个值，然后末尾位置的chargeTimes小于当前位置的chargeTimes都移除，然后添加当前的位置；
//如果头的位置超过了滑窗范围 移除，滑窗范围时[i-l+1, i]
//然后算出结果 chargeTimes[dq.First.Value] + k * sum
//时间复杂度：O(NLognLogn)
//空间复杂度：O(n)
        public int MaximumRobots(int[] chargeTimes, int[] runningCosts, long budget)
        {            
            int n = chargeTimes.Length;

            long left = 0, right = n;
            while (left < right)
            {
                long mid = right - (right - left) / 2;
                if (IsOK(mid, chargeTimes, runningCosts, budget))
                    left = mid;
                else
                    right = mid - 1;
            }
            return (int)left;
        }

        private bool IsOK(long k, int[] chargeTimes, int[] runningCosts, long budget)
        {
            int n = chargeTimes.Length;
            long sum = 0;
            LinkedList<int> dq = new LinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                sum += runningCosts[i];

                while (dq.Count > 0 && chargeTimes[dq.Last.Value] <= chargeTimes[i])
                {
                    dq.RemoveLast();
                }
                dq.AddLast(i);

                while (dq.Count > 0 && dq.First.Value <= i - k)
                {
                    dq.RemoveFirst();
                }

                if (i >= k - 1)
                {
                    long ret = chargeTimes[dq.First.Value] + k * sum;
                    if (ret <= budget) return true;
                    sum -= runningCosts[i - (int)k + 1];
                }
            }

            return false;
        }

        public int MaximumRobots_1(int[] chargeTimes, int[] runningCosts, long budget)
        {
            int maxCount = 0;
            LinkedList<int> localMaximum = new LinkedList<int>();
            long currentBudget = 0;

            for (int start = 0, end = 0; end < chargeTimes.Length; end++)
            {
                while (localMaximum.Count != 0 && chargeTimes[localMaximum.Last.Value] < chargeTimes[end])
                {
                    localMaximum.RemoveLast();
                }

                localMaximum.AddLast(end);
                currentBudget += runningCosts[end];

                while (localMaximum.Count != 0 && budget < (chargeTimes[localMaximum.First.Value] + (end - start + 1) * currentBudget))
                {
                    currentBudget -= runningCosts[start];
                    if (localMaximum.First.Value <= start)
                    {
                        localMaximum.RemoveFirst();
                    }

                    start++;
                }

                maxCount = Math.Max(maxCount, end - start + 1);
            }

            return maxCount;
        }
