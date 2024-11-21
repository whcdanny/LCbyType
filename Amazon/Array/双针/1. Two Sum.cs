//Leetcode 1. Two Sum ez
//题意：给定的整数数组中找到两个数，使它们的和等于一个特定的目标值。
//思路：两个指针，左右指针向中间移动的方式进行查找
//时间复杂度:  n 是字符串的长度, 时间复杂度是 O(n)。
//空间复杂度： O(n)    
        public int[] TwoSum(int[] nums, int target)
        {
            // 创建一个存储原始数组索引的数组
            int[] indexes = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                indexes[i] = i;
            }

            // 对数组进行排序
            Array.Sort(nums, indexes);

            // 左指针和右指针
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                {
                    // 找到目标值，返回两个数的索引
                    return new int[] { indexes[left], indexes[right] };
                }
                else if (sum < target)
                {
                    // 和小于目标值，左指针右移
                    left++;
                }
                else
                {
                    // 和大于目标值，右指针左移
                    right--;
                }
            }

            return new int[0]; // 如果未找到符合条件的两个数，返回空数组或null
        }