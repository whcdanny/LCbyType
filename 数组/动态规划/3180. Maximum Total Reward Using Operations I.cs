//Leetcode 3180. Maximum Total Reward Using Operations I med
//题目：给定一个长度为 
//n 的整数数组 rewardValues，表示奖励的数值。最初，奖励总值 
//x 为 0，所有索引都未标记。可以多次执行以下操作：
//选择一个未标记的索引 
//i（范围为[0, n - 1]）。
//如果 rewardValues[i] 大于当前的总奖励 
//x，则将 rewardValues[i] 添加到 
//x 中，并标记索引 i。
//思路: 动态规划+递归，
//每个位置两种可能性，选或不选
//先排序，然后递归，相当于先假设skip然后一直到最后，然后再往前找
//找是否当前rewardValues[i]与x哪个大，然后选择是skip还是take
//时间复杂度：O(nlogn+n∗r)r 是奖励范围的两倍
//空间复杂度：O(n∗r)r 是奖励范围的两倍
        public int MaxTotalReward(int[] rewardValues)
        {
            Array.Sort(rewardValues);
            int n = rewardValues.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[4000];
                Array.Fill(dp[i], -1);
            }
            return MaxTotalReward_Helper(rewardValues, dp, 0, 0);
        }

        int MaxTotalReward_Helper(int[] r, int[][] dp, int i, int val)
        {
            if (i == r.Length) 
                return val;
            if (dp[i][val] != -1) 
                return dp[i][val];
            int skip = MaxTotalReward_Helper(r, dp, i + 1, val);
            int take = 0;
            if (r[i] > val)
            {
                take = MaxTotalReward_Helper(r, dp, i + 1, val + r[i]);
            }
            return dp[i][val] = Math.Max(skip, take);
        }