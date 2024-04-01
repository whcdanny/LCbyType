//Leetcode 2653. Sliding Subarray Beauty med
//题意：给定一个包含 n 个整数的整数数组 nums，找到每个大小为 k 的子数组的美感。
//子数组的美感是子数组中的第 x 小的整数（如果它是负数），或者如果负整数少于 x 个，则为 0。
//返回一个整数数组，其中包含 n - k + 1 个整数，按顺序表示数组中第一个索引的子数组的美感。
//思路：hashtable, 看code
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] GetSubarrayBeauty(int[] nums, int k, int x)
        {
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            int[] res = new int[nums.Length - k + 1];

            for (int i = -50; i < 0; i++)
            {
                map.Add(i, 0);
            }

            //从0开始到k第一个区间，如果有小于0的则++；
            for (int i = 0; i < k; i++)
            {
                if (nums[i] < 0)
                {
                    map[nums[i]]++;
                }
            }

            for (int i = k; i < nums.Length; i++)
            {
                res[i - k] = GetXthSmallest(map, x);

                //更新map这是已经添加过的；
                if (nums[i - k] < 0)
                {
                    map[nums[i - k]]--;
                }

                //这是新的位置的；
                if (nums[i] < 0)
                {
                    map[nums[i]]++;
                }
            }

            //最后一个
            res[nums.Length - k] = GetXthSmallest(map, x);

            return res;
        }

        private int GetXthSmallest(SortedDictionary<int, int> negFreqMap, int x)
        {
            //如果x小于等于0，说明找到了第x小的数；
            foreach (var kvp in negFreqMap)
            {
                x -= kvp.Value;

                if (x <= 0)
                {
                    return kvp.Key;
                }
            }

            return 0;
        }