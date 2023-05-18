//348. Design Tic-Tac-Toe med
//是一个设计题，需要实现一个井字游戏（Tic-Tac-Toe）:
//TicTacToe(n)：构造函数nxn的矩阵，用于初始化游戏。
//move(row, col, player)：玩家在指定位置下棋，row和col代表下棋的位置，player代表玩家，取值为1或2，分别表示玩家1和玩家2.move条件：该位置是空的（即未被占据）。该位置下棋后，玩家能够获胜。
//思路: row和col用list，因为要存player走过的，这里注意要添加对角线和反对角线，因当他们和row，rol有一个满足这个矩阵的n，就证明此时的player
        public class TicTacToe1
        {
            private int[][] board;
            private int[] rows;
            private int[] cols;
            private int diagonal;
            private int antiDiagonal;
            private int n;

            public TicTacToe1(int n)
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
        public class TicTacToe2
        {
            private Dictionary<int, int> rows;
            private Dictionary<int, int> cols;
            private Dictionary<int, int> diagonal;
            private Dictionary<int, int> antiDiagonal;
            private int size;

            public TicTacToe2(int n)
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