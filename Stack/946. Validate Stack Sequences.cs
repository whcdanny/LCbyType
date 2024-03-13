//Leetcode 946. Validate Stack Sequences med
//题意：题目要求判断给定的 pushed 和 popped 数组是否可以通过一系列的入栈和出栈操作得到。
//其中，pushed 数组表示元素入栈的顺序，popped 数组表示元素出栈的顺序。
//思路：stack 用一个辅助栈来模拟入栈和出栈的过程。
//遍历 pushed 数组中的每个元素，依次将元素入栈。
//在每次入栈操作后，判断栈顶元素是否等于 popped 数组中当前位置的元素。
//如果相等，则说明可以执行出栈操作，将栈顶元素出栈，并将 popped 数组的索引后移一位。
//最后判断栈是否为空，若为空则说明所有元素都成功出栈，返回 true；否则返回 false。
//时间复杂度: 遍历 pushed 和 popped 数组的时间复杂度均为 O(n)，其中 n 是数组的长度。
//空间复杂度：O(n)。
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int poppedIndex = 0;
            foreach (int num in pushed)
            {
                stack.Push(num);
                while (stack.Count > 0 && stack.Peek() == popped[poppedIndex])
                {
                    stack.Pop();
                    poppedIndex++;
                }
            }
            return stack.Count == 0;
        }