//Leetcode 2441. Largest Positive Integer That Exists With Its Negative ez
//题意：给定一个不包含任何零的整数数组 nums，要求找到最大的正整数 k，使得其相反数 -k 也存在于数组中。如果不存在这样的整数，返回 -1。
//思路：左右针，组进行升序排序。然后从后往前只要找到-(nums[i]) 就输出；        
//时间复杂度:  O(n log n)，遍历数组的时间复杂度为 O(n)，总体时间复杂度为 O(n log n)。
//空间复杂度：O(1)
        public int FindMaxK(int[] nums)
        {
            Array.Sort(nums);
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums.Contains(-(nums[i])))
                {
                    return nums[i];
                }
            }
            return -1;
        }