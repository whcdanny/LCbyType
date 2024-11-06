//Leetcode 3212. Count Submatrices With Equal Frequency of X and Y med
//题目：给定一个二维字符矩阵 grid，其中 grid[i][j] 的值为 'X', 'Y', 或 '.'。要求返回符合以下条件的子矩阵的数量：
//该子矩阵包含位置 grid[0][0]。
//'X' 和 'Y' 的出现频率相等。
//至少包含一个 'X'。
//思路: preSum，建立两个x和y对应grid的每个位置之前的总和
//从0，0开始记录每个位置X,Y的个数，然后更新每个列的上一行
//外层循环：
//遍历每一行 i。
//对每一行中的每一列 j，逐列累计 'X' 和 'Y' 的数量。
//累计每一行中的 X 和 Y 的数量：
//对于每一列 j，累加 'X' 和 'Y' 出现的次数，分别存储在 vx 和 vy 中。
//然后将 vx 和 vy 赋值给 xvalue[i, j] 和 yvalue[i, j]。
//preSum累积计算：
//如果 i > 0，则通过 xvalue[i - 1, j] 和 yvalue[i - 1, j] 把之前行的累计值加到当前行，以实现从 grid[0][0] 到 grid[i][j] 子矩阵的累积效果。
//如果xvalue大于0并且x和y的个数相同说明满足条件；
//时间复杂度：O(rows * cols)
//空间复杂度：O(rows * cols)
        public int NumberOfSubmatrices(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int[,] xvalue = new int[rows, cols];
            int[,] yvalue = new int[rows, cols];
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                int xcount = 0;
                int ycount = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 'X')
                    {
                        xcount++;
                    }
                    if (grid[i][j] == 'Y')
                    {
                        ycount++;
                    }
                    xvalue[i, j] = xcount;
                    yvalue[i, j] = ycount;
                    if (i > 0)
                    {
                        xvalue[i, j] += xvalue[i - 1, j];
                        yvalue[i, j] += yvalue[i - 1, j];
                    }
                    if (xvalue[i, j] > 0 && xvalue[i, j] == yvalue[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }