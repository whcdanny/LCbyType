//Leetcode 2475. Number of Unequal Triplets in Array ez
//题意：给定一个包含正整数的数组 nums（下标从 0 开始），计算满足以下条件的三元组 (i, j, k) 的数量：
//0 <= i<j<k<nums.length
//nums[i]、nums[j] 和 nums[k] 两两不相等
//思路：hashtable, 三个for loops
//时间复杂度：O(n^3)
//空间复杂度：O(1)
        public int UnequalTriplets(int[] nums)
        {
            var count = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[i] == nums[j]) continue;
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] == nums[k]) continue;
                        if (nums[j] == nums[k]) continue;
                        count++;
                    }
                }
            }
            return count;
        }