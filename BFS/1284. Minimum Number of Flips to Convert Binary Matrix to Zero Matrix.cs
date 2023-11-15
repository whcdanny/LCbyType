//Leetcode 1284. Minimum Number of Flips to Convert Binary Matrix to Zero Matrix hard
//题意：给定一个 m x n 的二进制矩阵，其中每个 0 表示关闭，每个 1 表示打开。如果一个单元格被按下，则该单元格和所有相邻的 4 个单元格的值都会被切换（0 变为 1，1 变为 0）。返回使矩阵中的所有单元格均为 0 所需的最小翻转次数。如果无法使所有单元格都变为 0，则返回 -1。
//思路：BFS 记录下当前的matrix，然后记录下当前以string形式表示的字符串，然后开始BFS, 对每一个matrix进行反转并且计算次数，并记录下string以方便查重，然后直到找到全部是0；
//时间复杂度: O(m * n * 2^(m * n))，其中 m 和 n 分别是矩阵的行数和列数。
//空间复杂度：O(2^(m * n))
        public int MinFlips(int[][] mat)
        {
            HashSet<string> visited = new HashSet<string>();
            string matrixString = getMatrixAsString(mat);
            Queue<(int[][] tempMat, int flips)> queue = new Queue<(int[][] tempMat, int flips)>();
            queue.Enqueue((mat, 0));
            visited.Add(matrixString);            
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (isZeroMatrix(current.tempMat))
                    return current.flips;
                for (int i = 0; i < current.tempMat.Length; i++)
                {
                    for (int j = 0; j < current.tempMat[0].Length; j++)
                    {
                        Flip(current.tempMat, i, j);
                        string matAsString = getMatrixAsString(current.tempMat);

                        if (visited.Contains(matAsString))
                        {
                            Flip(current.tempMat, i, j);
                            continue;
                        }

                        visited.Add(matAsString);
                        queue.Enqueue((current.tempMat.Select(a => a.ToArray()).ToArray(), current.flips + 1));
                        Flip(current.tempMat, i, j);
                    }
                }
            }
            return -1;
        }

        private string getMatrixAsString(int[][] mat)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    sb.Append(Convert.ToString(mat[i][j]) + "-");
                }
            }

            return sb.ToString();
        }

        private bool isZeroMatrix(int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 1)
                        return false;
                }
            }
            return true;
        }
        private void Flip(int[][] mat, int x, int y)
        {
            List<int[]> dirs = new List<int[]> { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            mat[x][y] = mat[x][y] == 0 ? 1 : 0;

            foreach(var dir in dirs)
            {
                int nx = x + dir[0];
                int ny = y + dir[1];

                if (nx < 0 || nx >= mat.Length || ny < 0 || ny >= mat[0].Length)
                    continue;

                mat[nx][ny] = mat[nx][ny] == 0 ? 1 : 0;
            }
        }
