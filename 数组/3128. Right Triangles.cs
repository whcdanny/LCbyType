//Leetcode 3128. Right Triangles med
//题目：给定一个二维布尔矩阵 grid。
//如果 grid 中的 3 个元素可以组成一个直角三角形，满足以下条件：
//三角形的一个元素和另一个元素在同一行。
//三角形的其中一个元素和另一个元素在同一列。
//这 3 个元素不必相邻。
//如果三角形的 3 个元素的值均为 1，则称之为一个有效的直角三角形。
//返回可以组成的所有直角三角形的数量。
//思路: 统计每行和每列中的 1 的数量：
//首先，我们统计每一行和每一列中等于 1 的元素数量。因为一个有效的直角三角形要求共享同一行或同一列的元素来构成直角。
//遍历每个位置，计算以该位置为直角顶点的直角三角形数量：
//对于每一个 1 的位置(i, j)，假设它作为直角顶点。以 grid[i][j] 为直角顶点的三角形数量可以通过如下公式计算：
//三角形数量 = (行中 1 的数量 - 1) * (列中 1 的数量 - 1)
//这是因为其他符合条件的点必须位于同一行或同一列的其他位置。
//时间复杂度：O(m * n)
//空间复杂度：O(m + n)
        public long NumberOfRightTriangles(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[] rowCount = new int[m];
            int[] colCount = new int[n];

            // 统计每一行和每一列中的 1 的数量
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        rowCount[i]++;
                        colCount[j]++;
                    }
                }
            }

            long triangles = 0;
            // 遍历每个位置，计算以该点为直角顶点的三角形数量
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        triangles += (long)(rowCount[i] - 1) * (colCount[j] - 1);
                    }
                }
            }

            return triangles;
        }