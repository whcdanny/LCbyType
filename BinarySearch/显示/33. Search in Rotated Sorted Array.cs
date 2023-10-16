//Leetcode 33. Search in Rotated Sorted Array med
//题意：在一个旋转过的升序数组中查找目标元素，如果找到返回它的索引，否则返回 -1。
//思路：二分法: 中间的数大于最左边的数，这说明左半段是升序的。中间的数小于最左边的数，这说明右半段是升序的。
//时间复杂度:  二分法的时间复杂度是 O(logn)
//空间复杂度： O(1)
        public int Search33(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target <= nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] <= target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }