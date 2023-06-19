//644. Maximum Average Subarray II hard: 在一个整数数组中找到长度至少为 k 的连续子数组，使得其平均值最大
//思路：二分查找；left 为数组中最小的元素，right 为数组中最大的元素；如果存在平均值大于等于目标平均值的子数组，说明目标平均值可能更大，更新左边界为 mid。
//如果所有子数组的平均值都小于目标平均值，说明目标平均值不可能达到当前值，更新右边界为 mid
        public double FindMaxAverage(int[] nums, int k)
        {
            double left = double.MaxValue;
            double right = double.MinValue;

            // 找到数组中的最小值和最大值
            foreach (int num in nums)
            {
                left = Math.Min(left, num);
                right = Math.Max(right, num);
            }

            while (left < right - 0.00001)
            {
                double mid = (left + right) / 2;

                if (check(nums, mid, k))
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
        
        private bool check(int[] nums, double target, int k)
        {
            double sum = 0;
            double prevSum = 0;
            double minPrevSum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += nums[i] - target;
            }

            if (sum >= 0)
            {
                return true;
            }

            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i] - target;
                prevSum += nums[i - k] - target;
                minPrevSum = Math.Min(minPrevSum, prevSum);

                if (sum - minPrevSum >= 0)
                {
                    return true;
                }
            }

            return false;
        }