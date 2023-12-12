//Leetcode 529. Minesweeper med
//题意：给定一个代表游戏板的字符矩阵，'M' 代表地雷，'E' 代表未挖出的空格，'B' 代表没有相邻地雷的已挖出的空格，数字（'1' 到 '8'）表示地雷周围的地雷数，'X' 表示已挖出的地雷。
//现在点击一个坐标（i，j），如果点击到地雷 'M'，则将其改为 'X' 并停止游戏；如果点击到空格 'E'，则递归地揭露其相邻的空格；如果点击到数字 '1' 到 '8'，则将其显示。游戏结束的条件是点击到地雷 'M' 或者所有的空格都被揭露。
//思路：深度优先搜索（DFS）进行递归，根据规则更新游戏板。对于每个点击位置，根据点击位置的字符，有以下几种情况：
//如果点击位置是地雷 'M'，将其改为 'X' 并返回。
//如果点击位置是空方块 'E'，计算周围地雷的数量，如果数量为 0，将其改为已揭示的空白方块 'B'，并递归地揭示其周围的方块；如果数量大于 0，将其改为数字（'1' 到 '8'）。
//如果点击位置是已揭示的方块 'B' 或数字，保留原字符。
//时间复杂度: 遍O(rows * cols)
//空间复杂度：O(rows * cols) 用于存储访问过的，最坏情况 q 可以拥有所有元素
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            int row = click[0], col = click[1];

            // Case 1: Click on a mine 'M'
            if (board[row][col] == 'M')
            {
                board[row][col] = 'X';
            }
            // Case 2: Click on an empty square 'E'
            else
            {
                DFS_UpdateBoard(board, row, col);
            }

            return board;
        }

        private void DFS_UpdateBoard(char[][] board, int row, int col)
        {
            int mines = CountAdjacentMines(board, row, col);

            // Case 2.1: No adjacent mine, mark as 'B' and recursively reveal its neighbors
            if (mines == 0)
            {
                board[row][col] = 'B';
                int[] directions = { -1, 0, 1 };
                foreach (int dr in directions)
                {
                    foreach (int dc in directions)
                    {
                        if (dr == 0 && dc == 0) continue; // Skip the current cell
                        int newRow = row + dr, newCol = col + dc;
                        if (newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board[0].Length &&
                            board[newRow][newCol] == 'E')
                        {
                            DFS_UpdateBoard(board, newRow, newCol);
                        }
                    }
                }
            }
            // Case 2.2: There are adjacent mines, mark as the number of adjacent mines
            else
            {
                board[row][col] = (char)('0' + mines);
            }
        }

        private int CountAdjacentMines(char[][] board, int row, int col)
        {
            int mines = 0;
            int[] directions = { -1, 0, 1 };
            foreach (int dr in directions)
            {
                foreach (int dc in directions)
                {
                    if (dr == 0 && dc == 0) continue; // Skip the current cell
                    int newRow = row + dr, newCol = col + dc;
                    if (newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board[0].Length &&
                        (board[newRow][newCol] == 'M' || board[newRow][newCol] == 'X'))
                    {
                        mines++;
                    }
                }
            }
            return mines;
        }