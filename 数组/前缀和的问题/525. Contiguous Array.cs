//Leetcode 525. Contiguous Array med
//题意：给定一个二进制数组 nums，返回具有相等数量的 
//0 和 1 的连续子数组的最大长度。
//思路：问题转化
//将数组中的 0 转换为 −1，这样问题就转化为：
//寻找连续子数组的和为 0 的最大长度。
//前缀和 + 哈希表
//使用前缀和的思想，通过计算当前的累计和 sum：
//当两次出现相同的 sum 值时，说明这两次之间的子数组的和为 0。
//记录每个 sum 第一次出现的索引，用哈希表存储。
//核心逻辑遍历数组时计算前缀和 sum。
//如果当前 sum 已经在哈希表中，说明从哈希表记录的索引到当前索引之间的子数组和为 0，更新最大长度。
//如果当前 sum 不在哈希表中，将其存入哈希表，记录对应的索引。
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public int FindMaxLength(int[] nums)
        {
            // 将 0 转换为 -1，直接在累加中进行处理
            Dictionary<int, int> prefixSumMap = new Dictionary<int, int>();
            prefixSumMap[0] = -1;
            int maxLength = 0;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += (nums[i] == 0 ? -1 : 1);

                if (prefixSumMap.ContainsKey(sum))
                {
                    // 当前前缀和已存在，计算子数组长度
                    maxLength = Math.Max(maxLength, i - prefixSumMap[sum]);
                }
                else
                {
                    // 记录当前前缀和的索引
                    prefixSumMap[sum] = i;
                }
            }

            return maxLength;
        }