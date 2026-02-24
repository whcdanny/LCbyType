//Leetcode 1856. Maximum Subarray Min-Product med
//题意：给一个nums找出Maximum Subarray Min-Product，意思是一个subarry中最小的值*这个subarry的和。
//思路：Monotonic stack 单调栈，找出以nums[i]为最小值的left和right边界，然后找出最大的那个值
//两个数组 left 和 right，其中 left[i] 表示以 arr[i] 为最小值的连续子数组的左边界，
//right[i] 表示以 arr[i] 为最小值的连续子数组的右边界。
//找出前缀和方便算出left和right区间的sum
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int MaxSumMinProduct(int[] nums)
        {
            long res = 0;
            int Mod = (int)Math.Pow(10, 9) + 7;
            int n = nums.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while(stack.Count>0 && nums[i] <= nums[stack.Peek()])
                {
                    stack.Pop();
                }
                left[i] = stack.Count > 0 ? stack.Peek() : -1;
                stack.Push(i);
            }
            stack.Clear();
            for(int i= n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                {
                    stack.Pop();
                }
                right[i] = stack.Count > 0 ? stack.Peek() : n;
                stack.Push(i);
            }
            long[] prefixSum = new long[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + nums[i];
            }
            for (int i = 0; i < n; i++)
            {
                int l = left[i] + 1;
                int r = right[i];
                long sum = prefixSum[r] - prefixSum[l];                
                res = Math.Max(res, (long)nums[i] * sum);
            }
            return (int)(res % Mod);
        }