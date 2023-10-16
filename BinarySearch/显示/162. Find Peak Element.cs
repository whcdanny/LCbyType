//Leetcode 162. Find Peak Element med
//题意：在一个数组中找到峰值元素。峰值元素是指其值大于相邻两个元素
//思路：二分法: 找到数组中任意一个峰值元素
//时间复杂度:  二分查找的时间复杂度是 O(logn)
//空间复杂度： O(1)
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > nums[mid + 1])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        public int FindPeakElement1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            if (nums.Length == 1)
                return 0;
            if (nums.Length == 2)
                return nums[0] > nums[1] ? 0 : 1;
            int res = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i - 1] < nums[i] && nums[i] > nums[i + 1])
                    res = i;
                if (i + 1 == nums.Length - 1 && nums[i] < nums[i + 1])
                    res = i + 1;
            }
            return res;
        }