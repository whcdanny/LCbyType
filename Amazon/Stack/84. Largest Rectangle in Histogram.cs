//Leetcode 84. Largest Rectangle in Histogram med
//题意：给定一个整数数组 heights，表示柱状图的高度，其中每个柱子的宽度为 1。返回柱状图中最大矩形的面积。
//思路：Stack + monotomic stack 
//单调栈来解决这个问题。单调栈可以帮助我们找到柱子左右两边第一个小于当前柱子高度的位置，从而计算出以当前柱子为高度的最大矩形面积。
//我们遍历每个柱子，如果当前柱子的高度大于栈顶柱子的高度，我们将其入栈；
//否则，我们将栈顶的柱子依次出栈，计算以出栈柱子为高度的最大矩形面积，并更新最大面积值。
//我们需要记录每个柱子出栈时左右两边第一个小于其高度的柱子位置，以便计算矩形的宽度。
//当遍历完所有柱子后，如果栈中还有柱子，我们依次将其出栈，并根据其高度计算以其为高度的最大矩形面积。
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0, n = heights.Length;
            for (int i = 0; i <= n; i++)
            {
                int h = (i < n) ? heights[i] : 0;
                while (stack.Count > 0 && h < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = (stack.Count > 0) ? i - stack.Peek() - 1 : i;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }
            return maxArea;
        }