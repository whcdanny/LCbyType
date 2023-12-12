//Leetcode 419. Battleships in a Board med
//题意：给定一个二维数组 board，其中 'X' 表示战舰的一部分，'.' 表示空地。战舰的形状是水平或垂直的，并且不会有相邻的战舰。
//要求计算这个二维数组中有多少艘战舰。
//思路：（DFS）来解决这个问题。在遍历二维数组的过程中，当我们遇到一个 'X' 时，我们可以递归地标记这个战舰的所有部分，并将计数器加一。由于题目规定战舰的形状是水平或垂直的，我们可以简化判断。
//注：这里说白了x垂直或水平连着就证明是一艘船；
//时间复杂度: O(rows×cols) 
//空间复杂度：O(rows×cols)
        public int CountBattleships(char[][] board)
        {
            int count = 0;
            int rows = board.Length;
            int cols = board[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        count++;
                        DFS_CountBattleships(board, i, j);
                    }
                }
            }

            return count;
        }

        private void DFS_CountBattleships(char[][] board, int row, int col)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            if (row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] != 'X')
            {
                return;
            }

            board[row][col] = 'Y'; // Mark the visited cell

            DFS_CountBattleships(board, row + 1, col); // Move down
            DFS_CountBattleships(board, row, col + 1); // Move right
        }