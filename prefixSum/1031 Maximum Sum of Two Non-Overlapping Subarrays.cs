//Leetcode 1031 Maximum Sum of Two Non-Overlapping Subarrays med
//题意：给定一个整数数组 nums，找到两个不重叠的子数组 firstLen 和 secondLen，使得 firstLen 中的元素和与 secondLen 中的元素和之和最大。返回这个最大值。具体地，假设 firstLen 长度为 l，secondLen 长度为 m，且满足 l + m <= length(A)。
//思路：前缀和（Prefix Sum）, 先根据firstLen的窗口来算firstSum，然后根据这个窗口再找前面或者后面是否有secondLen的窗口位置 然后算secondSum，然后找出MAX;
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
        {
            int n = nums.Length;
            int[] prefixSum = new int[n + 1];
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + nums[i];
            }

            for(int i = firstLen; i <= n; i++)
            {
                int firstSum = prefixSum[i] - prefixSum[i - firstLen];
                for(int j = secondLen; j <= i - firstLen; j++)
                {
                    int secondSum = prefixSum[j] - prefixSum[j - secondLen];
                    res = Math.Max(res, firstSum + secondSum);
                }
                for(int k = i+secondLen; k <= n; k++)
                {
                    int secondSum = prefixSum[k] - prefixSum[k - secondLen];
                    res = Math.Max(res, firstSum + secondSum);
                }
            }
            return res;
        }