//Leetcode 1124. Longest Well-Performing Interval med
//题目：我们得到一个数组 hours，其中 hours[i] 表示某员工第 i 天的工作小时数。
//如果某一天的工作小时数 严格大于 8，那么这一天是一个疲惫日。
//一个高效区间是指在这个区间内，疲惫日的数量严格多于非疲惫日的数量。
//返回最长的高效区间的长度。
//思路: 对数组中的每个元素        
//hours[i]，转换为：1：疲惫日（工作时间 > 8）。−1：非疲惫日（工作时间 ≤ 8）。
//问题转化为寻找一个最长的子数组，使得该子数组的元素和sum>0。
//前缀和：计算从数组开头到每一天的前缀和。对于每个索引i，计算累加值 prefixSum，表示从第 0 天到第i 天的总和。
//Dictionary优化：使用哈希表 seen 记录每个前缀和第一次出现的索引。
//对于当前索引 i，若发现prefixSum−1 在 seen 中，则说明存在一个子数组的和大于 0，更新最长区间长度。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int LongestWPI(int[] hours)
        {
            // 转换数组：>8 变为 1；<=8 变为 -1
            int n = hours.Length;
            for (int i = 0; i < n; i++)
            {
                hours[i] = hours[i] > 8 ? 1 : -1;
            }

            // 前缀和和哈希表
            int prefixSum = 0;
            int maxLength = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                prefixSum += hours[i];

                // 如果前缀和 > 0，直接更新最大长度
                if (prefixSum > 0)
                {
                    maxLength = i + 1;
                }
                else
                {
                    // 检查是否存在 prefixSum - 1
                    if (map.ContainsKey(prefixSum - 1))
                    {
                        maxLength = Math.Max(maxLength, i - map[prefixSum - 1]);
                    }

                    // 记录 prefixSum 第一次出现的位置
                    if (!map.ContainsKey(prefixSum))
                    {
                        map[prefixSum] = i;
                    }
                }
            }

            return maxLength;
        }