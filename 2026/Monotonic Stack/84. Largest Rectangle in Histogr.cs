//Leetcode 84. Largest Rectangle in Histogram hard
//题意：给一个柱状图的int[], 找出一共长方形，面积最大
//思路：单调栈（Monotonic Stack），里面存入一共递增的高度的位置，
//当新的height存入，跟stack里位置的高度比对，如果低了，那么这个位置就是i-1是右边界
//然后找出左边界，然后width是i - stack.Peek() - 1，如果stack.Count == 0，就是i
//注：临界问题，当 i == n 时，我们视作一个高度为 0 的虚拟柱子，用以清空栈内剩余元素
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int LargestRectangleArea(int[] heights)
        {            
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            int n = heights.Length;

            for (int i = 0; i <= n; i++)
            {
                // 当 i == n 时，我们视作一个高度为 0 的虚拟柱子，用以清空栈内剩余元素
                int currentHeight = (i == n) ? 0 : heights[i];

                // 如果当前柱子高度小于栈顶柱子的高度，说明找到了栈顶柱子的右边界
                while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    // 弹出后，新的栈顶就是左边界
                    int width = (stack.Count == 0) ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }

            return maxArea;
        }