//Leetcode 2529. Maximum Count of Positive Integer and Negative Integer ez
//题意：给定一个非递减排序的整数数组 nums，要求返回正整数和负整数的数量中的最大值。
//思路：二分搜索, 先找到负数最接近0的位置；再找正数最接近0的位置；
//注：这里0不算正数；
//时间复杂度:  O(logN)，其中 N 是数组的长度
//空间复杂度： O(1)
        public int MaximumCount1(int[] nums)
        {
            int left = 0;
            int right = nums.Length;
            int mid = 0;
            //先算负数；
            while (left < right)
            {
                mid = (left + right) / 2;

                if (nums[mid] >= 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            //假设正数没有负数多，
            var max = left;
            
            left = 0;
            right = nums.Length;
            mid = 0;
            //再算正数；
            while (left < right)
            {
                mid = (left + right) / 2;

                if (nums[mid] < 1)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return Math.Max(nums.Length - left, max);
        }