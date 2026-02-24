//Leetcode 33. Search in Rotated Sorted Array med
//题意：给一个排序好但是并不是完全从头开始的数组，[4,5,6,7,0,1,2]
//然后给你一个target，找出这个target在数组的位置。
//思路：Binary Search， 找出mid，然后跟target的对比
//然后跟left的值作比较，确定有序区间，在有序区间内判断 target;
//如果target落在左边的有序范围内，搜索范围收缩到左边；
//否则，去右边那可能包含“旋转点”的复杂区域找。
//同理跟right的值作比较，确定有序区间，在有序区间内判断 target;       
//时间复杂度: O(log n)
//空间复杂度：O(1)
        public int Search(int[] nums, int target)
        {           
            int n = nums.Length;
            int left = 0;
            int right = n - 1;
            
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] >= nums[left])
                {
                    if (target >= nums[left] && target < nums[mid])
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
                    if (target <= nums[right] && target > nums[mid])
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