//Leetcode 3256. Maximum Value Sum by Placing Three Rooks II hard
//题目：在一个 m x n 的二维数组 board 中，每个单元格 (i, j) 都有一个值 board[i][j]，表示棋盘上的得分。
//题目要求在棋盘上放置三个车（Rook），使得这些车不在同一行或同一列，且放置的位置得分和最大化。
//思路:建立一个二维数组，存入所有的位置，然后存入每个位置i,j board[i][j]
//然后对数组排序，board[i][j]按值从大到小排序
//先选定两个位置，保证不能在同一行，同一列，
//然后找第三个，也要保证不能同一行，同一列。
//时间复杂度：O((m * n) log(m * n))，其中m是行数，n是列数。O((m * n)^3)
//空间复杂度：O(m * n)
        public long MaximumValueSum1(int[][] board)
        {
            int row = board.Length, col = board[0].Length;
            int[][] allElems = new int[row * col][];
            int pos = 0;

            // 将二维数组的每个元素存入allElems数组中
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    allElems[pos] = new int[] { i, j, board[i][j] };
                    pos++;
                }
            }

            // 使用Array.Sort排序allElems数组，按值从大到小排序
            Array.Sort(allElems, new Comparison<int[]>((a, b) => b[2].CompareTo(a[2])));

            long maxSum = 3L * int.MinValue;

            // 尝试选择三个不在同一行或列的最大元素组合
            for (int i = 0; i < row * col; i++)
            {
                for (int j = i + 1; j < row * col; j++)
                {
                    // 如果i和j在同一行或同一列，则跳过
                    if (allElems[i][0] == allElems[j][0] || allElems[i][1] == allElems[j][1])
                    {
                        continue;
                    }
                    long curSum = allElems[i][2] + allElems[j][2];

                    // 若加上第三个数的值仍不超过当前最大值，则无需继续搜索
                    if (curSum + allElems[j][2] <= maxSum)
                    {
                        break;
                    }

                    // 尝试找到第三个满足条件的元素
                    for (int k = j + 1; k < row * col; k++)
                    {
                        if (curSum + allElems[k][2] <= maxSum)
                        {
                            break;
                        }
                        // 如果k与i和j在同一行或同一列，则跳过
                        if (allElems[k][0] == allElems[i][0] || allElems[k][1] == allElems[i][1] ||
                            allElems[k][0] == allElems[j][0] || allElems[k][1] == allElems[j][1])
                        {
                            continue;
                        }

                        // 更新最大和
                        maxSum = curSum + allElems[k][2];
                        break;
                    }
                }
            }

            return maxSum;
        }