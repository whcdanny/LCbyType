//Leetcode 1441. Build an Array With Stack Operations med
//题意：给定一个整数数组 target 和一个整数 n。有一个空栈，支持两种操作："Push"（将整数推入栈顶）和"Pop"（移除栈顶的整数）。同时有一个范围为 [1, n] 的整数流。
//使用这两种栈操作，使得栈中的整数（从底部到顶部）等于数组 target。操作规则如下：
//如果整数流不为空，则从流中取下一个整数，并将其推入栈顶。
//如果栈不为空，则弹出栈顶的整数。
//如果在任意时刻，栈中的元素（从底部到顶部）等于 target，则不再从整数流中读取新的整数，也不再对栈执行更多的操作。
//返回构建 target 所需的栈操作。如果存在多个有效答案，则返回其中的任意一个。
//思路：Stack, 遍历数组 target，对于每个元素 num，首先将 [1, num-1] 的整数依次推入栈中，然后将 num 推入栈中。
//检查添加的current是否为target[i]，如果是则i++，如果不是那么就stack弹出，并写入list（pop）；
//时间复杂度：O(n)，其中 n 是数组 target 的长度。
//空间复杂度：O(n)，额外使用了一个栈。
        public IList<string> BuildArray(int[] target, int n)
        {
            int current = 1;
            List<string> list = new List<string>();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < target.Length;)
            {
                stack.Push(current);
                current++;
                list.Add("Push");
                if (stack.Peek() == target[i])
                {
                    i++;
                }
                else
                {
                    stack.Pop();
                    list.Add("Pop");
                }
            }
            return list;
        }