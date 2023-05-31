//162. Find Peak Element med
//是一个寻找峰值元素的问题。给定一个无序的整数数组
//思路：使用二分查找的思想来寻找峰值元素。由于峰值元素大于其相邻元素，所以根据数组的特性，我们可以判断出峰值元素一定存在于递增序列或递减序列中的某个位置
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