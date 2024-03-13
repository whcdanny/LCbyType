//Leetcode 907. Sum of Subarray Minimums med
//题意：题目要求给定一个整数数组 arr，找到数组 arr 的所有子数组中的最小值，然后计算这些最小值的总和，并对结果取模 10^9 + 7。
//思路：stack + Monotonic 单调栈来处理，遍历数组 arr。
//维护两个数组 left 和 right，其中 left[i] 表示以 arr[i] 为最小值的连续子数组的左边界（即 arr[i] 左边第一个小于 arr[i] 的元素的下标），
//right[i] 表示以 arr[i] 为最小值的连续子数组的右边界（即 arr[i] 右边第一个小于等于 arr[i] 的元素的下标）。
//计算以 arr[i] 为最小值的子数组的个数，即 count = (i - left[i]) * (right[i] - i)。
//将 arr[i] 乘以 count 加入结果中。
//最后返回结果对 10^9 + 7 取模的值。
//时间复杂度: O(n)，其中 n 是数组 arr 的长度
//空间复杂度：O(n)。
        public int SumSubarrayMins(int[] arr)
        {
            int MOD = (int)Math.Pow(10, 9) + 7;
            int n = arr.Length;
            long sum = 0;
            int[] left = new int[n];
            int[] right = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                left[i] = stack.Count > 0 ? stack.Peek() : -1;
                stack.Push(i);
            }
            stack.Clear();
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
                {
                    stack.Pop();
                }
                right[i] = stack.Count > 0 ? stack.Peek() : n;
                stack.Push(i);
            }
            for (int i = 0; i < n; i++)
            {
                sum = (sum + (long)arr[i] * (i - left[i]) * (right[i] - i)) % MOD;
            }
            return (int)sum;
        }