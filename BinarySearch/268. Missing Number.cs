//Leetcode 268. Missing Number ez
//题意：给定一个包含 0 到 n 中所有整数的数组 nums，其中数字不重复。请找出缺失的那个数字。
//思路：二分搜索：数组排序，然后在排序后的数组中进行二分查找。如果某个位置的元素大于该位置，说明缺失的数字在该位置的左半边；否则，缺失的数字在右半边。
//时间复杂度：O(NlogN) - 排序数组的时间复杂度为O(NlogN)，二分查找的时间复杂度为O(logN)。
//空间复杂度：O(1)
        public int MissingNumber(int[] nums)
        {
            Array.Sort(nums);
            int left = 0, right = nums.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > mid)
                {
                    // 缺失的数字在左半边
                    right = mid;
                }
                else
                {
                    // 缺失的数字在右半边
                    left = mid + 1;
                }
            }

            return left;
        }