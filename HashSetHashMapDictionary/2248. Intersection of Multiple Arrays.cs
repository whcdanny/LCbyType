//Leetcode 2248. Intersection of Multiple Arrays ez
//题意：给定一个二维整数数组 nums，其中 nums[i] 是一个非空数组，包含不同的正整数。返回在每个 nums 数组中都存在的整数列表，按升序排列。
//思路：hashtable 首先，我们可以利用哈希表存储每个数组中的整数出现次数。
//遍历第一个数组 nums[0]，将其中的每个元素添加到哈希表中，并初始化计数器 count。
//然后，遍历剩余的数组 nums[1:]，对于每个数组中的元素，如果在哈希表中存在且出现次数大于等于 count，则将其出现次数加一。
//最后，遍历哈希表，将出现次数等于 count 的整数添加到结果列表中。
//时间复杂度：O(n * m) 平均长度为 m，数组的数量为 n
//空间复杂度：O(m) O(k)，其中 k 为结果列表的长度。
        public IList<int> Intersection(int[][] nums)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            int count = nums.Length;

            // 初始化哈希表，记录第一个数组中的整数出现次数
            foreach (var num in nums[0])
            {
                if (!freqMap.ContainsKey(num))
                {
                    freqMap[num] = 1;
                }
            }

            // 遍历剩余的数组，更新哈希表中整数的出现次数
            for (int i = 1; i < nums.Length; i++)
            {
                foreach (var num in nums[i])
                {
                    if (freqMap.ContainsKey(num) && freqMap[num] == i)
                    {
                        freqMap[num]++;
                    }
                }
            }

            // 遍历哈希表，将出现次数等于 count 的整数添加到结果列表中
            IList<int> result = new List<int>();
            foreach (var kvp in freqMap)
            {
                if (kvp.Value == count)
                {
                    result.Add(kvp.Key);
                }
            }

            // 将结果列表按升序排列
            result = result.OrderBy(x => x).ToList();

            return result;
        }