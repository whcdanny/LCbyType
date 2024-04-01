//Leetcode 2711. Difference of Number of Distinct Values on Diagonals med
//题意：要求计算一个大小为 m x n 的矩阵，矩阵中每个元素 (r, c) 的值需要按照以下方式计算：
//计算单元格(r, c) 的左上对角线上的不同值的数量。
//计算单元格(r, c) 的右下对角线上的不同值的数量。
//将步骤 1 和步骤 2 中计算得到的数量相减并取绝对值，作为矩阵的元素值。
//思路：hashtable, 历遍grid，用hashset存储对每个位置找到左上对角线和右下对角线不同的值，
//最后给出每个hashset的绝对值之差；
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int[][] DifferenceOfDistinctValues(int[][] grid)
        {
            int[][] res = new int[grid.Length][];
            int index = 0;
            while (index < res.Length)
            {
                res[index] = new int[grid[0].Length];
                index++;
            }

            index = 0;
            while (index < grid.Length)
            {
                int j = 0;
                while (j < grid[0].Length)
                {
                    res[index][j] = Math.Abs(topLeft(grid, index, j) - bottomRight(grid, index, j));
                    j++;
                }
                index++;
            }

            return res;
        }

        private int topLeft(int[][] grid, int i, int j)
        {
            HashSet<int> hashset = new HashSet<int>();
            i--;
            j--;
            while (i > -1 && j > -1)
            {
                hashset.Add(grid[i][j]);
                i--;
                j--;
            }

            return hashset.Count;
        }

        private int bottomRight(int[][] grid, int i, int j)
        {
            HashSet<int> hashset = new HashSet<int>();
            i++;
            j++;
            while (i < grid.Length && j < grid[0].Length)
            {
                hashset.Add(grid[i][j]);
                i++;
                j++;
            }

            return hashset.Count;
        }
