//Leetcode 644. Maximum Average Subarray II hard
//题意：在一个数组中找到长度至少为 k 的连续子数组，使得子数组的平均值最大。
//思路：二分法: 我们需要明确一个事实：如果存在一个长度为 k 的子数组，它的平均值大于等于 x，那么一定存在一个长度为 k 的子数组，它的平均值大于等于 x 的子数组。利用这个特性，我们可以使用二分法来逼近目标平均值。在每一次迭代中，我们可以计算中间值 mid，然后检查是否存在长度至少为 k 的子数组，其平均值大于等于 mid。
//时间复杂度:  n 是数组的长度, O(n)
//空间复杂度： O(n)        
        public double FindMaxAverage(int[] nums, int k)
        {
            double left = double.MaxValue, right = double.MinValue;

            foreach (int num in nums)
            {
                left = Math.Min(left, num);
                right = Math.Max(right, num);
            }

            while (right - left > 1e-5)
            {
                double mid = left + (right - left) / 2;
                if (Check(nums, k, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            return right;
        }

        private bool Check(int[] nums, int k, double mid)
        {
            double[] prefixSum = new double[nums.Length];
            double minSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum[i] = (i > 0 ? prefixSum[i - 1] : 0) + nums[i] - mid;
                if (i >= k - 1 && prefixSum[i] - minSum >= 0)
                {
                    return true;
                }
                if (i >= k - 1)
                {
                    minSum = Math.Min(minSum, prefixSum[i - k + 1]);
                }
            }

            return false;
        }