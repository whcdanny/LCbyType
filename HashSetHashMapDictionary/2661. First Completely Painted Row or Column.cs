//Leetcode 2661. First Completely Painted Row or Column med
//题意：给给定一个整数数组 arr 和一个 m x n 的整数矩阵 mat，其中 arr 和 mat 包含范围在 [1, m * n] 内的所有整数。
//遍历数组 arr，从索引 0 开始，将 mat 中包含整数 arr[i] 的单元格进行涂色。
//返回在 mat 中某一行或某一列被完全涂色时的最小索引 i。
//思路：hashtable, Dictionary存入矩阵的数值和其对应的row和colum
//然后根据arr，找到每一个数字对应的row和colum，如果当前的row或者colum刚好等于矩阵的相对应的长宽，就说明找到res
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            Dictionary<int, int[]> map = new Dictionary<int, int[]>();
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (!map.ContainsKey(mat[i][j]))
                    {
                        map.Add(mat[i][j], new int[] { i, j });
                    }
                }
            }
            int[] rowCount = new int[mat.Length];
            int[] colCount = new int[mat[0].Length];
            for (int i = 0; i < arr.Length; i++)
            {
                //get row and col
                int row = map[arr[i]][0];
                int col = map[arr[i]][1];
                rowCount[row] += 1;
                colCount[col] += 1;
                if (colCount[col] == mat.Length)
                {
                    return i;
                }
                if (rowCount[row] == mat[0].Length)
                {
                    return i;
                }

            }
            return 0;
        }