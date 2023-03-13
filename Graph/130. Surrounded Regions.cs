//130. Surrounded Regions med
//给你一个 M×N 的二维矩阵，其中包含字符 X 和 O，让你找到矩阵中四面被 X 围住的 O，并且把它们替换成 X。
//思路：先找外围，如给有O,肯定不行，然后用check[][] 来check是否被包围
		public void Solve(char[][] board)
        {
            if (board.Length == 0 || board[0].Length == 0 || board == null)
                return;
            int m = board.Length;
            int n = board[0].Length;
            bool[,] check = new bool[m, n];

            for (int i = 1; i < m - 1; i++)
            {
                checkO(board, check, i, 0);
                checkO(board, check, i, n - 1);
            }
            for (int i = 0; i < n; i++)
            {
                checkO(board, check, 0, i);
                checkO(board, check, m - 1, i);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O' && !check[i, j])
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }
        private void checkO(char[][] board, bool[,] check, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] == 'X' || check[i, j])
            {
                return;
            }
            check[i, j] = true;
            checkO(board, check, i + 1, j);
            checkO(board, check, i - 1, j);
            checkO(board, check, i, j + 1);
            checkO(board, check, i, j - 1);
        }