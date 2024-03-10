//Leetcode 1944. Number of Visible People in a Queue hard
//题意：给定一个由 n 个人组成的队列，编号从 0 到 n - 1，从左到右排列。给定一个数组 heights，其中 heights[i] 表示第 i 个人的身高。
//如果一个人能够看到队列中右边的另一个人，那么表示这个人能够看到的人数为两者之间所有人身高都小于这两个人的身高。
//更正式地说，第 i 个人能够看到第 j 个人，如果 i<j，并且 min(heights[i], heights[j]) > max(heights[i + 1], heights[i + 2], ..., heights[j - 1])。
//要求返回一个数组 answer，其中 answer[i] 表示第 i 个人能够看到队列中右边的人数。
//思路：Stack, 从头开始，当i的时候，如果比前面的小，那么相对于前一个就是前一个能看到他，
//如果比前面的大，那么就在stack依此找到比他小的，说明这小的最后一个看到的只能是当前i，所以他们的可视+1，并且弹出
//时间复杂度：遍历一次数组，每个人最多入栈一次和出栈一次，因此时间复杂度为 O(n)。
//空间复杂度：使用了一个栈来存储身高，最坏情况下空间复杂度为 O(n)。
        public int[] CanSeePersonsCount(int[] heights)
        {
            int[] ans = new int[heights.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                int height = heights[i];
                while (stack.Count != 0 && heights[stack.Peek()] <= height)
                {
                    ans[stack.Pop()] += 1;
                }
                if (stack.Count != 0)
                {
                    ans[stack.Peek()] += 1;
                }
                stack.Push(i);
            }
            return ans;
        }
        //思路：遍历队列中的每个人，使用一个栈来记录可以被当前人看到的人的身高。
        //当遍历到第 i 个人时，将栈中所有身高大于等于当前人身高的人全部出栈，并记录出栈的数量，这些人都可以被第 i 个人看到。
        //将当前人的身高入栈，表示当前人可以被后面的人看到。
        //返回结果数组 answer。
        //时间复杂度：遍历一次数组，每个人最多入栈一次和出栈一次，因此时间复杂度为 O(n)。
        //空间复杂度：使用了一个栈来存储身高，最坏情况下空间复杂度为 O(n)。
        public int[] CanSeePersonsCount1(int[] heights)
        {
            int n = heights.Length;
            int[] answer = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[i] > stack.Peek())
                {
                    answer[i]++;
                    stack.Pop(); // 将栈中所有身高大于等于当前人身高的人全部出栈
                }
                if (stack.Count > 0) answer[i]++; // 当前人能够看到栈顶的人
                stack.Push(heights[i]); // 将当前人的身高入栈
            }

            return answer;
        }