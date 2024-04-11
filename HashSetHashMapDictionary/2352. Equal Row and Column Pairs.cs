//Leetcode 2352. Equal Row and Column Pairs med
//题意：给定一个 n x n 的整数矩阵 grid，返回满足以下条件的行列配对 (ri, cj) 的数量，其中第 ri 行和第 cj 列相等。
//如果它们包含相同顺序的相同元素，则认为行列配对相等（即，数组相等）。
//思路：hashtable 用三个loop，把每一行和每一列做比较；        
//时间复杂度：O(n^3)
//空间复杂度：O(1)
        public int EqualPairs(int[][] grid)
        {
            int ans = 0;
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid.Length; j++)
                {
                    int check = 0;
                    for (int k = 0; k < grid.Length; k++)
                        if (grid[i][k] == grid[k][j])
                            check++;
                    if (check == grid.Length)
                        ans++;
                }
            return ans;
        }