//Leetcode 348. Design Tic-Tac-Toe  med
//题意：设计一个 Tic-Tac-Toe 游戏，使得两名玩家交替进行。说白了这题就是当有一个横，竖，正对角，反对角，有n的时候，n为这个矩阵的size，就获胜，因为有一条横线，或竖线，或斜对角，或正对角已经让一个人占了；
//TicTacToe(n)：构造函数nxn的矩阵，用于初始化游戏。
//move(row, col, player)：玩家在指定位置下棋，row和col代表下棋的位置，player代表玩家，取值为1或2，分别表示玩家1和玩家2.move条件：该位置是空的（即未被占据）。该位置下棋后，玩家能够获胜。
//思路：说白了这题就是当有一个横，竖，正对角，反对角，有n的时候，n为这个矩阵的size，就获胜，因为有一条横线，或竖线，或斜对角，或正对角已经让一个人占了；用1代表player1，-1代表player2；
//使用两个数组来记录每个玩家在行和列上的得分情况，并使用两个变量来记录对角线的得分情况。使用两个数组 rows 和 cols 分别记录每个玩家在行和列上的得分情况，数组的索引代表行或列的编号，数组的值表示得分。使用两个变量 diag 和 antiDiag 来记录对角线的得分情况。在每次玩家进行操作时，根据所在行和列的得分情况更新数组和变量，然后检查是否有玩家获胜。如果某个玩家在某行、某列或某对角线上获得了 n 分，则该玩家获胜。
//时间复杂度：每次操作的时间复杂度为 O(1)。
//空间复杂度：O(n)，其中 n 是棋盘的大小
        /*Tic-Tac-Toe（井字棋）是一种简单的棋类游戏，通常由两名玩家轮流进行。游戏目标是通过在一个3x3的棋盘上，以横、竖或斜的方式将三个自己的标记（通常是“X”或“O”）连成一条线。
          游戏规则如下：
            游戏开始时，棋盘为空，两名玩家轮流进行。
            玩家1通常执“X”，玩家2通常执“O”。
            每位玩家在自己的回合里，选择一个空的格子，将自己的标记放入其中。
            玩家不能在已经被占用的格子里放置自己的标记。
            玩家获胜条件：
                任何一行（水平、垂直、对角线）上都是相同标记（X或O）。
            所有格子都已填满但没有玩家获胜（平局）。
            一旦游戏结束，将公布获胜玩家或宣布平局。*/
        public class TicTacToe1
        {
            private int[] rows;
            private int[] cols;
            private int diag;
            private int antiDiag;
            private int size;

            public TicTacToe1(int n)
            {
                size = n;
                rows = new int[n];
                cols = new int[n];
                diag = 0;
                antiDiag = 0;
            }

            public int Move(int row, int col, int player)
            {
                int score = (player == 1) ? 1 : -1;

                rows[row] += score;
                cols[col] += score;

                if (row == col)
                {
                    diag += score;
                }

                if (row == size - col - 1)
                {
                    antiDiag += score;
                }

                if (Math.Abs(rows[row]) == size || Math.Abs(cols[col]) == size || Math.Abs(diag) == size || Math.Abs(antiDiag) == size)
                {
                    return player;
                }

                return 0;
            }
        }
        //348. Design Tic-Tac-Toe 
        //是一个设计题，需要实现一个井字游戏（Tic-Tac-Toe）:
        //TicTacToe(n)：构造函数nxn的矩阵，用于初始化游戏。
        //move(row, col, player)：玩家在指定位置下棋，row和col代表下棋的位置，player代表玩家，取值为1或2，分别表示玩家1和玩家2.move条件：该位置是空的（即未被占据）。该位置下棋后，玩家能够获胜。
        //思路: row和col用list，因为要存player走过的，这里注意要添加对角线和反对角线，因当他们和row，rol有一个满足这个矩阵的n，就证明此时的player
        public class TicTacToe2
        {
            private int[][] board;
            private int[] rows;
            private int[] cols;
            private int diagonal;
            private int antiDiagonal;
            private int n;

            public TicTacToe2(int n)
            {
                this.n = n;
                board = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    board[i] = new int[n];
                }

                rows = new int[n];
                cols = new int[n];
                diagonal = 0;
                antiDiagonal = 0;
            }

            public int Move(int row, int col, int player)
            {
                int value = (player == 1) ? 1 : -1;

                rows[row] += value;
                cols[col] += value;

                if (row == col)
                    diagonal += value;

                if (row + col == n - 1)
                    antiDiagonal += value;

                if (Math.Abs(rows[row]) == n || Math.Abs(cols[col]) == n ||
                    Math.Abs(diagonal) == n || Math.Abs(antiDiagonal) == n)
                {
                    return player;
                }

                return 0;
            }
        }
        public class TicTacToe3
        {
            private Dictionary<int, int> rows;
            private Dictionary<int, int> cols;
            private Dictionary<int, int> diagonal;
            private Dictionary<int, int> antiDiagonal;
            private int size;

            public TicTacToe3(int n)
            {
                rows = new Dictionary<int, int>();
                cols = new Dictionary<int, int>();
                diagonal = new Dictionary<int, int>();
                antiDiagonal = new Dictionary<int, int>();
                size = n;
            }

            public int Move(int row, int col, int player)
            {
                int value = (player == 1) ? 1 : -1;

                if (!rows.ContainsKey(row))
                    rows[row] = 0;
                rows[row] += value;

                if (!cols.ContainsKey(col))
                    cols[col] = 0;
                cols[col] += value;

                if (row == col)
                {
                    if (!diagonal.ContainsKey(1))
                        diagonal[1] = 0;
                    diagonal[1] += value;
                }

                if (row + col == size - 1)
                {
                    if (!antiDiagonal.ContainsKey(1))
                        antiDiagonal[1] = 0;
                    antiDiagonal[1] += value;
                }

                if (Math.Abs(rows[row]) == size || Math.Abs(cols[col]) == size ||
                    Math.Abs(diagonal.GetValueOrDefault(1)) == size || Math.Abs(antiDiagonal.GetValueOrDefault(1)) == size)
                {
                    return player;
                }

                return 0;
            }
        }