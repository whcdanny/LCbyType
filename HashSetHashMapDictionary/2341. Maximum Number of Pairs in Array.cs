//Leetcode 2341. Maximum Number of Pairs in Array ez
//题意：给定一个整数数组 nums，每次操作可以选择数组中相等的两个整数，然后将它们移除，形成一对。问经过尽可能多次的操作后，剩下的数组中形成的对数和剩余的整数个数。
//思路：hashtable 使用一个哈希表（字典）统计数组中每个整数出现的次数。
//遍历哈希表，对于每个整数出现的次数 count，可以形成 count / 2 对整数对，剩余的 count % 2 个整数无法形成整数对。
//统计所有整数对的总数，以及剩余的整数个数。
//时间复杂度：O(n + m) m 为哈希表的大小
//空间复杂度：O(m)
        public int[] NumberOfPairs(int[] nums)
        {
            Dictionary<int, int> countMap = new Dictionary<int, int>();
           
            foreach (int num in nums)
            {
                if (!countMap.ContainsKey(num))
                {
                    countMap[num] = 0;
                }
                countMap[num]++;
            }

            int pairCount = 0;
            int remainingCount = 0;
            
            foreach (int count in countMap.Values)
            {
                pairCount += count / 2;
                remainingCount += count % 2;
            }

            return new int[] { pairCount, remainingCount };
        }