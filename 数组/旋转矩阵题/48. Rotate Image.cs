//48. Rotate Image med
//给一个矩阵，进行顺时针旋转；
//思路：先以左上到右下对称线先旋转，这样（0，1）->（1，0）依此类推，然后再让每一行进行反转
//做旋转矩阵的题一定要利用好对称线；
		public void rotate(int[][] matrix)
        {
            int n = matrix.Length;
            // 先沿对角线镜像对称二维矩阵
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    // swap(matrix[i][j], matrix[j][i]);
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            // 然后反转二维矩阵的每一行
            foreach (int[] row in matrix)
            {
                reverse(row);
            }
        }

        // 反转一维数组
        void reverse(int[] arr)
        {
            int i = 0, j = arr.Length - 1;
            while (j > i)
            {
                // swap(arr[i], arr[j]);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }
//类似上一个思路，先每一列反转，然后 y=-x的对称先旋转		
		public void Rotate(int[][] matrix) {
        Array.Reverse(matrix);、、每一列反转
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int val = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = val;
            }
        }
    }

//延展题：如果是逆时针旋转怎么办；
//将二维矩阵原地逆时针旋转 90 度
//思路：先以左下到右上的对称线先旋转，这样（0，0）->（n-1，n-1）依此类推，然后再让每一行进行反转
//做旋转矩阵的题一定要利用好对称线；
        public void rotate2(int[][] matrix)
        {
            int n = matrix.Length;
            // 沿左下到右上的对角线镜像对称二维矩阵
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    // swap(matrix[i][j], matrix[n-j-1][n-i-1])
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - j - 1][n - i - 1];
                    matrix[n - j - 1][n - i - 1] = temp;
                }
            }
            // 然后反转二维矩阵的每一行
            foreach (int[] row in matrix)
            {
                reverse(row);
            }
        }
		// 反转一维数组
        void reverse(int[] arr)
        {
            int i = 0, j = arr.Length - 1;
            while (j > i)
            {
                // swap(arr[i], arr[j]);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }