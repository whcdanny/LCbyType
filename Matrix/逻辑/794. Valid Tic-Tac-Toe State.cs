//794. Valid Tic-Tac-Toe State med
//题目：给定一个井字棋（Tic-Tac-Toe）棋盘状态，判断是否有可能通过有效的游戏操作达到该棋盘状态。
//棋盘为一个 
//3×3 的字符串数组 board，包含字符 ' ', 'X', 和 'O'。
//' ' 表示空格。'X' 表示玩家1的棋子。'O' 表示玩家2的棋子。
//游戏规则：
//玩家轮流操作，先手玩家下 'X'，后手玩家下 'O'。
//玩家只能将棋子下在空格处。
//游戏结束条件：
//任意一行、列或对角线中有连续三个相同的非空字符。
//所有格子都填满。
//游戏结束后不能继续操作。
//返回 true 如果棋盘状态是有效的，否则返回 false。
//思路：'X' 和 'O' 的数量关系：
//先手总是下 'X'，后手下 'O'，因此 'X' 的数量总是大于等于 'O' 的数量，且两者之差最多为1。
//即：countX >= countO 且 countX - countO <= 1。
//胜利状态的约束：
//如果 'X' 赢（连续三个 'X'），则 'X' 的数量必须比 'O' 多 1。
//如果 'O' 赢（连续三个 'O'），则 'X' 的数量必须等于 'O'。
//不能同时有两个赢家：
//如果两个玩家都满足胜利条件，则该状态无效。
//对棋盘的分析：
//需要检查每一行、列和对角线是否满足胜利条件。
//时间复杂度:  O(1)
//空间复杂度： O(1)
        public bool ValidTicTacToe(string[] board)
        {
            int countX = 0, countO = 0;

            // 统计 'X' 和 'O' 的数量
            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    if (cell == 'X') countX++;
                    if (cell == 'O') countO++;
                }
            }

            // 'X' 和 'O' 的数量关系必须满足
            if (countO > countX || countX - countO > 1)
                return false;

            // 检查是否有赢家
            bool xWin = IsWinner_ValidTicTacToe(board, 'X');
            bool oWin = IsWinner_ValidTicTacToe(board, 'O');

            // 如果 'X' 赢，必须比 'O' 多一个
            if (xWin && countX != countO + 1)
                return false;

            // 如果 'O' 赢，必须与 'X' 数量相等
            if (oWin && countX != countO)
                return false;

            // 不可能同时两个玩家赢
            if (xWin && oWin)
                return false;

            return true;
        }
        private bool IsWinner_ValidTicTacToe(string[] board, char player)
        {
            // 检查每一行
            for (int i = 0; i < 3; i++)
            {
                if (board[i][0] == player && board[i][1] == player && board[i][2] == player)
                    return true;
            }

            // 检查每一列
            for (int i = 0; i < 3; i++)
            {
                if (board[0][i] == player && board[1][i] == player && board[2][i] == player)
                    return true;
            }

            // 检查两条对角线
            if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
                return true;

            if (board[0][2] == player && board[1][1] == player && board[2][0] == player)
                return true;

            return false;
        }