//Leetcode 2780. Minimum Index of a Valid Split med
//题意：给定一个长度为 n 的整数数组 nums，数组中至少存在一个“主要元素”。
//要求在数组中找到一个索引 i，将数组分割为两个子数组 nums[0, ..., i] 和 nums[i + 1, ..., n - 1]，使得分割后的两个子数组的主要元素相同。
//如果找不到这样的分割点，则返回 -1。
//思路：hashtable,Dictionary存入每个数子出现的个数，并找到主要元素
//如果主freq[dominantNum] < nums.Count / 2 直接-1；
//然后从nums开始历遍，只要找到主要元素，就给给左边出现的数量++，
//直到如果分界线i. [0,i] [i+1, n],在左边leftFreq * 2 > i + 1，在右边freq[dominantNum] * 2 > nums.Count - i - 1
//满足条件i就是分界线；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinimumIndex(IList<int> nums)
        {
            var leftFreq = 0;
            var dominantNum = nums[0];
            var freq = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                freq[num] = 1 + freq.GetValueOrDefault(num, 0);
                if (freq[num] > freq[dominantNum])
                    dominantNum = num;
            }

            if (freq[dominantNum] < nums.Count / 2)
                return -1;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == dominantNum)
                {
                    leftFreq++;
                    freq[dominantNum]--;
                }

                if (leftFreq * 2 > i + 1 && freq[dominantNum] * 2 > nums.Count - i - 1)
                    return i;
            }

            return -1;
        }