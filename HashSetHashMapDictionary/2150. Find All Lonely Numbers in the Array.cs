//Leetcode 2150. Find All Lonely Numbers in the Array med
//题意：给定一个整数数组 nums。一个数字 x 被称为孤立的，当且仅当它仅出现一次，并且数组中不存在相邻的数字（即 x + 1 和 x - 1）。
//返回数组中所有的孤立数字。可以以任何顺序返回答案。
//思路：hashtable 使用哈希表统计数组中每个数字的出现次数。
//遍历哈希表中的每个数字，检查其是否孤立：
//如果该数字出现的次数为 1，并且它的前一个数和后一个数都不存在于哈希表中，则将其加入结果列表中。
//时间复杂度：O(n)，其中 n 为数组 nums 的长度
//空间复杂度：O(n)
        public IList<int> FindLonely(int[] nums)
        {
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            List<int> lonelyNumbers = new List<int>();

            // 统计数字出现次数
            foreach (int num in nums)
            {
                if (!countMap.ContainsKey(num))
                {
                    countMap[num] = 0;
                }
                countMap[num]++;
            }

            // 检查每个数字是否孤立
            foreach (var kvp in countMap)
            {
                int num = kvp.Key;
                int count = kvp.Value;

                if (count == 1 && !countMap.ContainsKey(num - 1) && !countMap.ContainsKey(num + 1))
                {
                    lonelyNumbers.Add(num);
                }
            }

            return lonelyNumbers;
        }