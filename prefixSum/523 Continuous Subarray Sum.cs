//Leetcode 523 Continuous Subarray Sum med
//题意：给定一个包含非负整数的数组和一个目标整数 k，判断是否存在连续的子数组，使得子数组的和等于 k 的倍数。
//思路：前缀和（Prefix Sum）和模运算来解决。我们可以利用前缀和数组 prefixSum，其中 prefixSum[i] 表示数组中前 i+1 个元素的和。首先，我们需要找到子数组的和能够整除 k 的情况。如果 prefixSum[i] 与 prefixSum[j] 对 k 取模的结果相同，那么说明从第 i+1 个元素到第 j 个元素之间的子数组的和是 k 的倍数。
//时间复杂度：O(n)
//空间复杂度：O(min(n, k))
        public bool CheckSubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict[0] = -1;
            int currentSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];
                int mod = k != 0 ? currentSum % k : currentSum;

                if (dict.ContainsKey(mod))
                {
                    if (i - dict[mod] >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    dict[mod] = i;
                }
            }

            return false;
        }