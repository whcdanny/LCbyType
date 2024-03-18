//Leetcode 85. Maximal Rectangle hard
//题意：给定一个充满和 的rows x cols 二进制，找到仅包含 的最大矩形并返回其面积。matrix011
//思路：Stack + 动态规划和单调栈 
//首先，我们将问题转化为以每一行为底边的最大矩形问题。我们定义一个二维数组 dp，其中 dp[i][j] 表示以第 i 行为底边，第 j 列为右边界的最大矩形的高度。
//我们可以使用动态规划来计算数组 dp。具体地，我们从第一行开始，对于每一行，我们根据上一行的 dp 值更新当前行的 dp 值。
//如果当前位置的元素为 1，则 dp[i][j] = dp[i - 1][j] + 1；如果当前位置的元素为 0，则 dp[i][j] = 0。
//接下来，对于每一行的 dp 值，我们可以使用单调栈来计算以当前行为底边的最大矩形面积。
//具体地，我们将 dp[i] 作为高度数组，然后使用单调栈来找到每个位置左右两侧第一个小于当前高度的位置，然后计算以当前位置为高度的最大矩形面积。
//最后，我们遍历每一行的 dp 值，并计算以每一行为底边的最大矩形面积，取最大值作为答案。
//思路总结：
//使用动态规划计算每一行的高度数组 dp。
//使用单调栈计算以每一行为底边的最大矩形面积。
//计算所有可能的最大矩形面积，取最大值作为答案。
//时间复杂度: O(rows * cols)
//空间复杂度：O(rows * cols)
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;
            int rows = matrix.Length, cols = matrix[0].Length;
            int[][] dp = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                dp[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        dp[i][j] = (i > 0) ? dp[i - 1][j] + 1 : 1;
                    }
                }
            }
            int maxArea = 0;
            for (int i = 0; i < rows; i++)
            {
                maxArea = Math.Max(maxArea, LargestRectangleArea(dp[i]));
            }
            return maxArea;
        }

        private int LargestRectangleArea(int[] heights)
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
