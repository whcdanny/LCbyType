//Leetcode 152. Maximum Product Subarray med
//题目：给定一个整数数组nums，找到一个子阵列
//具有最大乘积的那个，并返回该乘积。
//生成测试用例时，答案将适合32 位整数。
//思路: 给出maxProduct，globalMax，globalMin
//然后起始都是nums[0], localMax = globalMax * nums[i];localMin = globalMin * nums[i];
//然后每次放入nums[i]就更新maxProduct，globalMax，globalMin,
//最后更新maxproduct
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxProduct(int[] nums)
        {
            int maxProduct = nums[0];

            int globalMax = nums[0];
            int globalMin = nums[0];

            for (int i = 1; i < nums.Length; ++i)
            {
                int localMax = globalMax * nums[i];
                int localMin = globalMin * nums[i];

                globalMax = Math.Max(localMin, localMax);
                globalMax = Math.Max(nums[i], globalMax);

                globalMin = Math.Min(localMin, localMax);
                globalMin = Math.Min(nums[i], globalMin);

                maxProduct = Math.Max(maxProduct, globalMax);
            }

            return maxProduct;
        }