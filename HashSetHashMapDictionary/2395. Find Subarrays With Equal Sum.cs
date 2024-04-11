//Leetcode 2395. Find Subarrays With Equal Sum ez
//题意：给定一个整数数组 nums，判断是否存在两个长度为 2 的子数组，它们的和相等且起始索引不同。如果存在这样的子数组，返回 true，否则返回 false。
//思路：hashtable 遍历数组 nums，对于每个元素 nums[i]，再遍历数组 nums[i+1:] 中的元素 nums[j]，计算子数组 nums[i:i+2] 和 nums[j:j+2] 的和，如果它们相等且起始索引不同，则返回 true。
//如果遍历完所有元素后都没有找到满足条件的子数组，则返回 false。        
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public bool FindSubarrays(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int sum = nums[i] + nums[i + 1];
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[j] + nums[j + 1] == sum)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
