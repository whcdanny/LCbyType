//Leetcode 240. Search a 2D Matrix II med
//题意：在一个按照以下规律排列的二维矩阵中查找目标值：每行中的整数从左到右按升序排列。每列中的整数从上到下按升序排列。
//思路：二分法: 二分查找的变体来解决。我们可以从矩阵的右上角开始搜索，因为左上角是一行的最大值，同时也是一列里面的最小值，这样才能进行判断； 如果目标值大于当前元素，则目标值必定在当前元素的下方；如果目标值小于当前元素，则目标值必定在当前元素的左侧。
//时间复杂度:  m 是矩阵的行数，n 是矩阵的列数 , O(log(m*n)) = O(log(m) + log(n))
//空间复杂度： O(1)
        public bool SearchMatrixII(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length < 1 || matrix[0].Length < 1)
            {
                return false;
            }
            int col = matrix[0].Length - 1;
            int row = 0;
            while (col >= 0 && row <= matrix.Length - 1)
            {
                if (target == matrix[row][col])
                {
                    return true;
                }
                else if (target < matrix[row][col])
                {
                    col--;
                }
                else if (target > matrix[row][col])
                {
                    row++;
                }
            }
            return false;
        }