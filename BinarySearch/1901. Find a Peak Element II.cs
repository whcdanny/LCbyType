//Leetcode 1901. Find a Peak Element II med
//题意：题目描述一个二维矩阵 mat，其中没有两个相邻的单元格具有相同的值。峰值元素是指在矩阵中严格大于其左、右、上、下相邻元素的元素。要求找到任何一个峰值元素 mat[i][j]，并返回长度为2的数组 [i, j]。
//矩阵的外围被值为 -1 的外围边界包围。
//思路：用二分法来找到行i，然后找到这一行最大的数的列j，然后再根据上下判断是否为最大；
//注：如果left和right相同时，如果mid+1或者mid-1超出mat的长度，那么就直接输出；
//时间复杂度: O(log n)，其中 n 是问题的规模。这是因为我们使用二分查找来寻找合适的土地边长。
//空间复杂度：O(1)，因为我们只使用了常量级别的额外空间。
        public int[] FindPeakGrid(int[][] mat)
        {
            int left = 0;
            int right = mat.Length - 1;
            while (left <= right)
            {
                
                int mid = left + (right - left) / 2;
                int colum = rowPeak(mat, mid);
                int value = mat[mid][colum];
                if (left == right)
                {
                    if (mid + 1 > mat.Length - 1 || mid - 1 < 0)
                        return new int[] { mid, colum };
                }
                if (mid == 0)
                {
                    if (value > mat[mid + 1][colum])
                        return new int[] { mid, colum };
                }
                else if (mid == mat.Length - 1)
                {
                    if (value > mat[mid - 1][colum])
                        return new int[] { mid, colum };
                }
                else
                {
                    if (value > mat[mid - 1][colum] && value > mat[mid - 1][colum])
                        return new int[] { mid, colum };
                }
                if (value > mat[mid - 1][colum] && value > mat[mid - 1][colum])
                    return new int[] { mid, colum };
                if (value < mat[mid + 1][colum])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return new int[] { -1, -1 };
        }
        public int rowPeak(int[][] mat, int row)
        {
            int max = -1;
            int res=0;
            for(int i = 0; i < mat[0].Length; i++)
            {
                if (mat[row][i] > max)
                {
                    max = mat[row][i];
                    res = i;
                }
            }
            return res;
        }       
