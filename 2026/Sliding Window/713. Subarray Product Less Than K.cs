//Leetcode 713. Subarray Product Less Than K med
//题意：在一个nums中，找出乘积小于k的所有子集
//思路：滑窗，如果当前窗口的乘积<k,那么res+=right-left+1; 如果>=k, 那么乘积/nums[left]，直到<k;
// 特判：如果 k <= 1，因为 nums[i] >= 1，所以乘积不可能小于 k
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            // 特判：如果 k <= 1，因为 nums[i] >= 1，所以乘积不可能小于 k
            if (k <= 1) return 0;

            int res = 0;
            int left = 0;
            int product = 1; 

            for (int right = 0; right < nums.Length; right++)
            {
                product *= nums[right];

                // 这里的循环不需要 left <= right，因为 product 最终会变为 1 (当窗口为空时)
                // 且由于 k > 1，product < k 最终一定会成立
                while (product >= k)
                {
                    product /= nums[left];
                    left++;
                }

                // 以 right 结尾的连续子数组个数刚好是窗口的长度
                res += right - left + 1;
            }

            return res;
        }
//思路：暴力算法， 固定left然后right历遍满足<k，然后res += right - left + 1;   
//时间复杂度: O(n^2)
//空间复杂度：O(1)
        public int NumSubarrayProductLessThanK1(int[] nums, int k)
        {
            int res = 0;
            int left = 0;
            while (left < nums.Length)
            {
                int right = left;
                int preSum = nums[left];                
                while (preSum < k)
                {
                    right++;
                    if (right < nums.Length)
                    {
                        preSum *= nums[right];
                    }
                    else
                    {
                        break;
                    }                    
                }
                right--;
                res += right - left + 1;
                left++;
            }
            return res;
        }