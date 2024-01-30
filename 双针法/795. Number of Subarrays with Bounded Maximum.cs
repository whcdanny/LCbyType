//Leetcode 795. Number of Subarrays with Bounded Maximum med
//题意：给定一个整数数组 nums 和两个整数 left 和 right，返回连续的、非空子数组的数量，使得该子数组的最大元素的值在区间 [left, right] 内。
//思路：双指针，start 和 end 表示当前子数组的起始和结束位置，初始值都设置为 -1。
//遍历数组 nums，对于每个元素：
//如果元素大于 right，说明当前元素不能在任何子数组中，将 start 和 end 都设置为当前位置。
//如果元素在区间[left, right] 内，更新 end 为当前位置。
//每次遍历都将符合条件的子数组数量累加到结果 result 中。
//时间复杂度：O(n)，其中 n 是数组的长度
//空间复杂度：O(1)
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            int result = 0;
            int start = -1, end = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > right)
                {
                    start = end = i;
                }
                else if (nums[i] >= left && nums[i] <= right)
                {
                    end = i;
                }

                result += end - start;
            }

            return result;
        }