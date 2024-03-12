//Leetcode 1526. Minimum Number of Increments on Subarrays to Form a Target Array hard
//题意：给定一个整数数组 target。你有一个初始数组 initial，初始数组的大小与 target 相同，初始数组中的所有元素都是零。
//在一个操作中，你可以选择初始数组中的任意子数组，并将其中的每个值增加一。
//返回从初始数组形成目标数组所需的最小操作次数。
//思路：Stack,创建了一个栈 st，用来存储每次遍历到的目标数组元素，初始时将第一个元素 target[0] 入栈。
//接下来，从目标数组的第二个元素开始遍历，对于每个目标数组元素 target[i]：
//获取栈顶元素 top，表示当前初始数组的最后一个元素。
//如果 top 小于 target[i]，说明需要进行操作，操作次数为 target[i] - top，将操作次数累加到 sum 中。
//将 target[i] 入栈，更新栈顶元素。
//时间复杂度：O(n)，其中 n 是目标数组 target 的长度
//空间复杂度：O(n)
        public int MinNumberOperations(int[] target)
        {
            int sum = target[0], len = target.Length;
            Stack<int> stack = new Stack<int>();
            stack.Push(sum);
            for (int i = 1; i < len; i++)
            {
                int top = stack.Peek();
                if (top < target[i])
                    sum += target[i] - top;
                stack.Push(target[i]);
            }
            return sum;
        }