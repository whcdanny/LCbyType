//Leetcode 2367. Number of Arithmetic Triplets med
//题意：给定一个严格递增的整数数组 nums 和一个正整数 diff。定义一个三元组 (i, j, k) 是算术三元组，如果满足以下条件：
//i<j<k
//nums[j] - nums[i] == diff
//nums[k] - nums[j] == diff
//要求返回唯一算术三元组的数量。
//思路：二分搜索法: 先根据nums[i] + diff 找到合适j位置，再根据找到的j位置找nums[index] + diff找到k的位置；        
//时间复杂度：O(log(n) * log(n))
//空间复杂度：O(1)
        public int ArithmeticTriplets(int[] nums, int diff)
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int index = Array.BinarySearch(nums, nums[i] + diff);

                if (index > 0)
                {
                    index = Array.BinarySearch(nums, nums[index] + diff);

                    if (index > 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }