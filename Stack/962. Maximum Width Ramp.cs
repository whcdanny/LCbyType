//Leetcode 962. Maximum Width Ramp med
//题意：给定一个整数数组 nums，ramp 表示数组中一个满足条件的区间 (i, j)，其中 i < j 且 nums[i] <= nums[j]。该区间的宽度为 j - i。
//要求找出 nums 中最大的 ramp 的宽度。
//思路：stack 使用一个单调递减栈，栈中存储的是数组元素的索引。
//遍历数组 nums，对于每个元素 nums[i]，我们需要将其索引入栈，但是要保持栈中的元素是单调递减的。
//遍历过程中，如果当前元素 nums[i] 大于栈顶元素对应的值 nums[stack.Peek()]，
//则栈顶元素对应的索引不再满足单调递减的条件，我们可以将其出栈，并计算当前索引 i 与栈顶元素对应索引之间的宽度，更新结果。
//最后返回结果。
//时间复杂度: O(n)，其中 n 是数组的长度
//空间复杂度：O(n)。
        public int MaxWidthRamp(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            int maxRampWidth = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (stack.Count == 0 || nums[i] < nums[stack.Peek()])
                {
                    stack.Push(i);
                }
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[i] >= nums[stack.Peek()])
                {
                    maxRampWidth = Math.Max(maxRampWidth, i - stack.Pop());
                }
            }
            return maxRampWidth;
        }