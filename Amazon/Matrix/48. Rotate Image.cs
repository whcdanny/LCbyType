//Leetcode 48. Rotate Image med
//题目：给定一个n x n2Dmatrix图像，将图像旋转90度（顺时针）。
//您必须就地旋转图像，这意味着您必须直接修改输入的 2D 矩阵。请勿分配另一个 2D 矩阵并进行旋转。
//思路: 思维逻辑，90°顺时针旋转，
// 先沿对角线镜像对称二维矩阵
// 然后反转二维矩阵的每一行
//时间复杂度：O(n*n)
//空间复杂度：O(1)
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            // 先沿对角线镜像对称二维矩阵
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {                   
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            // 然后反转二维矩阵的每一行
            foreach (int[] row in matrix)
            {
                int i = 0, j = row.Length - 1;
                while (j > i)
                {
                    // swap(arr[i], arr[j]);
                    int temp = row[i];
                    row[i] = row[j];
                    row[j] = temp;
                    i++;
                    j--;
                }
            }
        }