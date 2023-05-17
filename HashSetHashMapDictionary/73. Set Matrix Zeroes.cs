//73. Set Matrix Zeroes med
//是一个将矩阵中某个元素为0的行和列都设为0
//思路：用两个dictionary来找到横向和纵向为0的位置，然后设置为true，然后再历遍matrix只要横纵位置跟0的位置重复，就设置成0；
        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            Dictionary<int, bool> rows = new Dictionary<int, bool>();
            Dictionary<int, bool> cols = new Dictionary<int, bool>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows[i] = true;
                        cols[j] = true;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rows.ContainsKey(i) || cols.ContainsKey(j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }