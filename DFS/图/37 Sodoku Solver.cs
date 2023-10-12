//Leetcode 37 Sodoku Solver hard
//题意：填充数独的问题
//思路：深度优先搜索（DFS）: 遍历数独格子，当遇到空格时，尝试填充数字 1 到 9，并进行递归搜索。在递归搜索中，我们使用上述编写的函数来判断当前数字是否合法，如果合法就继续填充下一个空格。如果递归搜索的过程中发现填充的数字无法满足数独规则，就需要回溯，将当前位置重新设为空格。
//时间复杂度: n 是数独的边长（通常为 9） O(9^(n*n))
//空间复杂度： O(n*n)
        public void SolveSudoku(char[][] board)
        {
            Solve_SolveSudoku(board);
        }

        private bool Solve_SolveSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValidSudoku(board, i, j, c))
                            {
                                board[i][j] = c;
                                if (Solve_SolveSudoku(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board[i][j] = '.';
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValidSudoku(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                //同一行是否已经存在数字, 同一列是否已经存在数字,检查同一个 3x3 子格子内是否已经存在数字
                if (board[row][i] == c || board[i][col] == c || board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c)
                {
                    return false;
                }
            }
            return true;
        }