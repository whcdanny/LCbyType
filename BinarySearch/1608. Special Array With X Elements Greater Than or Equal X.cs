//Leetcode 1608. Special Array With X Elements Greater Than or Equal X ez
//题意： 给定一个非负整数数组 nums，如果存在一个数字 x，使得数组中大于或等于 x 的元素的数量正好为 x，那么数组 nums 被称为特殊数组。如果存在这样的 x，则返回 x；否则返回 -1。
//思路：使用二分搜索，假设一个数，判断是否是否有x个大于这个数并且等于这个数；
//时间复杂度: O(n log n)
//空间复杂度：O(1)
        public int SpecialArray(int[] nums)
        {
            int right = nums.Length;
            int left = 1;
            while (left <= right)
            {
                int mid = right - (right - left) / 2;
                int count = 0;
                foreach (int num in nums)
                    if (num >= mid) count++;
                if (count == mid)
                    return mid;
                else if (count > mid)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        public int SpecialArray1(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;

            for (int x = 0; x <= n; x++)
            {
                int count = CountGreaterOrEqual(nums, x);
                if (count == x)
                {
                    return x;
                }
            }

            return -1;
        }

        private int CountGreaterOrEqual(int[] nums, int target)
        {
            int left = 0, right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return nums.Length - left;
        }
