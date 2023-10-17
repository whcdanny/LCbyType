//Leetcode 410. Split Array Largest Sum hard
//题意：给定一个非负整数数组 nums 和一个整数 k，将数组划分为 k 个非空连续子数组，求出个数最小的子集并且要求这个子集总和是最大的。
//思路：二分查找. 下界为数组 nums 中元素的最大值（因为每个子数组至少包含一个元素），上界为数组 nums 中所有元素的和（因为将整个数组作为一个子数组）。然后，在每次迭代中计算子数组和的中间值 mid，并调用辅助函数 CountSubarrays(nums, mid) 来计算在限制子数组和为 mid 的情况下，可以划分的子数组个数。如果划分的子数组个数小于等于 m，说明当前子数组和的最大值可能满足要求，将上界更新为 mid-1；否则，将下界更新为 mid+1。最终的上界值即为最大值最小的子数组和。
//时间复杂度:  O(log(sum - max))，其中 sum 是数组的总和，max 是数组的最大值。
//空间复杂度： O(1)  
        public int SplitArray(int[] nums, int k)
        {
            long left = nums.Max();
            long right = nums.Sum();

            while (left <= right)
            {
                long mid = left + (right - left) / 2;

                int count = CountSubarrays(nums, mid);

                if (count <= k)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return (int)left;
        }

        private int CountSubarrays(int[] nums, long maxSum)
        {
            int count = 1;
            long sum = 0;

            foreach (var num in nums)
            {
                sum += num;
                if (sum > maxSum)
                {
                    count++;
                    sum = num;
                }
            }

            return count;
        }