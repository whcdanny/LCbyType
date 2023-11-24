//Leetcode 529. Minesweeper med
//题意：给定一个代表游戏板的字符矩阵，'M' 代表地雷，'E' 代表未挖出的空格，'B' 代表没有相邻地雷的已挖出的空格，数字（'1' 到 '8'）表示地雷周围的地雷数，'X' 表示已挖出的地雷。现在点击一个坐标（i，j），如果点击到地雷 'M'，则将其改为 'X' 并停止游戏；如果点击到空格 'E'，则递归地揭露其相邻的空格；如果点击到数字 '1' 到 '8'，则将其显示。游戏结束的条件是点击到地雷 'M' 或者所有的空格都被揭露。
//思路：使用 BFS 历遍的时候是9个方向，然后先用sum来确定你周围是否有炸弹并算出总和，如果sum=0，表示没有炸弹，那么就可以放入queue，依此类推；
//时间复杂度: 遍O(rows * cols)
//空间复杂度：O(rows * cols) 用于存储访问过的，最坏情况 q 可以拥有所有元素
        public char[][] UpdateBoard(char[][] board, int[] click)
        {

            if (board[click[0]][click[1]] == 'M')
            {
                board[click[0]][click[1]] = 'X';
                return board;
            }

            int rows = board.Length;
            int cols = board[0].Length;
            int[][] dirs = new int[][] {new int[] {-1,0}, new int[] {0,1}, new int[] {1,0},new int[] {0,-1}, new int[] {-1,-1}, new int[] {-1,1}, new int[] {1, 1}, new int[] {1, -1}};
            bool[] visited = new bool[rows * cols];

            var q = new Queue<int[]>();
            q.Enqueue(click);
            visited[click[0] * cols + click[1]] = true;

            while (q.Count != 0)
            {

                int[] curr = q.Dequeue();
                int sum = 0;
                for (int d = 0; d < dirs.Length; d++)
                {
                    int x = curr[0] + dirs[d][0];
                    int y = curr[1] + dirs[d][1];
                    if (x < 0 || y < 0 || x >= rows || y >= cols)
                    {
                        continue;
                    }

                    sum += board[x][y] == 'M' ? 1 : 0;
                }

                board[curr[0]][curr[1]] = sum == 0 ? 'B' : (char)(sum + '0');
                if (sum != 0) continue;

                for (int d = 0; d < dirs.Length; d++)
                {
                    int x = curr[0] + dirs[d][0];
                    int y = curr[1] + dirs[d][1];

                    if (x < 0 || y < 0 || x >= rows || y >= cols || visited[x * cols + y] || board[x][y] == 'M')
                    {
                        continue;
                    }

                    visited[x * cols + y] = true;
                    q.Enqueue(new int[] { x, y });
                }
            }

            return board;
        }