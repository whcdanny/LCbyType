//Leetcode 2404. Most Frequent Even Element EZ
//题意：给定一个整数数组 nums，返回出现次数最多的偶数元素。如果存在多个出现次数相同的偶数元素，则返回其中最小的一个。如果没有偶数元素，则返回 -1。
//思路：hashtable 首先统计数组中每个偶数元素的出现次数，然后找出出现次数最多的偶数元素并记录其出现次数。接着再次遍历数组，找出出现次数最多的偶数元素中最小的那个。
//注：SortedDictionary
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MostFrequentEven(int[] nums)
        {
            SortedDictionary<int, int> count = new SortedDictionary<int, int>();

            // 统计每个偶数元素的出现次数
            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    if (!count.ContainsKey(num))
                        count[num] = 0;
                    count[num]++;
                }
            }

            // 找出出现次数最多的偶数元素
            int maxCount = 0;
            int mostFrequentEven = -1;
            foreach (var kvp in count)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostFrequentEven = kvp.Key;
                }
            }

            return mostFrequentEven;
        }