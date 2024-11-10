//Leetcode 3158. Find the XOR of Numbers Which Appear Twice ez
//题目：给定一个整数数组 nums，数组中的每个数字要么出现一次，要么出现两次。
//返回所有在数组中出现两次的数字的按位异或（XOR）结果，如果没有数字出现两次，则返回 0
//思路: 统计数字出现次数：使用一个字典（Dictionary<int, int>）统计数组中每个数字的出现次数。
//找出出现两次的数字：遍历字典，找出所有出现两次的数字。
//计算 XOR：对所有出现两次的数字进行 XOR 运算，得到最终结果。
//XOR 操作的特点是相同数字 XOR 结果为 0，不同数字会得到不同的组合结果。
//边界情况：如果没有任何数字出现两次，则返回 0。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int DuplicateNumbersXOR(int[] nums)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            int result = 0;

            // 统计每个数字的出现次数
            foreach (int num in nums)
            {
                if (frequency.ContainsKey(num))
                {
                    frequency[num]++;
                }
                else
                {
                    frequency[num] = 1;
                }
            }

            // 找出出现两次的数字并进行 XOR 操作
            foreach (var pair in frequency)
            {
                if (pair.Value == 2)
                {
                    result ^= pair.Key;
                }
            }

            return result;

        }