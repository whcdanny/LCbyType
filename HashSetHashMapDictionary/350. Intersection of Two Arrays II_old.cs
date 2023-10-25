//350. Intersection of Two Arrays II ez
//要求找出两个数组中的交集元素，并且考虑元素的重复
//思路：统计 nums1 中每个元素的出现次数，遍历 nums2，寻找交集元素
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