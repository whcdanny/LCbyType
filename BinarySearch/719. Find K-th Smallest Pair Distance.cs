//Leetcode 719. Find K-th Smallest Pair Distance hard
//题意：给定一个整数数组 nums，返回其中所有元素之间的差的绝对值中第 k 小的值。
//思路：二分搜索：首先，我们可以对数组进行排序，然后使用二分查找确定绝对差值的范围。然后，我们可以计算在这个范围内的差值小于等于 mid 的数对数量，并根据数量调整二分查找的范围，最终找到第 k 小的绝对差值。
//注：固定i=0开始，然后j++，满足nums[j] - nums[i] <= mid，然后不满足之和i动，然后再考虑j；
//时间复杂度: O(N log N)，而每次二分查找的时间复杂度是 O(N log W)，其中 W 是数组中最大元素和最小元素的差值。总体时间复杂度是 O(N log N log W)。
//空间复杂度：O(1)
        public int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums);

            int left = 0, right = nums[nums.Length - 1] - nums[0];
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int count = binarySearch_SmallestDistancePair(nums, mid);

                if (count < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private int binarySearch_SmallestDistancePair(int[] nums, int mid)
        {
            int count = 0;
            int j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                while (j < nums.Length && nums[j] - nums[i] <= mid)
                {
                    j++;
                }
                count += j - i - 1;
            }

            return count;
        }