//Leetcode 2190. Most Frequent Number Following Key In an Array ez
//题意：给定一个整数数组 nums 和一个整数 key，数组中包含 key。
//对于数组中的每个唯一整数 target，统计在 nums 中 key 的每次出现后，紧接着出现 target 的次数。
//换句话说，统计满足以下条件的索引 i 的数量：
//0 <= i <= nums.length - 2
//nums[i] == key
//nums[i + 1] == target
//返回出现次数最多的 target。测试用例会保证出现次数最多的 target 是唯一的。
//思路：hashtable 找到nums[i] == key，找到target然后根据target的出现的数量，或者 target是否大于最多出现的频率；
//哈希表记录每个 target 在数组中出现的次数。
//遍历数组 nums，找到所有满足条件的(key, target) 对，即 nums[i] == key 且 nums[i + 1] == target。
//统计每个 target 出现的次数，并更新哈希表中对应的计数。
//找到出现次数最多的 target。
//时间复杂度：遍历数组 nums O(n)，其中n是数组的长度。统计target出现次数O(m)，其中m是数组中唯一整数的数量 O(n + m)。
//空间复杂度：O(m)
        public int MostFrequent(int[] nums, int key)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            int maxCount = 0;
            int mostFrequent = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == key)
                {
                    int target = nums[i + 1];
                    count[target] = count.GetValueOrDefault(target) + 1;
                    if (count[target] > maxCount || (count[target] == maxCount && target > mostFrequent))
                    {
                        maxCount = count[target];
                        mostFrequent = target;
                    }
                }
            }

            return mostFrequent;
        }