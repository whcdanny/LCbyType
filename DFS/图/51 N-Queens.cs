//Leetcode 51 N-Queens hard
//题意：求解在 n x n 的棋盘上放置 n 个皇后，使得它们互相不能攻击到彼此。这里的规则是皇后可以水平、垂直和对角线移动
//思路：深度优先搜索（DFS, 用一个list[]列为位置index，而list[index]存行的位置，
//时间复杂度:  n 是输入字符串的长度, O(n)
//空间复杂度： n 是输入字符串的长度, O(n)
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> res = new List<IList<string>>();
            int[] list = new int[n];
            Array.Fill(list, -1);
            SolveNQueens(res, list, n, 0);
            return res;
        }
        private void SolveNQueens(IList<IList<string>> result, int[] list, int n, int row)
        {
            if (row == n)
            {
                result.Add(GenerateBoard(list));
                return;
            }
            for(int col = 0; col < n; col++)
            {
                if(IsValidSolveNQueens(list, n, row, col))
                {
                    list[row] = col;
                    SolveNQueens(result, list, n, row + 1);
                    list[row] = -1;
                }
            }
        }
        private bool IsValidSolveNQueens(int[] list, int n, int row, int col)
        {
            for(int i = 0; i < row; i++)
            {
                if (list[i] == col || list[i] - i == col - row || list[i] + i == col + row)
                    return false;
            }
            return true;
        }
        private IList<string> GenerateBoard(int[] list)
        {
            int n = list.Length;
            IList<string> res = new List<string>();
            for(int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                Array.Fill(row, '.');
                row[list[i]] = 'Q';
                res.Add(new string(row));

            }
            return res;
        }