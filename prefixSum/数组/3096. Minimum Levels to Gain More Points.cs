//Leetcode 3096. Minimum Levels to Gain More Points med
//题目：给定一个长度为 n 的二进制数组 possible，表示一个游戏中的关卡信息：
//如果 possible[i] == 0，第 i 关是不可通关的。
//如果 possible[i] == 1，第 i 关可以被通关。
//游戏规则如下：
//得分规则：通关一关得 1 分，未通关一关扣 1 分。
//游戏开始时，Alice 从第 0 关开始顺序地玩，然后轮到 Bob 顺序玩剩下的关卡。
//目标：Alice 想知道她至少需要玩多少关，才能保证她的得分比 Bob 的得分高，假设两人都采取最优策略（即尽可能通关最多的关卡）。
//返回值：
//如果 Alice 不可能通过玩游戏让自己的得分高于 Bob，则返回 -1。
//否则返回 Alice 至少需要玩的关卡数。
//思路: preSum[i] 存储的是从 0 到 i 位置的 possible 数组的前缀和，用来记录 Alice 通关关卡的累计得分
//secondPreSum 用来记录 Bob 玩的关卡的得分（从后往前计算）。
//如果preSum[i - 1] > secondPreSum，说明Alice得分高于Bob，然后更新ans的level
//最后看看Alice最小level可以赢Bob
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinimumLevels(int[] possible)
        {
            int n = possible.Length;
            int[] preSum = new int[n];
            preSum[0] = possible[0] == 1 ? 1 : -1;

            for (int i = 1; i < n; ++i)
                preSum[i] = preSum[i - 1] + (possible[i] == 1 ? 1 : -1);

            int secondPreSum = 0;
            int ans = -1;

            for (int i = n - 1; i > 0; --i)
            {
                secondPreSum += (possible[i] == 1 ? 1 : -1);
                if (preSum[i - 1] > secondPreSum)
                    ans = i;
            }

            return ans;
        }