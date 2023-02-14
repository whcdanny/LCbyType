//59. Spiral Matrix II med
//根据给的n写出螺旋的matrix跟54很想，说白了就要写出54的matrix
//思路：还是从做四个边界上下左右，先上往右，然后右边境往下，下边境往左，然和左边境往上；这次没走一次就要把数放入建立好的matrix里；
		public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for(int i=0; i < n; i++)
            {
                matrix[i] = new int[n];
            }
            int upper_bound = 0, lower_bound = n - 1;
            int left_bound = 0, right_bound = n - 1;
            // 需要填入矩阵的数字
            int num = 1;

            while (num <= n * n)
            {
                if (upper_bound <= lower_bound)
                {
                    // 在顶部从左向右遍历
                    for (int j = left_bound; j <= right_bound; j++)
                    {
                        matrix[upper_bound][j] = num++;
                    }
                    // 上边界下移
                    upper_bound++;
                }

                if (left_bound <= right_bound)
                {
                    // 在右侧从上向下遍历
                    for (int i = upper_bound; i <= lower_bound; i++)
                    {
                        matrix[i][right_bound] = num++;
                    }
                    // 右边界左移
                    right_bound--;
                }

                if (upper_bound <= lower_bound)
                {
                    // 在底部从右向左遍历
                    for (int j = right_bound; j >= left_bound; j--)
                    {
                        matrix[lower_bound][j] = num++;
                    }
                    // 下边界上移
                    lower_bound--;
                }

                if (left_bound <= right_bound)
                {
                    // 在左侧从下向上遍历
                    for (int i = lower_bound; i >= upper_bound; i--)
                    {
                        matrix[i][left_bound] = num++;
                    }
                    // 左边界右移
                    left_bound++;
                }
            }
            return matrix;
        }