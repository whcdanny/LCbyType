//Leetcode 503. Next Greater Element II med
//题意：给定一个循环整数数组 nums（即 nums[nums.length - 1] 的下一个元素是 nums[0]），返回每个元素在 nums 中的下一个更大的数字。
//一个数 x 的下一个更大的数字是在数组中 x 的顺序遍历中，第一个比它更大的数字，这意味着你可以循环搜索以找到它的下一个更大的数字。如果不存在，则为此数字返回 -1。
//思路：Stack+ monotomic stack 单调递减栈来寻找下一个更大的元素。遍历数组时，将元素的索引入栈。
//如果当前元素比栈顶元素大，则说明栈顶元素的下一个更大元素就是当前元素。将栈顶元素弹出，并记录其下一个更大元素为当前元素。
//最后，对于栈中剩余的元素，它们的下一个更大元素都不存在，因此将其对应的结果置为 -1。
//返回结果数组。
//时间复杂度：O(n)，其中 n 是数组的长度。每个元素最多入栈一次，出栈一次，因此时间复杂度为 O(n)。
//空间复杂度：O(n) 
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>(); // 存放元素的索引

            for (int i = 0; i < 2 * n; i++)
            {
                int index = i % n; // 取模获取原数组中的索引
                while (stack.Count > 0 && nums[index] > nums[stack.Peek()])
                {
                    result[stack.Pop()] = nums[index]; // 更新下一个更大元素
                }
                if (i < n)
                {
                    stack.Push(index); // 将索引入栈
                }
            }

            return result;
        }