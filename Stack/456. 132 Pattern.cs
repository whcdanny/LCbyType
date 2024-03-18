//Leetcode 456. 132 Pattern med
//题意：给定一个由 n 个整数组成的数组 nums，一个 132 模式是一个由三个整数组成的子序列 nums[i]、nums[j] 和 nums[k]，满足 i < j < k 且 nums[i] < nums[k] < nums[j]。
//如果数组 nums 中存在 132 模式，则返回 true；否则，返回 false。
//思路：Stack从右向左遍历数组 nums，用一个变量 max_k 来记录已经遍历过的元素中的最大值，代表了 nums[k]。
//我们使用一个栈来存储 nums[j]，栈顶元素是当前找到的 132 模式中的 nums[j]。
//在遍历过程中，如果遇到的元素 nums[i] 小于 max_k，说明找到了一个满足条件的 132 模式，返回 true。
//否则，我们不断地弹出栈顶元素，直到栈为空或者栈顶元素小于当前的元素 nums[i]，同时更新 max_k 为栈顶元素。
//最后，如果遍历完成还没有找到 132 模式，则返回 false。
//注：相当于k>j>i，所以从后往前，然后找到大于max_k位置就满足 nums[k] < nums[j]，然后只要找到一个nums[i] < nums[k]，就是132；
//时间复杂度：O(n)，其中 n 是数组 nums 的长度。
//空间复杂度：O(n) 
        public bool Find132pattern(int[] nums)
        {
            if (nums == null || nums.Length < 3) return false;

            Stack<int> stack = new Stack<int>();
            int max_k = int.MinValue;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] < max_k) return true;

                while (stack.Count > 0 && nums[i] > stack.Peek())
                {
                    max_k = stack.Pop();
                }

                stack.Push(nums[i]);
            }

            return false;
        }