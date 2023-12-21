//Leetcode 2448. Minimum Cost to Make Array Equal hard
//题意：给定两个长度为 n 的数组 nums 和 cost，每个数组中的元素都是正整数。
//你可以进行以下操作任意次数：
//将数组 nums 中任意元素增加 1。
//将数组 nums 中任意元素减少 1。
//每次操作的花费为 cost[i]，其中 cost[i] 是对 nums[i] 进行操作的花费。
//返回使得数组 nums 中的所有元素相等的最小总花费。
//思路：二分搜索，对nums里的value进行二分搜索；找到mid和mi+1的总开销；如果大了，更改left，如果小，更改right        
//时间复杂度: O(nlog(max-min))
//空间复杂度：O(1)
        public long MinCost(int[] nums, int[] cost)
        {
            int left = int.MaxValue;
            int right = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                left = Math.Min(nums[i], left);
                right = Math.Max(nums[i], right);
            }

            long res = 0;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                var totalCost1 = GetCost(nums, cost, mid);
                var totalCost2 = GetCost(nums, cost, mid + 1);
                res = Math.Min(totalCost1, totalCost2);

                if (totalCost1 > totalCost2)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return res;
        }

        private long GetCost(int[] nums, int[] cost, int num)
        {
            long totalCost = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                totalCost += (long)Math.Abs(nums[i] - num) * cost[i];
            }

            return totalCost;
        }