//Leetcode 2439. Minimize Maximum of Array med
//题意：给定一个包含 n 个非负整数的数组 nums。每次操作可以选择数组中任意一个位置 i（1 <= i < n），并将 nums[i] 减1，同时将 nums[i-1] 加1。目标是通过一系列这样的操作，使得数组中的最大值最小。求最小可能的最大值。
//思路：二分搜索，对nums里的value进行二分搜索；通过 isValidMid 函数检查是否可以通过一系列操作使得数组的最大值不超过 mid。如果可以，将 high 调整为 med - 1；否则将 low 调整为 mid + 1。       
//注：这里二分法用temp来记录操作数，如果操作数<=0意思nums[i]；并且从nums后往前，是因为”nums[i] 减1，同时将 nums[i-1] 加1“
//时间复杂度: O(n log(max-min))，其中 max 和 min 分别为数组中的最大值和最小值
//空间复杂度：O(1)
        public int MinimizeArrayValue(int[] nums)
        {
            int result = 0;
            int low = nums.Min();
            int high = nums.Max();

            while (low <= high)
            {
                long mid = ((long)low + (long)high) / 2;

                if (isValidMid(nums, mid))
                {
                    result = (int)mid;
                    high = result - 1;
                }
                else
                {
                    low = (int)mid + 1;
                }
            }
            return result;
        }
        //检查和调整剩余的操作数，以确保在整个数组中的所有元素都能被操作到不超过 mid 的值
        private bool isValidMid(int[] nums, long mid)
        {
            long tempRem = 0;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] <= mid)
                {
                    tempRem -= Math.Min(tempRem, mid - nums[i]);
                }
                else
                {
                    tempRem += nums[i] - mid;
                }
            }
            return tempRem <= 0;
        }