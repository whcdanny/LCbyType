//54. Spiral Matrix med
//给一个矩阵，按照螺旋方式读取，也就是先从最上面一行读到头，然后往下读到头，然后往上读到刚才的起始点下一位，然后重复直到读完；
//思路：做四个边界上下左右，先上往右，然后右边境往下，下边境往左，然和左边境往上；
		public IList<int> SpiralOrder(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int upper_bound = 0, lower_bound = m - 1;
            int left_bound = 0, right_bound = n - 1;
            IList<int> res = new List<int>();            
            while (res.Count() < m * n)
            {
                if (upper_bound <= lower_bound)
                {
                    // 在顶部从左向右遍历
                    for (int j = left_bound; j <= right_bound; j++)
                    {
                        res.Add(matrix[upper_bound][j]);
                    }
                    // 上边界下移
                    upper_bound++;
                }

                if (left_bound <= right_bound)
                {
                    // 在右侧从上向下遍历
                    for (int i = upper_bound; i <= lower_bound; i++)
                    {
                        res.Add(matrix[i][right_bound]);
                    }
                    // 右边界左移
                    right_bound--;
                }

                if (upper_bound <= lower_bound)
                {
                    // 在底部从右向左遍历
                    for (int j = right_bound; j >= left_bound; j--)
                    {
                        res.Add(matrix[lower_bound][j]);
                    }
                    // 下边界上移
                    lower_bound--;
                }

                if (left_bound <= right_bound)
                {
                    // 在左侧从下向上遍历
                    for (int i = lower_bound; i >= upper_bound; i--)
                    {
                        res.Add(matrix[i][left_bound]);
                    }
                    // 左边界右移
                    left_bound++;
                }
            }
            return res;
        }