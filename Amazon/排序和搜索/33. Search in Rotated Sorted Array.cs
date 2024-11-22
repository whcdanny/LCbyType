//Leetcode 33. Search in Rotated Sorted Array med
//题意：在一个旋转过的升序数组中查找目标元素，如果找到返回它的索引，否则返回 -1。
//思路：二分法: 
//先确认当前mid在左边升序，还是在右边的升序
//如果在左边升序，查找target在哪个区间，[left,mid]肯定升序， 或者 [mid,right]
//如果在右边升序，查找target在哪个区间，[left,mid],或者 [mid,right]这个肯定是升序
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