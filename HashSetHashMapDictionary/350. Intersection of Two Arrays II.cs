//Leetcode 350. Intersection of Two Arrays II ez
//题意：给定两个数组，编写一个函数来计算它们的交集。
//思路：遍历第一个数组 nums1，将每个元素的出现次数记录在HashMap中。然后，遍历第二个数组 nums2，对于每个元素，检查其在HashMap中的计数，如果大于0，则将该元素添加到结果列表中，并将HashMap中对应元素的计数减一。
//时间复杂度：遍历两个数组分别需要 O(m+n) 的时间，其中 m 和 n 分别是两个数组的长度。
//空间复杂度：O(min(m,n))
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> result = new List<int>();

            // 统计 nums1 中每个元素的出现次数
            foreach (int num in nums1)
            {
                if (map.ContainsKey(num))
                    map[num]++;
                else
                    map[num] = 1;
            }

            // 遍历 nums2，寻找交集元素
            foreach (int num in nums2)
            {
                if (map.ContainsKey(num) && map[num] > 0)
                {
                    result.Add(num);
                    map[num]--;
                }
            }

            return result.ToArray();
        }