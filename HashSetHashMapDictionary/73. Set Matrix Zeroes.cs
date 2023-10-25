//Leetcode 73. Set Matrix Zeroes med
//题意：给定一个 m x n 的矩阵，如果一个元素是 0，则将其所在行和列的所有元素都设为 0。请使用原地算法。
//思路：两个集合分别来记录所有含有0的行和列的索引
//时间复杂度：两次遍历矩阵，因此时间复杂度是 O(m*n)
//空间复杂度：O(m+n)
        public void SetZeroes1(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            // 记录含有0的行和列的索引
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            // 将含有0的行和列置为0
            foreach (int row in rows)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[row][j] = 0;
                }
            }

            foreach (int col in cols)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][col] = 0;
                }
            }
        }

        //73. Set Matrix Zeroes med
        //是一个将矩阵中某个元素为0的行和列都设为0
        //思路：用两个dictionary来找到横向和纵向为0的位置，然后设置为true，然后再历遍matrix只要横纵位置跟0的位置重复，就设置成0；
        public void SetZeroes2(int[][] matrix)
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