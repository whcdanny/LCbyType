//Leetcode 1504. Count Submatrices With All Ones med
//题意：给定一个二维的二进制矩阵 mat，要求计算出矩阵中所有元素都为 1 的子矩阵的数量。
//思路：Stack,计算子矩阵中所有元素都为 1 的数量，可以利用动态规划和栈来解决。以下是具体的步骤：
//首先，遍历矩阵的每一行，将每一行作为底部，统计以该行为底部的连续 1 的个数。这样可以将问题转化为求以每一行为底部的矩阵中所有元素都为 1 的子矩阵的数量。
//对于每一行，将其视为柱状图，统计每个位置的高度，即该位置向上连续 1 的个数。
//这可以利用动态规划来实现，对于每一行的每个位置，如果该位置为 1，则高度为上一行该位置高度加 1，否则高度为 0。
//对于每一行的柱状图，可以利用单调栈来计算以该行为底部的所有矩阵中所有元素都为 1 的子矩阵的数量。
//具体做法是维护一个单调递增栈，栈中存放的是当前行中各个位置的高度对应的列索引。
//遍历每一行的柱状图，对于每个高度 h，计算以当前行为底部、高度为 h 的子矩阵的数量。
//遍历过程中，对于每个高度 h，计算当前列索引与栈顶元素之间的距离，即可以得到以当前行为底部、高度为 h 的子矩阵的宽度。
//这样就可以得到以当前行为底部、高度为 h 的子矩阵的数量，即宽度乘以高度。
//将所有行的子矩阵数量累加起来，即可得到矩阵中所有元素都为 1 的子矩阵的总数量。
//时间复杂度：O(m*n) 的时间。对于每一行，需要 O(n) 的时间来计算柱状图的高度，并利用单调栈计算子矩阵的数量。 m 和 n 分别是矩阵的行数和列数。
//空间复杂度：O(n)
        public int NumSubmat(int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;
            int[][] heights = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                heights[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                    {
                        heights[i][j] = mat[i][j];
                    }
                    else
                    {
                        heights[i][j] = mat[i][j] == 0 ? 0 : heights[i - 1][j] + 1;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < rows; i++)
            {
                result += CountSubmat(heights[i]);
            }

            return result;
        }
        private int CountSubmat(int[] heights)
        {
            int[] count = new int[heights.Length];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    count[i] = count[stack.Peek()];
                    count[i] += heights[i] * (i - stack.Peek());
                }
                else
                {
                    count[i] = heights[i] * (i + 1);
                }
                stack.Push(i);
            }

            int total = 0;
            foreach (int c in count)
            {
                total += c;
            }
            return total;
        }