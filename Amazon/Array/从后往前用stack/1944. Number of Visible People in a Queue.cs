//Leetcode 1944. Number of Visible People in a Queue hard
//题意：给定一个由 n 个人组成的队列，编号从 0 到 n - 1，从左到右排列。给定一个数组 heights，其中 heights[i] 表示第 i 个人的身高。
//如果一个人能够看到队列中右边的另一个人，那么表示这个人能够看到的人数为两者之间所有人身高都小于这两个人的身高。
//更正式地说，第 i 个人能够看到第 j 个人，如果 i<j，并且 min(heights[i], heights[j]) > max(heights[i + 1], heights[i + 2], ..., heights[j - 1])。
//要求返回一个数组 answer，其中 answer[i] 表示第 i 个人能够看到队列中右边的人数。        
//思路：stack, 从后往前遍历队列中的每个人，使用一个栈来记录身高。
//stack里存的是一个身高递增，也就是说如果当前身高，高于stack最上面的，那么pop，
//然后res++, 因为我们可以看到第一个比自己矮，
//我们也可以看到第一个比自己大，所以如果stack.Count > 0 res++；
//时间复杂度：O(n)。
//空间复杂度：O(n)。
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
                if (stack.Count > 0) 
                    answer[i]++; // 当前人能够看到栈顶的人
                stack.Push(heights[i]); // 将当前人的身高入栈
            }

            return answer;
        }