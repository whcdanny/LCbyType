//Leetcode 3186. Maximum Total Damage With Spell Casting med
//题目：一个魔法师拥有多种咒语。给定一个数组 power，其中每个元素代表一个咒语的伤害值。
//可以有多个咒语具有相同的伤害值。
//已知，如果魔法师决定施放一个伤害值为 power[i] 的咒语，那么他不能施放伤害值为 power[i] - 2、power[i] - 1、power[i] + 1 或 power[i] + 2 的任何咒语。
//每个咒语只能施放一次。
//请返回魔法师可以施放的最大可能总伤害值。
//思路: 动态规划
//先把每一个power相同的统计出来存入map，然后给这个power排序，这样只需要找power[i] - 2、power[i] - 1就可以了
//然后从i开始，先看i在map中的值，和前一位dp[i-1]比较
//然后查找值比map[i]-2的dp[j]，然后找出这个dp[j]+当前map[i]的个数，和 刚才dp[i]进行比较
//最后dp[map.Count - 1]
//时间复杂度：O(nlogn)
//空间复杂度：O(n)
        public long MaximumTotalDamage(int[] power)
        {
            // Step 1: 将每个伤害值的总和存入字典 map
            Dictionary<int, long> map = new Dictionary<int, long>();
            foreach (var p in power)
            {
                if (map.ContainsKey(p))
                    map[p] += p;  // 累加相同伤害值的咒语
                else
                    map[p] = p;   // 初始化伤害值
            }

            // Step 2: 获取 map 的键并排序
            var keys = map.Keys.ToList();
            keys.Sort();

            // Step 3: 初始化动态规划数组 dp
            long[] dp = new long[map.Count];
            dp[0] = map[keys[0]];

            // Step 4: 动态规划计算最大伤害值
            for (int i = 1; i < keys.Count; i++)
            {
                int key = keys[i];
                long curr = map[key];
                long prev = dp[i - 1];
                dp[i] = Math.Max(curr, prev);  // 当前伤害和前一个最大值比较

                // 查找第一个与当前 key 不相邻的伤害值索引 j
                for (int j = i - 1; j >= 0; j--)
                {
                    if (keys[j] + 2 < key)
                    {   // 确保不相邻
                        dp[i] = Math.Max(dp[j] + curr, dp[i]);
                        break;  // 找到第一个不相邻的元素后立即跳出
                    }
                }
            }

            // 返回最大伤害值
            return dp[keys.Count - 1];
        }