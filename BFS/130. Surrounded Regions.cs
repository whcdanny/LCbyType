//Leetcode 130. Surrounded Regions med
//题意：题目要求对一个二维矩阵进行处理，将被 'X' 包围的区域中的 'O' 修改为 'X'，而不被 'X' 包围的区域中的 'O' 保持不变。
//思路：广度优先搜索（BFS）序列化： 首先遍历矩阵的四条边，将与边界相连的 'O' 及其相邻的 'O' 标记为特殊字符（如 '#'）,然后遍历整个矩阵，将所有剩余的 'O' 修改为 'X'，将特殊字符 '#' 恢复为 'O'
//时间复杂度:  O(m * n)
//空间复杂度：O(1)
        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0) return;

            int m = board.Length;
            int n = board[0].Length;

            // Step 1: Traverse the four edges and mark connected 'O' as special character '#'
            for (int i = 0; i < m; i++)
            {
                if (board[i][0] == 'O') Mark(board, i, 0);
                if (board[i][n - 1] == 'O') Mark(board, i, n - 1);
            }
            for (int j = 0; j < n; j++)
            {
                if (board[0][j] == 'O') Mark(board, 0, j);
                if (board[m - 1][j] == 'O') Mark(board, m - 1, j);
            }
            // Step 2: Traverse the whole board, change remaining 'O' to 'X', restore '#' to 'O'
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O') board[i][j] = 'X';
                    if (board[i][j] == '#') board[i][j] = 'O';
                }
            }
        }

        private void Mark(char[][] board, int i, int j)
        {
            int m = board.Length;
            int n = board[0].Length;
            if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != 'O') return;
            board[i][j] = '#';
            Mark(board, i + 1, j);
            Mark(board, i - 1, j);
            Mark(board, i, j + 1);
            Mark(board, i, j - 1);
        }