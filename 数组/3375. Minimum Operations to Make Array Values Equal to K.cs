//Leetcode 3375. Minimum Operations to Make Array Values Equal to K
//题意：给定一个整数数组nums和一个整数k。
//如果数组中所有严格大于 的值都相同，h则称该整数有效。h
//例如，如果nums = [10, 8, 10, 8]，则有效整数是h = 9因为所有都nums[i] > 9 等于 10，但 5 不是有效整数。
//您可以对 执行以下操作nums：
//选择对中的当前值有效h的整数。nums
//对于每个索引i，nums[i] > h设置nums[i] 为h。
//返回使 中的每个元素都等于所需的最少操作数。如果不可能使所有元素都等于，则返回 -1。nums kk
//思路：如果nums中有比k小的 -1
//然后只要找出比k大的不重复的个数就是答案；
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public int MinOperations(int[] nums, int k)
        {
            if (nums.Min() < k)
                return -1;
            SortedSet<int> set = new SortedSet<int>();
            foreach (var num in nums)
            {
                if (num > k)
                    set.Add(num);
            }
            return set.Count;
        }