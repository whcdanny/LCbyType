//Leetcode 1381. Design a Stack With Increment Operation med
//题意：设计一个栈，支持以下操作：
//CustomStack(int maxSize)：初始化一个最大容量为maxSize的栈。
//void Push(int x)：将元素x添加到栈顶，如果栈未满。
//int Pop()：弹出并返回栈顶元素，如果栈为空则返回-1。
//void Increment(int k, int val)：将栈底的前k个元素增加val，如果栈中元素不足k个，则将所有元素都增加val。
//思路：Stack, 我们可以使用一个数组来存储栈的元素，同时使用另一个数组来存储每个元素的增量。
//在 Push 操作中，我们将元素添加到数组的末尾；
//在 Pop 操作中，我们从数组末尾取出元素，并将其与对应位置的增量相加，同时将增量传递给下一个位置；
//在 Increment 操作中，我们将前 k 个元素的增量加上 val。
//时间复杂度：Push：O(1) Pop：O(1) Increment：O(k)，其中 k 为参数值，我们需要更新前 k 个元素的增量。CustomStack：O(1)。
//空间复杂度：O(n)，其中 n 为栈的最大容量 maxSize，因为我们使用了两个大小为 n 的数组来存储栈的元素和增量。
        public class CustomStack
        {
            private int maxSize;
            private Stack<int> stack;
            private int[] increments;

            public CustomStack(int maxSize)
            {
                this.maxSize = maxSize;
                stack = new Stack<int>(maxSize);
                increments = new int[maxSize];
            }

            public void Push(int x)
            {
                if (stack.Count < maxSize)
                {
                    stack.Push(x);
                }
            }

            public int Pop()
            {
                if (stack.Count == 0)
                {
                    return -1;
                }
                int index = stack.Count - 1;
                int result = stack.Pop() + increments[index];
                if (index > 0)
                {
                    increments[index - 1] += increments[index];
                }
                increments[index] = 0;
                return result;
            }

            public void Increment(int k, int val)
            {
                int index = Math.Min(k, stack.Count) - 1;
                if (index >= 0)
                {
                    increments[index] += val;
                }
            }
        }