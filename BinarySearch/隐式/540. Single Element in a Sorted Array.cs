//Leetcode 540. Single Element in a Sorted Array med
//题意：在一个排序好的数组中，找到唯一一个只出现一次的元素，其他元素都出现两次。
//思路：二分法: 二分查找，左边界 left 为 0，右边界 right；mid 是偶数，比较 mid 和 mid + 1， 两个元素相等，单个元素在[mid+2, right] 的范围内，两个元素不相等，单个元素在[left, mid] 的范围内；
//时间复杂度:  n 是数组的长度, O(logn)
//空间复杂度： O(1)        
        public int SingleNonDuplicate(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (mid % 2 == 1)
                {
                    mid--; // 确保 mid 是偶数
                }

                if (nums[mid] == nums[mid + 1])
                {
                    left = mid + 2;// Unique element is on the right side
                }
                else
                {
                    right = mid;// Unique element is on the left side
                }
            }

            return nums[left];
        }